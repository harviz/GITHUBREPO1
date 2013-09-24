using System;
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
 *      paieska pagal datos intervala
 * 
 * */


namespace asysreview
{
    public partial class Form1 : Form
    {



        private void button4_Click(object sender, EventArgs e)
        {
            bool rezult = false;
            string query1 = "", query2 = "";

            listView1.Clear();

            if (radioButton1.Checked & !radioButton2.Checked)
            {
                query1 = "SELECT count(*) FROM tbl1 WHERE col_1 = true and col_6 >= '" + dateTimePicker1.Text + "' and col_6 <= '" + dateTimePicker2.Text + "';";
                query2 = "SELECT id, col_5, col_6 FROM tbl1 WHERE col_1 = true and col_6 >= '" + dateTimePicker1.Text + "' and col_6 <= '" + dateTimePicker2.Text + "';";
                textBox4.Text = dateTimePicker1.Text;
                textBox5.Text = dateTimePicker2.Text;
            }
            if (!radioButton1.Checked & radioButton2.Checked)
            {
                query1 = "SELECT count(*) FROM tbl1 WHERE col_1 = true and col_15 >= '" + dateTimePicker1.Text + "' and col_15 <= '" + dateTimePicker2.Text + "';";
                query2 = "SELECT id, col_5, col_6 FROM tbl1 WHERE col_1 = true and col_15 >= '" + dateTimePicker1.Text + "' and col_15 <= '" + dateTimePicker2.Text + "' order by col_5 desc;";
                textBox4.Text = dateTimePicker1.Text;
                textBox5.Text = dateTimePicker2.Text;
            }


            if (dateTimePicker1.Value > dateTimePicker2.Value)
                MessageBox.Show(Convert.ToString(dateTimePicker1.Text) + " > " + Convert.ToString(dateTimePicker2.Text));
            else
            {

                
                pgDBase.db_query = query1;
                if (pgDBase.db_select(2))
                {
                    if (Convert.ToInt32(pgDBase.db_result) > 0)
                    {
                        MessageBox.Show(Convert.ToString(pgDBase.db_result));
                        //textBox4.Text = query1;
                        int count1 = Convert.ToInt32(pgDBase.db_result);
                        pgDBase.db_query = query2;

                        pgDBase.db_tab_1 = new DataTable();
                        pgDBase.db_tab_1.Columns.Add("id", typeof(int));
                        pgDBase.db_tab_1.Columns.Add("numeris", typeof(int));
                        pgDBase.db_tab_1.Columns.Add("data", typeof(DateTime));

                        if (pgDBase.db_select_1(ref pgDBase.db_tab_1, count1, 3))
                        {
                            listView1.Clear();
                            listView1.Columns.Add("Eil.nr.");
                            listView1.Columns.Add("Data");
                            // listo sudarymas                                        
                            for (int i = 0; i < pgDBase.db_tab_1.Rows.Count; i++)      // reads rows
                            {
                                DataRow drow = pgDBase.db_tab_1.Rows[i];
                                if (drow.RowState != DataRowState.Deleted)
                                {
                                
                                    ListViewItem lvi = new ListViewItem(drow["numeris"].ToString());
                                    lvi.SubItems.Add(drow["data"].ToString());
                                    // Add the list items to the ListView
                                
                                    listView1.Items.Add(lvi);
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
                        MessageBox.Show("Nera tokio eiles numerio !!!");
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
                {

                }
                

            }

        }

    }
}