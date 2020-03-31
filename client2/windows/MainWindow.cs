
using mpp_proiect_1.model;
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
using mpp_proiect_1.utils;
using mpp_proiect_1.services;
using mpp_proiect_1.client;

namespace mpp_proiect_1.windows
{
    public partial class MainWindow : Form
    {
        // private MainController ctr;
        
        private ClientController ctr;
        private  readonly IList<Donator> donatoriL;
        private readonly IList<String> volL;
        private readonly IList<CazCaritabil> cazuriL;

        public MainWindow(ClientController ctr)
        {
            InitializeComponent();
            this.ctr = ctr;

            cazuriL = new List<CazCaritabil>();
            cazuriL = ctr.getCazuri().ToList();
            var list1 = new BindingList<CazCaritabil>(cazuriL);
            dataGridViewCazuri.DataSource = list1;
             donatoriL = new List<Donator>();
             donatoriL = ctr.getDonatori().ToList();
             var list2 = new BindingList<Donator>(donatoriL);
             dataGridViewDonatori.DataSource = list2;
            ctr.updateEvent += userUpdate;
                  }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void userUpdate(object sender, VoluntarEventArgs e)
        {
        
            if (e.UserEventType == VoluntarEvent.UpdatedCaz)
            {
                CazCaritabil caz = (CazCaritabil)e.Data;
                int index = cazuriL.IndexOf(caz);
                cazuriL[index] = caz;
                Console.WriteLine("[Window] caz Updated " + caz);
                dataGridViewCazuri.BeginInvoke(new UpdateDataGridViewCazuri(this.updateGridViewCazuri), 
                    new Object[] { dataGridViewCazuri, cazuriL });
            }
            if (e.UserEventType == VoluntarEvent.NewDonator)
            {
                Donator donator = (Donator)e.Data;
                donatoriL.Add(donator);
                Console.WriteLine("[Window] donator Added" + donator);
                dataGridViewDonatori.BeginInvoke(new UpdateDataGridViewDonatori(this.updateGridViewDonatori), 
                    new Object[] { dataGridViewDonatori, donatoriL});
            }
        }
        private void updateGridViewDonatori(DataGridView dgv, IList<Donator> newData)
        {
            dgv.DataSource = null;
            dgv.DataSource = newData;
        }
        public delegate void UpdateDataGridViewDonatori(DataGridView dgv, IList<Donator> data);
        public delegate void UpdateDataGridViewCazuri(DataGridView dgv, IList<CazCaritabil> data);

        private void updateGridViewCazuri(DataGridView dgv, IList<CazCaritabil> newData)
        {
            dgv.DataSource = null;
            dgv.DataSource = newData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!StringExt.IsNumeric(textBoxNrTelefon.Text) || !StringExt.IsNumeric(textBoxSumaDonatie.Text))
            {
                MessageBox.Show("Nr Telefon / Suma trebuie sa fie un numar!");
                return;
            }
            CazCaritabil currentCaz = (CazCaritabil)dataGridViewCazuri.CurrentRow.DataBoundItem;
            Donator currentDonator = null;
            if (dataGridViewDonatori.CurrentRow != null)
            {
                currentDonator = (Donator)dataGridViewDonatori.CurrentRow.DataBoundItem;
            }
            else
            {
                currentDonator = new Donator(generateDonatorId(), textBoxNume.Text, textBoxAdresa.Text, Int64.Parse(textBoxNrTelefon.Text));

                try { ctr.saveDonator(currentDonator); }
                catch (ValidationException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
           

            int id = generateDonatieId();
            Donatie donatie = new Donatie(id, currentDonator.Id, currentCaz.Id, Double.Parse(textBoxSumaDonatie.Text));
            donatie.Id = id;
            try
            {
                ctr.donatieAdded(donatie);
                Double s = currentCaz.SumaTotala + Double.Parse(textBoxSumaDonatie.Text);
                ctr.updateSumaCaz(new CazCaritabil(currentCaz.Id, currentCaz.Denumire, s));
                MessageBox.Show("Donatia a fost inregistrata! Va multumim!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            
        }
        public int generateDonatorId()
        {
            try { return ctr.getDonatori().ToList().Max(donator => donator.Id) + 1; }
            catch (InvalidOperationException ex)
            {
                return 1;
            }

        }

        public int generateDonatieId()
        {
            try
            {
                return ctr.getDonatii().ToList().Max(donatie => donatie.Id) + 1;
            }
            catch (InvalidOperationException ex)
            {
                return 1;
            }

        }
        private void MainWindow_Shown(Object sender, EventArgs e)
        {

            MessageBox.Show("You are in the Form.Shown event.");
            dataGridViewDonatori.ClearSelection();
        }

        private void textBoxNume_TextChanged(object sender, EventArgs e)
        {
           List<Donator> donators = ctr.getDonatori().ToList().FindAll(d => d.Nume.Equals(textBoxNume.Text));
           dataGridViewDonatori.DataSource = donators;
        }

        private void dataGridViewDonatori_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridViewDonatori_DataBindingComplete(object sender, EventArgs e)
        {
            dataGridViewDonatori.ClearSelection();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            dataGridViewDonatori.ClearSelection();
        }

        private void DataGridViewDonatori_SelectionChanged(object sender, EventArgs e)
        {
           
            Donator currentObject = (Donator)dataGridViewDonatori.CurrentRow.DataBoundItem;
            
            
        }

        private void dataGridViewDonatori_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            Donator currentObject = (Donator)dataGridViewDonatori.CurrentRow.DataBoundItem;
           
            textBoxNume.ResetText();
            textBoxNume.AppendText(currentObject.Nume);
            textBoxAdresa.ResetText();
            textBoxAdresa.AppendText(currentObject.Adresa);
            textBoxNrTelefon.ResetText();
            textBoxNrTelefon.AppendText(currentObject.NrTelefon.ToString());
        }

        private void dataGridViewDonatori_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            Donator currentObject = (Donator)dataGridViewDonatori.CurrentRow.DataBoundItem;
            textBoxNume.ResetText();
            textBoxNume.AppendText(currentObject.Nume);
            textBoxAdresa.ResetText();
            textBoxAdresa.AppendText(currentObject.Adresa);
            textBoxNrTelefon.ResetText();
            textBoxNrTelefon.AppendText(currentObject.NrTelefon.ToString());
        }

        private void dataGridViewDonatori_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            Donator currentObject = (Donator)dataGridViewDonatori.CurrentRow.DataBoundItem;
             textBoxNume.ResetText();
            textBoxNume.AppendText(currentObject.Nume);
            textBoxAdresa.ResetText();
            textBoxAdresa.AppendText(currentObject.Adresa);
            textBoxNrTelefon.ResetText();
            textBoxNrTelefon.AppendText(currentObject.NrTelefon.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           ctr.logout();
            MessageBox.Show("You have successfully logged out!");
            ctr.updateEvent -= userUpdate;
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
