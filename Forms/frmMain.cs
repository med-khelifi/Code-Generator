
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using CodeGenerator_Project.Forms;
using System.Linq;
namespace CodeGenerator_Project.Connection
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        

        List<string> SelectedTabels = new List<string>();
        private clsGenerator.enGenerationMode _GetGenerationMode()
        {
            clsGenerator.enGenerationMode _Mode;
            if (rbtnInlineSQL.Checked)
            {
                _Mode = clsGenerator.enGenerationMode.Inline;
            }
            else
            {
                _Mode = clsGenerator.enGenerationMode.StoredProcedure;
            }
            return _Mode;
        }
        private List<string> _GetSelectedTabels()
        {
            List<string> SelectedTabels = new List<string>();
            foreach (var item in clDatabaseTabels.CheckedItems)
            {
                SelectedTabels.Add(item.ToString());
            }

            return SelectedTabels;
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            List<string> list = await clsConnection.LoadDatabasesList();
            if (list == null || list.Count == 0)
            {
                MessageBox.Show("Cannot Load Databases list", "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (var item in list)
                {
                    cbDatabases.Items.Add(item);
                }
            }

            // ✅ تجنب الخطأ بالتأكد من وجود عناصر في `cbDatabases`
            if (cbDatabases.Items.Count > 0)
            {
                cbDatabases.SelectedIndex = 0;
            }


        }

        private async void cbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDatabases.SelectedItem == null)
                return;

            string selectedDb = cbDatabases.SelectedItem.ToString().Trim();
            List<string> list = await clsConnection.GetTablesNameList(selectedDb);

            clDatabaseTabels.Items.Clear();

            if (list == null || list.Count == 0)
            {
                MessageBox.Show($"No tables found in database: {selectedDb}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var item in list)
            {
                clDatabaseTabels.Items.Add(item);
            }

            _CheckListItems(true);
            chkCheckAllList.Checked = true;
        }
        private void _CheckListItems(bool chk)
        {
            for (int i = 0; i < clDatabaseTabels.Items.Count; i++)
            {
                clDatabaseTabels.SetItemChecked(i, chk);
            }
        }

        private bool isUpdating = false; // متغير لمنع التكرار اللانهائي

        private void clDatabaseTabels_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isUpdating) return;

            this.BeginInvoke((Action)(() =>
            {
                isUpdating = true;

                // ✅ إصلاح الحساب ليشمل العنصر الذي يتغير حالياً
                bool allChecked = clDatabaseTabels.CheckedItems.Count + (e.NewValue == CheckState.Checked ? 1 : -1) == clDatabaseTabels.Items.Count;
                #region.Checked = allChecked;

                isUpdating = false;
            }));
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string selectedPath = txtPath.Text.Trim();

            // 1. Check if the path is empty
            if (string.IsNullOrWhiteSpace(selectedPath))
            {
                MessageBox.Show("Please enter a valid path.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Check if the path is properly formatted (contains invalid characters)
            if (selectedPath.Any(c => Path.GetInvalidPathChars().Contains(c)))
            {
                MessageBox.Show("The path contains invalid characters.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Check if the path is rooted (must be absolute like "C:\Folder")
            if (!Path.IsPathRooted(selectedPath))
            {
                MessageBox.Show("Please choose a valid root path.", "Invalid Path Root", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Check if the directory actually exists
            if (!Directory.Exists(selectedPath))
            {
                MessageBox.Show("The selected path does not exist. Please choose an existing directory.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If all validations pass, proceed to the next form
            frmGenerate frm = new frmGenerate
                (cbDatabases.Text.Trim(), _GetSelectedTabels(), selectedPath,_GetGenerationMode());
            frm.ShowDialog();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Select a folder";

            // Optionally, set the initial directory (can be left empty to use default)
            folderBrowserDialog1.SelectedPath = @"C:\";

            // Show the dialog and check if the user selected a folder
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the selected folder path
                txtPath.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        private void chkCheckAllList_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;

            isUpdating = true;
            _CheckListItems(chkCheckAllList.Checked);
            isUpdating = false;
        }
    }
}
#endregion