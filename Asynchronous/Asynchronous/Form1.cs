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

namespace Asynchronous
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data source=(localdb)\MSSQLLocalDB; Initial catalog=Library; " +
            "Integrated security=SSPI;");

        SqlDataReader reader;
        SqlCommand comm;
        public Form1()
        {
            InitializeComponent();
            conn.Open();
            comm = conn.CreateCommand();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int r1=0, r2=0;
            await Task.Run(async () =>
            {
                comm.CommandText = "SELECT SUM(LEN(Name)) FROM BOOKS WAITFOR DELAY '00:00:01'";
                var res = await comm.ExecuteScalarAsync();
                if (res is int)
                    r1 = (int)res;
            });

            await Task.Run(async () =>
            {
                comm.CommandText = "SELECT SUM(LEN(Name)) FROM AUTHORS WAITFOR DELAY '00:00:01'";
                var res = await comm.ExecuteScalarAsync();
                if (res is int)
                    r2 = (int)res;
            });

            label1.Text = r1.ToString();
            label2.Text = r2.ToString();
        }
    }
}
