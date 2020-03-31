using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mpp_proiect_1.repository;

namespace mpp_proiect_1
{
    public partial class Form1 : Form
    {
        
        DonatorDbRepository repo = new DonatorDbRepository();
        public Form1()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "idD";
            dataGridView1.Columns[1].Name = "Nume";
            dataGridView1.Columns[2].Name = "Adresa";
            dataGridView1.Columns[3].Name = "NrTelefon";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillData();
          

        }

        private void FillData()
        {
            dataGridView1.Rows.Add(repo.findOne(1).Id,repo.findOne(1).Nume,repo.findOne(1).Adresa);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
