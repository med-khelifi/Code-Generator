using CodeGenerator_Project.Connection;
using CodeGenerator_Project.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenerator_Project.Forms
{
    public partial class frmGenerate : Form
    {
        List<string> SelectedTabels;
        string SavePath, DatabaseName;
        
        clsGenerator.enGenerationMode _Mode;
        public frmGenerate(string DatabaseName, List<string> SelectedTabels, string Path,clsGenerator.enGenerationMode Mode)
        {
            InitializeComponent();
            this.SelectedTabels = SelectedTabels;
            this.SavePath = Path;
            this.DatabaseName = DatabaseName;
            _Mode = Mode;
        }

        private void frmGenerate_Load(object sender, EventArgs e)
        {
            dgvTabels.Rows.Clear();
            dgvTabels.Columns.Clear(); // Ensure columns are not duplicated

            // Create a properly configured column
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
            {
                Name = "FileName",
                HeaderText = "File Name",
                ReadOnly = true
            };
            dgvTabels.Columns.Add(column);

            // Populate the rows
            foreach (var item in SelectedTabels)
            {
                dgvTabels.Rows.Add("cls" + item.ToString() + ".cs"); // Ensure the item is a string
                dgvTabels.Rows.Add("cls" + item.ToString() + "Data.cs"); // Ensure the item is a string
            }
            
            if(_Mode == clsGenerator.enGenerationMode.StoredProcedure)
            {
                foreach (var item in SelectedTabels)
                {
                    dgvTabels.Rows.Add("cls" + item.ToString() + "StordProcedure.sql"); // Ensure the item is a string
                }
            }
            


            dgvTabels.Rows.Add("clsDataAccessUtil.cs");

            lblFileCount.Text = dgvTabels.Rows.Count.ToString() + " File(s).";
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            SavePath = Path.Combine(SavePath, DatabaseName);
            Directory.CreateDirectory(SavePath);

            List<Task> tasks = new List<Task>();
            List<string> warnings = new List<string>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (!clsGenerator.GenerationStrategies.TryGetValue(_Mode, out var generateFunc))
            {
                MessageBox.Show("❌ Invalid generation mode selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var item in SelectedTabels)
            {
                string tableName = item.ToString().Trim();

                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        var columns = await clsConnection.GetTableColumnsForSP(tableName);

                        if (columns == null || columns.Count == 0)
                        {
                            lock (warnings)
                            {
                                warnings.Add($"⚠ Warning: No columns found for table {tableName}");
                            }
                            return;
                        }

                        await generateFunc(tableName,columns ,SavePath);
                    }
                    catch (Exception ex)
                    {
                        clsUtil.LogError(ex);
                        lock (warnings)
                        {
                            warnings.Add($"❌ Error processing table {tableName}: {ex.Message}");
                        }
                    }
                }));
            }

            await Task.WhenAll(tasks);
            await clsGenerator.GenerateAndSaveDataAccessUtil(SavePath);

            stopwatch.Stop();

            if (warnings.Count > 0)
            {
                MessageBox.Show(string.Join("\n", warnings), "Warnings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            MessageBox.Show($"✅ All files have been generated successfully in {stopwatch.ElapsedMilliseconds} ms.",
                             "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



    }
}
