using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAndAwait
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data source=(localdb)\MSSQLLocalDB; 
Initial catalog=Library; Integrated security=SSPI;");

        SqlDataAdapter adapter;
        DataSet set;
        public Form1()
        {
            InitializeComponent();
            adapter = new SqlDataAdapter(@"
SELECT * FROM AUTHORS_BOOKS;
SELECT * FROM AUTHORS;
SELECT * FROM BOOKS",conn);
            set = new DataSet();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(()=>
            {
                adapter.Fill(set);
                dataGridView1.Invoke(new Action(() => dataGridView1.DataSource = set.Tables[2]));
            });

            await Task.Run(()=>
            {
                var added = from c in set.Tables[1].AsEnumerable() select c.ItemArray[1];

                foreach (var i in added)
                    comboBox1.Invoke(new Action<string>(s=>comboBox1.Items.Add(s)),i);
            });

            
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                string sel = (string)comboBox1.Invoke(new Func<object>(()=> comboBox1.SelectedItem));

                var data = (from authors_books in set.Tables[0].AsEnumerable()
                            join authors in set.Tables[1].AsEnumerable() on authors_books.ItemArray[2].ToString()  equals authors.ItemArray[0].ToString()
                            join books in set.Tables[2].AsEnumerable() on authors_books.ItemArray[1]  .ToString()  equals books.ItemArray[0]  .ToString()
                            where authors.ItemArray[1].ToString() == sel
                            select authors_books).Count();

                label1.Invoke(new Action<int>(s=>label1.Text = s.ToString()),data);
            });
        }
    }
}
