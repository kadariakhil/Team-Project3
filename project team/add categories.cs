using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using System.Windows.Forms;

namespace ProjectCAT
{
    public partial class Form1 : Form
    {

        DataTable dt;
        DataColumn dc;
        DataRow dr;
        DataTable Cat;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_Textchanged(object sender, object EventArgs )
        {
            if (!Regex.IsMatch(txtCname.Text, @"[a - zA - Z]"))
            {
                MessageBox.Show("only A-Z accepted");
                txtCname.Text = "";
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cid, cname,  cdesc;
            cid = txtCID.Text;
            cname = txtCname.Text;
          
            cdesc = txtCdesc.Text;
            try
            {
                dr = Cat.NewRow();
                dr[0] = int.Parse(cid);
                dr[1] = cname;

                dr[2] = cdesc;
                Cat.Rows.Add(dr);
            }
            catch (Exception ob)
            {
                MessageBox.Show(ob.Message);
            }
            clear();
        }
        private void clear()
        {
            txtCID.Text = "";
            txtCname.Text = "";
            
            txtCdesc.Text = "";
        }


   

    private void Form1_Load(object sender, EventArgs e)
        {

            Cat = Generatetable();
            dataGridView1.DataSource = Cat;

        }
        DataTable Generatetable()
        {
            dt = new DataTable("Products_Category");

            dc = new DataColumn("CId", typeof(int));
            dt.Columns.Add(dc);
            dt.PrimaryKey = new DataColumn[] { dc };

            dc = new DataColumn("CName", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("CDescription", typeof(string));
            dt.Columns.Add(dc);

            return dt;
        }

        private void txtCID_TextChanged(object sender, EventArgs e)
        {

            if (Regex.IsMatch(txtCID.Text, "[^0-9]"))
            {
                MessageBox.Show("do not enter non numeric vals");
                txtCID.Text = "";
            }
        
    }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
