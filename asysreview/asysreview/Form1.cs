using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace asysreview
{
    public partial class Form1 : Form
    {
        private System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();

        public Form1()
        {
            InitializeComponent();
            Inicialize();

            this.WindowState = FormWindowState.Maximized;

            //MessageBox.Show(Convert.ToString(Screen.PrimaryScreen.WorkingArea.Width));
            //MessageBox.Show(Convert.ToString(this.Width));
            int maxx = Screen.PrimaryScreen.WorkingArea.Width;
            int maxy = Screen.PrimaryScreen.WorkingArea.Height;
            
            tabControl1.Width = maxx - 30;
            tabControl1.Height = maxy - 70;

            listView1.Width = maxx - 80;
            listView1.Height = maxy - 220;

            button5.Left = maxx - 360;
            button5.Top = maxy - 170;

            checkBox3.Left = maxx - 550;
            checkBox3.Top = maxy - 160;            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(1000, 700);
            this.printPreviewDialog1.Location = new System.Drawing.Point(29, 29);
            this.document.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(document_PrintPage);
            //document.DefaultPageSettings.Landscape = false;
            document.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4",1169,827);
            printPreviewDialog1.Document = document;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Pasiruoses !";
            statusStrip1.Refresh();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int maxx = this.Width;
            int maxy = this.Height;

            tabControl1.Width = maxx - 30;
            tabControl1.Height = maxy - 70;

            listView1.Width = maxx - 80;
            listView1.Height = maxy - 280;

            button5.Left = maxx - 375;
            button5.Top = maxy - 190;

            checkBox3.Left = 27;
            checkBox3.Top = 21;

            groupBox2.Left = 27;
            groupBox2.Top = maxy - 220;
            groupBox2.Width = maxx - 80;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox3.Checked)
            {                
                for (int s = 0; s < listView1.Columns.Count; s++)                
                    listView1.Columns[s].Width = -1;                
            }
            else
            {
                for (int s = 0; s < listView1.Columns.Count; s++)                
                    listView1.Columns[s].Width = -2;
            }
        }

        

        
            
    }
}
