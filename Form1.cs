using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Student_Information
{
    public partial class Form1 : Form
    {
        readonly SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=Student_Info;Integrated Security=true");
        SqlDataAdapter adapter;
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM info", connection);
            adapter.FillSchema(table, SchemaType.Source);
            adapter.Fill(table);
            dgv.DataSource = table;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = table.NewRow();
                row["ID"] = Convert.ToInt32(tbxID.Text);
                row["Name"] = tbxName.Text;
                row["Department"] = tbxDept.Text;
                row["Gender"] = cbxGender.Text;
                row["Blood_Group"] = cbxBg.Text;
                row["Date_of_Birth"] = tbxDob.Text;
                row["Phone"] = tbxPhone.Text;
                row["Email"] = tbxEmail.Text;
                row["Present_Address"] = tbxPresentA.Text;
                row["Permanent_Address"] = tbxPermanentA.Text;
                table.Rows.Add(row);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateDB_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(table);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = table.Rows[dgv.CurrentRow.Index];
                table.Rows.Remove(row);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = table.Rows[dgv.CurrentRow.Index];
                if(row["ID"].Equals( Convert.ToInt32(tbxID.Text)))
                {
                    row["Name"] = tbxName.Text;
                    row["Department"] = tbxDept.Text;
                    row["Gender"] = cbxGender.Text;
                    row["Blood_Group"] = cbxBg.Text;
                    row["Date_of_Birth"] = tbxDob.Text;
                    row["Phone"] = tbxPhone.Text;
                    row["Email"] = tbxEmail.Text;
                    row["Present_Address"] = tbxPresentA.Text;
                    row["Permanent_Address"] = tbxPermanentA.Text;
                }
                else
                {
                    MessageBox.Show("CAN'T CHANGE THE STUDENT ID!");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteA_Click(object sender, EventArgs e)
        {
            table.Rows.Clear();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxID.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            tbxName.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            tbxDept.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            cbxGender.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            cbxBg.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            tbxDob.Text = dgv.CurrentRow.Cells[5].Value.ToString();
            tbxPhone.Text = dgv.CurrentRow.Cells[6].Value.ToString();
            tbxEmail.Text = dgv.CurrentRow.Cells[7].Value.ToString();
            tbxPresentA.Text = dgv.CurrentRow.Cells[8].Value.ToString();
            tbxPermanentA.Text = dgv.CurrentRow.Cells[9].Value.ToString();
        }
    }
}
