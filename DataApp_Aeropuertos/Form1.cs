using DAL.Classes;
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

namespace DataApp_Aeropuertos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           // dataGridView1.Visible = false;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet ds = VerHurtos();
            dataGridView1.DataSource = ds.Tables[0];
            DBHelper.llenarItems(comboBox1,comboBox2,comboBox3);
        }

        public static DataSet VerHurtos()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    
                };
            return DBHelper.ExecuteDataSet("ups_Hurtos", dbParams);

        }

        public static DataSet VerHurtosDep(ComboBox cb)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                        DBHelper.MakeParam("@Departamento", SqlDbType.VarChar, 50, cb.Text),
                };
            return DBHelper.ExecuteDataSet("ups_SendDepartamento", dbParams);
        }

        public static DataSet VerHurtosMun(ComboBox cb)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                        DBHelper.MakeParam("@Municipio", SqlDbType.VarChar, 50, cb.Text),
                };
            return DBHelper.ExecuteDataSet("ups_SendMunicipio", dbParams);
        }

        public static DataSet VerHurtosMar(ComboBox cb)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                        DBHelper.MakeParam("@MARCA", SqlDbType.VarChar, 50, cb.Text),
                }; 
            return DBHelper.ExecuteDataSet("ups_SendMarca", dbParams);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = VerHurtosDep(comboBox1);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = VerHurtosMun(comboBox2);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet ds = VerHurtosMar(comboBox3);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataSet ds = VerHurtos();
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
