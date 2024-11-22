using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Database_Tier;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetDatabaseNames();
        }

        private void GetDatabaseNames()
        {
            try
            {
                DataTable databaseNames = DatabaseMethods.GetDatabaseNames();
                cbDatabases.DataSource = databaseNames;
                cbDatabases.DisplayMember = "name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string databaseName = cbDatabases.Text.ToString();
                dgvTables.DataSource = DatabaseMethods.GetTableNames(databaseName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string databaseName = cbDatabases.Text.ToString();
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var cellValue = dgvTables[e.ColumnIndex, e.RowIndex].Value;
                    string tableName = cellValue.ToString();
                    dgvColumns.DataSource = DatabaseMethods.GetTable(databaseName, tableName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                string databaseName = cbDatabases.Text.ToString();
                string tableName = dgvTables.CurrentCell.Value?.ToString();
                DataTable columns = (DataTable)dgvColumns.DataSource;

                if (columns == null)
                {
                    MessageBox.Show("Please choose the table.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                GenerateCode generateCode = new GenerateCode(databaseName, tableName, columns);
                tbCode.Text = generateCode.Generate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCopyDataTierText_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbCode.Text))
            {
                // Copy the text to the clipboard
                Clipboard.SetText(tbCode.Text.ToString().Trim());
                MessageBox.Show("Code copied to clipboard.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
