using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_EX
{
    public partial class Form1 : Form
    {

        SqlDataAdapter adapter = null;
        DataSet dataSet = new DataSet();
        SqlConnection connection = new SqlConnection();
        SqlCommandBuilder builder = null;
        SqlDataReader reader = null;

        //SqlDataAdapter adapterCategory = null;
        //SqlConnection connection = new SqlConnection();
       // SqlCommandBuilder builder2 = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void connectToDBToolStripMenuItem_Click(object sender, EventArgs e)
        {

            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString;
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select * from Base", connection.ConnectionString);
                adapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                ts_status.Text = "Connection to bd success";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ts_status.Text = "All data read success";
                connection.Close();
            }
            /* if (adapterBase == null)
             {
                 adapterBase = new SqlDataAdapter();
                 dataGridView1.Rows.Clear();
                 dataGridView1.Columns.Clear();
             }
             else
             {
                 adapterBase = null;
                 dataSetBase = new DataSet();
             }
             connectionAsync.ConnectionString = ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString;
             try
             {
                 adapterBase = new SqlDataAdapter("select * from Category", connectionAsync.ConnectionString);
                 adapterBase.Fill(dataSetBase);
                 dataGridView1.DataSource = dataSetBase.Tables[0];
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {
                  ts_status.Text = "All data read success";
             }*/
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {     if(tabControl1.SelectedTab == tabPage1)
            {
                int lastid = 1;
                if(dataGridView1.Rows.Count > 0)
                {
                   lastid =(int)dataGridView1.Rows[dataGridView1.Rows.Count -1].Cells[0].Value;
                }
               Edit eb = new Edit(lastid);
                if (eb.ShowDialog() == DialogResult.OK)
                {
                    dataSet.Tables[0].Rows.Add(Int32.Parse(eb.textBox1.Text), eb.textBox2.Text);
                }
                eb.Dispose();
            }
        else if(tabControl1.SelectedTab ==tabPage2)
            {

            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {

                if (tabControl1.SelectedTab == tabPage1)
                {
                    if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Cells[0].Value != null)
                        dataSet.Tables[0].Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                
            }
        }
    }
}
