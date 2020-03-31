
using mpp_proiect_1.client;
using mpp_proiect_1.model;
using mpp_proiect_1.repository;
using mpp_proiect_1.services;
using mpp_proiect_1.validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mpp_proiect_1.windows
{
    public partial class LogInWindow : Form
    {
        //private LogInController ctr;
        // private VoluntarService voluntarService;
        private ClientController ctr;
        public LogInWindow(ClientController ctr)
        {
            InitializeComponent();
            this.ctr = ctr ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            String parola = textBox3.Text;

            try
            {
                ctr.login(textBox2.Text,parola);
                MessageBox.Show("Login succeded!");

               
                 MainWindow chatWin = new MainWindow(ctr);
                
                chatWin.Text = "window for " + textBox2.Text;
                chatWin.Show();
                this.Hide();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Login Error " + ex.Message/*+ex.StackTrace*/, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
