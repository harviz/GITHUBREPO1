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
    class pgDB
    {
        //variables
        private string db_password = "87654321";
        private string db_port = "Port=5432";
        private string db_connection_string;
        private NpgsqlConnection db_conn;
        public string db_query;
        private NpgsqlCommand db_command;
        private int db_rowsaffected;
        private NpgsqlDataReader db_datareader;
        public string db_result;

        // ARRAYS
        // one dimentional        
        //public int[] db_array_i_1_01, db_array_i_1_02, db_array_i_1_03, db_array_i_1_04, db_array_i_1_05, db_array_i_1_06;        

        // two dimentional
        public int[,] db_array_int_1;

        // other arrays
        public Array[] db_array1;

        // DATASETS, DATATABLES
        public DataTable db_tab_1;

        //methods
        public pgDB()
        {
            db_connection_string = "Server=127.0.0.1;" + this.db_port + ";User Id=postgres;Password=" + this.db_password + ";Database=asys;";
            db_conn = new NpgsqlConnection(db_connection_string);
            db_query = "";
            db_rowsaffected = 0;
            db_result = "";
            //db_array_int_1 = new int[0,0];
        }

        public bool check_connectivity()
        {
            bool result = true;
            try
            {                
                db_conn.Open();
                db_conn.Close();
                result = true;
                //MessageBox.Show(Convert.ToString(result));
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                //this.eventer(e.Message);
                result = false;
                //MessageBox.Show(Convert.ToString(result));
            }
            return result;
            //return true;
        }

        public bool db_insert()
        {
            db_rowsaffected = 0;
            if (db_query != "")
            {
                db_conn.Open();
                db_command = new NpgsqlCommand(db_query, db_conn);
                try
                {
                    db_rowsaffected = db_command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    //this.eventer(e.Message);
                    MessageBox.Show(e.Message);
                    return false;
                }
                db_conn.Close();
                return true;
            }
            else
                return false;
        }

        public bool db_update()
        {
            db_rowsaffected = 0;
            if (db_query != "")
            {
                db_conn.Open();
                db_command = new NpgsqlCommand(db_query, db_conn);
                try
                {
                    db_rowsaffected = db_command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    //this.eventer(e.Message);
                    MessageBox.Show(e.Message);
                    return false;
                }
                db_conn.Close();
                return true;
            }
            else
                return false;            
        }

        public bool db_select(int resultkind)
        {
            int var1 = 0;
            db_array_int_1 = new int[0,0];
            Array.Clear(db_array_int_1, 0, db_array_int_1.Length);

            if (db_query != "")
            {
                if (resultkind == 1)
                {
                    db_conn.Open();
                    db_command = new NpgsqlCommand(db_query, db_conn);
                    try
                    {
                        db_datareader = db_command.ExecuteReader();
                        while (db_datareader.Read())                                // reads rows
                        {
                            for (int i = 0; i < db_datareader.FieldCount; i++)      // reads fields
                            {
                                db_array_int_1[var1,i] = Convert.ToInt32(db_datareader[i]);
                            }
                            var1++;
                        }
                    }
                    catch (Exception e)
                    {
                        //this.eventer(e.Message);
                        MessageBox.Show(e.Message);
                        db_conn.Close();
                        return false;
                    }
                    db_conn.Close();
                    return true;
                }
                else if (resultkind == 2)
                {
                    db_conn.Open();
                    db_command = new NpgsqlCommand(db_query, db_conn);
                    try
                    {
                        db_datareader = db_command.ExecuteReader();
                        while (db_datareader.Read())
                        {
                            for (int i = 0; i < db_datareader.FieldCount; i++)
                            {
                                db_result = Convert.ToString(db_datareader[i]);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        //this.eventer(e.Message);
                        MessageBox.Show(e.Message);
                        db_conn.Close();
                        return false;
                    }
                    db_conn.Close();
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool db_select(int array1, int rows, int cols)
        {
            int var1 = 0;
            try
            {
                Array.Clear(db_array_int_1, 0, db_array_int_1.Length);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            if (db_query != "")
            {
                db_conn.Open();
                db_command = new NpgsqlCommand(db_query, db_conn);
                try
                {
                    db_datareader = db_command.ExecuteReader();                    
                    db_array_int_1 = new int[rows, db_datareader.FieldCount];
                    while (db_datareader.Read())                                // reads rows
                    {
                        for (int i = 0; i < db_datareader.FieldCount; i++)      // reads fields
                        {
                            db_array_int_1[var1,i] = Convert.ToInt32(db_datareader[i]);
                        }
                        var1++;
                    }
                }
                catch (Exception e)
                {
                    //this.eventer(e.Message);
                    MessageBox.Show(e.Message);
                    db_conn.Close();
                    return false;
                }
                db_conn.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool db_select_1 (ref DataTable tab_1, int rows, int cols)
        {
            int var1 = 0;
            object[] array = new object[cols];

            if (db_query != "")
            {
                db_conn.Open();
                db_command = new NpgsqlCommand(db_query, db_conn);
                try
                {
                    db_datareader = db_command.ExecuteReader();
                    //db_array_int_1 = new int[rows, db_datareader.FieldCount];
                    while (db_datareader.Read())                                // reads rows
                    {
                        for (int i = 0; i < db_datareader.FieldCount; i++)      // reads fields
                        {
                            array[i] = db_datareader[i];                            
                        }
                        tab_1.Rows.Add(array);
                        var1++;
                    }
                }
                catch (Exception e)
                {
                    //this.eventer(e.Message);
                    MessageBox.Show(e.Message);
                    db_conn.Close();
                    return false;
                }
                db_conn.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool db_array_clear (string array1, int cols, string col_type)
        {
            if (col_type.Length < 20)
            {
                for (int i = 0; i < cols; i++)
                {

                }
            }
            return true;
        }

        public bool db_select_10(ref DataTable tab_1, int rows, int cols)
        {


            return true;
        }

    }
}
