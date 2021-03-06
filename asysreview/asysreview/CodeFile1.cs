﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

/*
 * 
 *      paieska pagal eiles numeri
 * 
 * */


namespace asysreview
{
    public partial class Form1 : Form
    {
        
        private void button1_Click(object sender, EventArgs e)
        {
            bool rezult = false;

            listView1.Clear();
            pgDBase.db_query = "SELECT count(*) FROM tbl1 WHERE col_1 = true and col_5 = '" + textBox1.Text + "';";
            if (pgDBase.db_select(2))
            {
                if (Convert.ToInt32(pgDBase.db_result) > 0)
                {
                    int count1 = Convert.ToInt32(pgDBase.db_result);
                    pgDBase.db_query = "SELECT id, col_5, col_6"
                                        + ", col_7, col_9, col_10"
                                        + ", col_11, col_12, col_13"
                                        + ", col_14, col_15, col_16"
                                        + ", col_25, col_26, col_27"
                                        + ", col_28, col_29, col_42"
                                        + ", col_45, col_46, col_47"
                                        + ", col_48, col_49, col_50"
                                        + ", col_51"
                                        + " FROM tbl1 WHERE col_1 = true and col_5 = '"
                                        + textBox1.Text + "' order by col_5 desc;";
                    
                    pgDBase.db_tab_1 = new DataTable();
                    pgDBase.db_tab_1.Columns.Add("id", typeof(int));
                    pgDBase.db_tab_1.Columns.Add("col_5", typeof(int));
                    pgDBase.db_tab_1.Columns.Add("col_6", typeof(DateTime));
                    pgDBase.db_tab_1.Columns.Add("col_7", typeof(string));
                    pgDBase.db_tab_1.Columns.Add("col_9", typeof(int));
                    pgDBase.db_tab_1.Columns.Add("col_10", typeof(string));
                    pgDBase.db_tab_1.Columns.Add("col_11", typeof(string));
                    pgDBase.db_tab_1.Columns.Add("col_12", typeof(string));
                    pgDBase.db_tab_1.Columns.Add("col_13", typeof(int));
                    pgDBase.db_tab_1.Columns.Add("col_14", typeof(int));
                    pgDBase.db_tab_1.Columns.Add("col_15", typeof(DateTime));
                    pgDBase.db_tab_1.Columns.Add("col_16", typeof(string));
                    pgDBase.db_tab_1.Columns.Add("col_25", typeof(string));
                    pgDBase.db_tab_1.Columns.Add("col_26", typeof(string));
                    pgDBase.db_tab_1.Columns.Add("col_27", typeof(string));
                    pgDBase.db_tab_1.Columns.Add("col_28", typeof(string));
                    pgDBase.db_tab_1.Columns.Add("col_29", typeof(string));
                    pgDBase.db_tab_1.Columns.Add("col_42", typeof(string));
                    pgDBase.db_tab_1.Columns.Add("col_45", typeof(int));
                    pgDBase.db_tab_1.Columns.Add("col_46", typeof(int));
                    pgDBase.db_tab_1.Columns.Add("col_47", typeof(int));
                    pgDBase.db_tab_1.Columns.Add("col_48", typeof(int));
                    pgDBase.db_tab_1.Columns.Add("col_49", typeof(int));
                    pgDBase.db_tab_1.Columns.Add("col_50", typeof(int));
                    pgDBase.db_tab_1.Columns.Add("col_51", typeof(int));


                    if (pgDBase.db_select_1(ref pgDBase.db_tab_1, count1, 25))
                    {
                        listView1.Clear();
                        listView1.Columns.Add("Eil.nr.");
                        listView1.Columns.Add("Gavimo data");
                        listView1.Columns.Add("Vagono1 nr.");
                        listView1.Columns.Add("Asiracio nr.");
                        listView1.Columns.Add("Asies pagaminimo data");
                        listView1.Columns.Add("Paskutinio formavimo data");
                        listView1.Columns.Add("Paskutinio pilno data");
                        listView1.Columns.Add("D Apskritimo diametras");
                        listView1.Columns.Add("K Apskritimo diametras");
                        listView1.Columns.Add("Paridenimo data");
                        listView1.Columns.Add("Vagono2 nr.");
                        listView1.Columns.Add("Asies diamet.per viduri");
                        listView1.Columns.Add("D Ratlankio storis po remonto");
                        listView1.Columns.Add("K Ratlankio storis po remonto");
                        listView1.Columns.Add("D nusidevejimas po remonto");
                        listView1.Columns.Add("K nusidevejimas po remonto");
                        listView1.Columns.Add("revizijos rusis");
                        listView1.Columns.Add("darbuotojas");
                        listView1.Columns.Add("darbuotojas");
                        listView1.Columns.Add("darbuotojas");
                        listView1.Columns.Add("darbuotojas");
                        listView1.Columns.Add("darbuotojas");
                        listView1.Columns.Add("darbuotojas");
                        listView1.Columns.Add("darbuotojas");

                        // listo sudarymas                                        
                        for (int i = 0; i < pgDBase.db_tab_1.Rows.Count; i++)      // reads fields
                        {
                            DataRow drow = pgDBase.db_tab_1.Rows[i];
                            if (drow.RowState != DataRowState.Deleted)
                            {                                
                                ListViewItem lvi = new ListViewItem(drow["col_5"].ToString());                                
                                lvi.SubItems.Add(drow["col_6"].ToString().Substring(0,10));                                
                                lvi.SubItems.Add(drow["col_7"].ToString());                                
                                lvi.SubItems.Add(drow["col_9"].ToString());                                
                                lvi.SubItems.Add(drow["col_10"].ToString());                                
                                lvi.SubItems.Add(drow["col_11"].ToString());                                
                                lvi.SubItems.Add(drow["col_12"].ToString());                                
                                lvi.SubItems.Add(drow["col_13"].ToString());                                
                                lvi.SubItems.Add(drow["col_14"].ToString());                                
                                lvi.SubItems.Add(drow["col_15"].ToString().Substring(0, 10));                                
                                lvi.SubItems.Add(drow["col_16"].ToString());                                
                                lvi.SubItems.Add(drow["col_25"].ToString());                                
                                lvi.SubItems.Add(drow["col_26"].ToString());                                
                                lvi.SubItems.Add(drow["col_27"].ToString());                                
                                lvi.SubItems.Add(drow["col_28"].ToString());                                
                                lvi.SubItems.Add(drow["col_29"].ToString());                                
                                lvi.SubItems.Add(drow["col_42"].ToString());                               
                                lvi.SubItems.Add(drow["col_45"].ToString());                                
                                lvi.SubItems.Add(drow["col_46"].ToString());                                
                                lvi.SubItems.Add(drow["col_47"].ToString());                               
                                lvi.SubItems.Add(drow["col_48"].ToString());                                
                                lvi.SubItems.Add(drow["col_49"].ToString());                                
                                lvi.SubItems.Add(drow["col_50"].ToString());                                
                                lvi.SubItems.Add(drow["col_51"].ToString());                                


                                //listView1.ForeColor = Color.Red;                                
                                // Add the list items to the ListView
                                
                                listView1.Items.Add(lvi);
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
                                /*for(int n = 0; n < 24;n++)
                                    listView1.Columns[n].Width = -1;*/
                            }
                        }
                        rezult = true;
                    }
                    else
                    {
                        MessageBox.Show("SELECT id, col_5, col_6 FROM tbl1 nepavyko !!!");
                    }
                }
                else if (Convert.ToInt32(pgDBase.db_result) == 0)
                {
                    toolStripStatusLabel1.Text = "Nera tokio eiles numerio !!!";                    
                    //statusStrip1.Refresh();
                    //MessageBox.Show("Nera tokio eiles numerio !!!");
                }
            }
            else
            {
                MessageBox.Show("SELECT count(*) nepavyko !!!");
            }
                        
            if (rezult)
            {
                tabControl1.SelectTab(4);
            }
            else
            {}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

    }
}