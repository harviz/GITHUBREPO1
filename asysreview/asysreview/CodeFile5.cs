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
/   CodeFile5.cs
/   printing
/
*/

namespace asysreview
{
    public partial class Form1 : Form
    {
        //global variables

        private void button5_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Font printFont = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            
            int x1 = 70, y1 = 50;
            int tbw1 = 1169, tbh1 = 827;
            int tbh2 = 113;
            
            Pen p = new Pen(Color.Black, 1);

            e.Graphics.DrawLine(p, x1, y1, tbw1 - 20, y1);
            e.Graphics.DrawLine(p, x1, tbh1 - 60, tbw1 - 20, tbh1 - 60);
            e.Graphics.DrawLine(p, x1, y1+358, tbw1 - 20, y1+358);
            
            e.Graphics.DrawLine(p, x1, y1, x1, tbh1 - 60);
            e.Graphics.DrawLine(p, tbw1 - 20, y1, tbw1 - 20, tbh1 - 60);
            e.Graphics.DrawLine(p, x1 + 359, y1, x1 + 359, tbh1 - 60);
            e.Graphics.DrawLine(p, x1 + 359 + 359, y1, x1 + 359 + 359, tbh1 - 60);

            int x2 = x1 + 2, y2 = y1 + 2;
            
            e.Graphics.DrawString("sdfasdfgsdfgsdfgsdfgS", printFont, System.Drawing.Brushes.Black, 2, 5);
            e.Graphics.DrawString("Eil.nr.", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("Gavimo data", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("Vagono1 nr.", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("Asiracio nr.", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("Asies pagaminimo data", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("Paskutinio formavimo data", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("Paskutinio pilno data", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("D Apskritimo diametras", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("K Apskritimo diametras", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("Paridenimo data", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("Vagono2 nr.", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("Asies diamet.per viduri", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("D Ratlankio storis po remonto", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("K Ratlankio storis po remonto", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("D nusidevejimas po remonto", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("K nusidevejimas po remonto", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("revizijos rusis", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("darbuotojas", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("darbuotojas", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("darbuotojas", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("darbuotojas", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("darbuotojas", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("darbuotojas", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            e.Graphics.DrawString("darbuotojas", printFont, System.Drawing.Brushes.Black, x2, y2); y2 = y2 + 10;
            



            /*
            listView1.Columns.Add();
            listView1.Columns.Add();
            listView1.Columns.Add("Vagono1 nr.");
            listView1.Columns.Add();
            listView1.Columns.Add();
            listView1.Columns.Add();
            listView1.Columns.Add();
            listView1.Columns.Add();
            listView1.Columns.Add();
            listView1.Columns.Add();
            listView1.Columns.Add();
            listView1.Columns.Add();
            listView1.Columns.Add();
            listView1.Columns.Add();
            listView1.Columns.Add();
            listView1.Columns.Add();
            listView1.Columns.Add();
            listView1.Columns.Add();
            listView1.Columns.Add("darbuotojas");
            listView1.Columns.Add("darbuotojas");
            listView1.Columns.Add("darbuotojas");
            listView1.Columns.Add("darbuotojas");
            listView1.Columns.Add("darbuotojas");
            listView1.Columns.Add("darbuotojas");
             * */

        }
    }
}

