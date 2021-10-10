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
    public partial class Offers : Form
    {
        DataTable dt;
        DataColumn dc;
        DataRow dr;
        DataTable addoffers;
        public Offers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string offerid, Discount,  Promosource;
        
            offerid = txtoid.Text;
            
            Promosource = listpromosource.Text;
            Discount = listdiscount.Text;

            try
            {
                dr = addoffers.NewRow();
                dr[0] = int.Parse(offerid);
                dr[1] = Discount;
                dr[2] = Promosource;

                addoffers.Rows.Add(dr);
            }
            catch (Exception ob)
            {
                MessageBox.Show(ob.Message);
            }
            clear();
        }
        private void clear()
        {
            txtoid.Text = "";
            listdiscount.Text = "";
            listpromosource.Text = "";

        }
        DataTable GenerateTable()
        {
            dt = new DataTable("Add Orders");
            dc = new DataColumn("OfferId", typeof(int));
            dt.Columns.Add(dc);
            dt.PrimaryKey = new DataColumn[] { dc };

            dc = new DataColumn("Discount", typeof(string));
            dt.Columns.Add(dc);

            dc = new DataColumn("PromoSource", typeof(string));
            dt.Columns.Add(dc);

            return dt;

        }

        private void txtoid_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtoid.Text, "[^0-9]"))
            {
                MessageBox.Show("do not enter  non-numeric values");
                //txtpid.Text = txtprice.Text.Remove(txtprice.Text.Length - 1);
                txtoid.Text = "";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            addoffers = GenerateTable();
            dataGridView1.DataSource = addoffers;
        }
    }
}

