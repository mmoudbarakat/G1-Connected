﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G1_Connected
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlDataReader dReader;
            if(listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
            }
            sqlCommand1.CommandText = "Select Id, Name From Department";
            sqlConnection1.Open();
            dReader = sqlCommand1.ExecuteReader();
            while(dReader.Read())
            {
                string str = ((int)dReader[0]).ToString() + "\t" + dReader[1].ToString();
                listBox1.Items.Add(str);
            }
            dReader.Close();
            sqlConnection1.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string str = "Insert Into Department Values(" + textBox1.Text + ", '" + textBox2.Text + "')";
            //MessageBox.Show(str);
            sqlCommand1.CommandText = str;
            sqlConnection1.Open();
            int affectedRows = sqlCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            MessageBox.Show(affectedRows.ToString() + " Rows affected");
            textBox1.Text = textBox2.Text = "";
        }
    }
}
