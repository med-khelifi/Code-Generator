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
        string DataAccessPath = string.Empty;
        string BusinessLayerPath = string.Empty;
        public frmGenerate(string DatabaseName, List<string> SelectedTabels, string Path)
        {
            InitializeComponent();
            this.SelectedTabels = SelectedTabels;
            this.SavePath = Path;
            this.DatabaseName = DatabaseName;
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
            dgvTabels.Rows.Add("clsDataAccessUtil.cs");

            lblFileCount.Text = dgvTabels.Rows.Count.ToString() + " File(s).";
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            // Define base paths for Data Access and Business Layer
            DataAccessPath = Path.Combine(SavePath, DatabaseName + "_DataLayer");
            BusinessLayerPath = Path.Combine(SavePath, DatabaseName + "_BusinessLayer");

            // Ensure the layer directories exist (create if they don't exist)
            Directory.CreateDirectory(DataAccessPath);
            Directory.CreateDirectory(BusinessLayerPath);

            List<Task> tasks = new List<Task>();
            List<string> warnings = new List<string>(); // Store warning messages

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Iterate over selected tables
            foreach (var item in SelectedTabels)
            {
                string tableName = item.ToString().Trim();

                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        // Get table columns
                        var columns = await clsConnection.GetTableColumns(tableName);

                        // Validate columns
                        if (columns == null || columns.Count == 0)
                        {
                            lock (warnings) // Ensure thread safety when adding warnings
                            {
                                warnings.Add($"⚠ Warning: No columns found for table {tableName}");
                            }
                            return;
                        }

                        // Generate code for business and data access layers
                        string businessLayer = clsGenerator.GenerateBusinessLayer(tableName, columns);
                        string dataAccess = clsGenerator.GenerateDataLayer(tableName, columns);

                        // Save generated files to the respective layer directories
                        string businessFilePath = Path.Combine(BusinessLayerPath, "cls" + tableName + ".cs");
                        string dataFilePath = Path.Combine(DataAccessPath, tableName + "Data.cs");

                        clsUtil.SaveToFile(businessLayer, businessFilePath);
                        clsUtil.SaveToFile(dataAccess, dataFilePath);
                    }
                    catch (Exception ex)
                    {
                        // Log errors
                        clsUtil.LogError(ex);
                        lock (warnings)
                        {
                            warnings.Add($"❌ Error processing table {tableName}: {ex.Message}");
                        }
                    }
                }));
            }

            // Wait for all table-processing tasks to complete
            await Task.WhenAll(tasks);

            // Generate and save clsDataAccessUtil AFTER all other files are created
            string dataAccessUtilPath = Path.Combine(DataAccessPath, "clsDataAccessUtil.cs");
            clsUtil.SaveToFile(clsGenerator.clsDataAccessUtil(), dataAccessUtilPath);

            stopwatch.Stop();

            // Display any warnings collected
            if (warnings.Count > 0)
            {
                MessageBox.Show(string.Join("\n", warnings), "Warnings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Show success message
            MessageBox.Show($"✅ All files have been generated successfully in {stopwatch.ElapsedMilliseconds} ms.",
                             "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
