using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2_Day20
{
    public partial class Form3 : Form
    {
        DataTable dt;
        DataColumn dc;
        DataRow dr;
        DataTable addcustomer;
        public Form3()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            string custid, custdob, custpayment, custoffer;
            custid = txtcustid.Text;
            custdob = dob.Text;
            custpayment = paymentsource.Text;
            custoffer = offer.Text;
            try
            {
                dr = addcustomer.NewRow();
                dr[0] = int.Parse(custid);
                dr[1] = custdob;
                dr[2] = custpayment;
                dr[3] = custoffer;
                addcustomer.Rows.Add(dr);
            }
            catch (Exception ob)
            {
                MessageBox.Show(ob.Message);
            }
            clear();       
        }
        private void clear()
        {
            txtcustid.Text = "";
            dob.Text = "";
            offer.Text = "";
            paymentsource.Text = "";
        }
        DataTable GenerateTable()
        {
            dt = new DataTable("Additional Customer");
            dc = new DataColumn("custid", typeof(int));
            dt.Columns.Add(dc);
            dt.PrimaryKey = new DataColumn[] { dc };

            dc = new DataColumn("dob", typeof(string));
            dt.Columns.Add(dc);

            dc = new DataColumn("Paymentoffer_Source", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("OfferCashBack", typeof(string));
            dt.Columns.Add(dc);

            return dt;

        }
        private void Form3_Load(object sender, EventArgs e)
        {
            addcustomer = GenerateTable();
            dataGridView1.DataSource = addcustomer;
        }

        private void txtcustid_TextChanged(object sender, EventArgs e)
        {

            if (Regex.IsMatch(txtcustid.Text, "[^0-9]"))
            {
                MessageBox.Show("do not enter  non-numeric values");
                //txtpid.Text = txtprice.Text.Remove(txtprice.Text.Length - 1);
                txtcustid.Text = "";
            }
        }
    }
}
