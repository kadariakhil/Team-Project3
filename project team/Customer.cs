using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{

    public partial class Customer : Form
    {

        DataTable dt;
        DataColumn dc;
        DataRow dr;
        DataTable cust;

        public Customer()
        {
            InitializeComponent();
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            string custid, cname, cont,email,add;
            custid = txtcid.Text;
            cname = txtcname.Text;
            cont = txtcont.Text;
            email = txtemail.Text;
            add = txtcadd.Text;

            try
            {

                dr = cust.NewRow();
                dr[0] = int.Parse(custid);
                dr[1] = cname;
                dr[2] = long.Parse(cont);
                dr[3] = email;
                dr[4] = add;

                cust.Rows.Add(dr);
            }
            catch (Exception ob)
            {
                MessageBox.Show(ob.Message);
            }
            clear();
        }
        private void clear()
        {
            txtcid.Text = "";
            txtcname.Text = "";
            txtcont.Text = "";
            txtemail.Text = "";
            txtcadd.Text = "";

        }

        private void Customer_Load(object sender, EventArgs e)
        {

            cust = Generatetable();
            dataGridView1.DataSource = cust;
        }

        DataTable Generatetable()
        {
            dt = new DataTable("Customer");

            dc = new DataColumn("Customer Id", typeof(int));
            dt.Columns.Add(dc);
            dt.PrimaryKey = new DataColumn[] { dc };

            dc = new DataColumn("Customer Name", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("Customer contact", typeof(long));
            dt.Columns.Add(dc);

            dc = new DataColumn("Customer Email", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("Customer Address", typeof(string));
            dt.Columns.Add(dc);
            return dt;
        }

        private void txtcid_TextChanged(object sender, EventArgs e)
        {

            if (Regex.IsMatch(txtcid.Text, "[^0-9.]"))
            {
                MessageBox.Show("do not enter non numeric vals");
                //txtpid.Text = txtpid.Text.Remove(txtpid.Text.Length - 1);
                txtcid.Text = "";
            }
        }

        private void txtcont_TextChanged(object sender, EventArgs e)
        {

            if (Regex.IsMatch(txtcont.Text, "[^0-9.]"))
            {
                MessageBox.Show("do not enter non numeric vals");
                //txtpid.Text = txtpid.Text.Remove(txtpid.Text.Length - 1);
                txtcont.Text = "";
            }
        }
    }
}
