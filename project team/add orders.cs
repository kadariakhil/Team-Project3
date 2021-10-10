using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class Form1 : Form
    {
        DataTable dt;
        DataColumn dc;
        DataRow dr;
        DataTable prod;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            string pid, pname, price, pdesc;
            pid = txtpid.Text;
            pname = txtpname.Text;
            price = txtprice.Text;
            pdesc = txtdesc.Text;
            try
            {

                dr = prod.NewRow();
                dr[0] = int.Parse(pid);
                dr[1] = pname;
                dr[2] = float.Parse(price);
                dr[3] = pdesc;

                prod.Rows.Add(dr);
            }
            catch(Exception ob)
            {
                MessageBox.Show(ob.Message);
            }
            clear();
         }
        private void clear()
        {
            txtpid.Text = "";
            txtpname.Text = "";
            txtprice.Text = "";
            txtdesc.Text = "";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            prod = Generatetable();
            dataGridView1.DataSource = prod;
        }

        DataTable Generatetable()
        {
            dt = new DataTable("Products");

            dc = new DataColumn("ProdId", typeof(int));
            dt.Columns.Add(dc);
            dt.PrimaryKey = new DataColumn[] { dc };

            dc = new DataColumn("ProdName", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("ProdPrice", typeof(float));
            dt.Columns.Add(dc);
            dc = new DataColumn("ProdDescription", typeof(string));
            dt.Columns.Add(dc);

            return dt;
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtprice.Text, "[^0-9.]"))
            {
                MessageBox.Show("do not enter non numeric vals");
                //txtprice.Text = txtprice.Text.Remove(txtprice.Text.Length - 1);
                txtprice.Text = "";
            }
        }

        private void txtpid_TextChanged(object sender, EventArgs e)
        {

            if (Regex.IsMatch(txtpid.Text, "[^0-9.]"))
            {
                MessageBox.Show("do not enter non numeric vals");
                //txtpid.Text = txtpid.Text.Remove(txtpid.Text.Length - 1);
                txtpid.Text = "";
            }
        }
    }
}
