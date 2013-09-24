using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using System.Threading;

/*
/   CodeFile0.cs
/   global settings
/
*/

namespace asysreview
{
    public partial class Form1 : Form
    {
        //global variables        
        
        pgDB pgDBase;
        bool logged = false;
        bool port_opened = false;
        bool db_connectivity;
        bool db_use = true;
        private System.Drawing.Printing.PrintDocument document_f32 = new System.Drawing.Printing.PrintDocument();
        private System.Drawing.Printing.PrintDocument document_f49 = new System.Drawing.Printing.PrintDocument();

        //for timers
        private int timer1_blinkFrequency = 800;//1/2 of a second
        private int timer1_maxNumberOfBlinks = 3;
        private int timer1_blinkCount = 0;
        private Color color1;
        private Color color2;
        private SystemColors systemcolor1;
        private SystemColors systemcolor2;


        //methods
        private void Inicialize()
        {
            
            pgDBase = new pgDB();
            if (db_use)
            {
                if (pgDBase.check_connectivity())
                {
                    db_connectivity = true;
                }
                else
                {
                    db_connectivity = false;
                }
            }            

            this.Location = new Point(0, 0);
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //resize_all_panels("panel3");
            /*
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(1000, 700);
            this.printPreviewDialog1.Location = new System.Drawing.Point(29, 29);
            this.document_f32.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(document_f32_PrintPage);
            document_f32.DefaultPageSettings.Landscape = true;
            //document_f32.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 826, 1169);
            //document_f32.DefaultPageSettings.PaperSize.Kind = kind;
            printPreviewDialog1.Document = document_f32;

            this.printPreviewDialog2.ClientSize = new System.Drawing.Size(1000, 700);
            this.printPreviewDialog2.Location = new System.Drawing.Point(29, 29);
            this.document_f49.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(document_f49_PrintPage);
            document_f49.DefaultPageSettings.Landscape = true;            
            printPreviewDialog2.Document = document_f49;
             * */
        }

        private void SetDefaults()
        {
            
        }

        private void LoadValues()
        {
        
        }
        

        

        

        private void hide_all_panels(string asd)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel && c.Name != asd)
                {
                    c.Hide();
                }
            }
        }

        private void hide_all_panels()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel)
                {
                    c.Hide();
                }
            }
        }

        private void hide_all_panels(string asd, string das)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel && c.Name != asd && c.Name != das)
                {
                    c.Hide();
                }
            }
        }

        private void resize_all_panels(string asd)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel && c.Name != asd)
                {
                    c.Location = new Point(0, 48);
                    c.Size = new Size(this.ClientSize.Width ,this.ClientSize.Height - 70);
                }
            }
        }

    }
}