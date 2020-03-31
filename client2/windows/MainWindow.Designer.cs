using System;

namespace mpp_proiect_1.windows
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewCazuri = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewDonatori = new System.Windows.Forms.DataGridView();
            this.textBoxNume = new System.Windows.Forms.TextBox();
            this.textBoxAdresa = new System.Windows.Forms.TextBox();
            this.textBoxNrTelefon = new System.Windows.Forms.TextBox();
            this.textBoxSumaDonatie = new System.Windows.Forms.TextBox();
            this.LogOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCazuri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDonatori)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCazuri
            // 
            this.dataGridViewCazuri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCazuri.Location = new System.Drawing.Point(1, 1);
            this.dataGridViewCazuri.MultiSelect = false;
            this.dataGridViewCazuri.Name = "dataGridViewCazuri";
            this.dataGridViewCazuri.ReadOnly = true;
            this.dataGridViewCazuri.RowTemplate.Height = 24;
            this.dataGridViewCazuri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCazuri.Size = new System.Drawing.Size(618, 238);
            this.dataGridViewCazuri.TabIndex = 0;
            this.dataGridViewCazuri.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(285, 477);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Adauga Donatie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewDonatori
            // 
            this.dataGridViewDonatori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDonatori.Location = new System.Drawing.Point(477, 278);
            this.dataGridViewDonatori.Name = "dataGridViewDonatori";
            this.dataGridViewDonatori.ReadOnly = true;
            this.dataGridViewDonatori.RowTemplate.Height = 24;
            this.dataGridViewDonatori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewDonatori.Size = new System.Drawing.Size(539, 239);
            this.dataGridViewDonatori.TabIndex = 2;
            this.dataGridViewDonatori.TabStop = false;
            this.dataGridViewDonatori.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDonatori_CellClick);
            this.dataGridViewDonatori.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDonatori_CellContentClick_1);
            this.dataGridViewDonatori.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewDonatori_CellMouseClick);
            // 
            // textBoxNume
            // 
            this.textBoxNume.Location = new System.Drawing.Point(328, 278);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.Size = new System.Drawing.Size(100, 22);
            this.textBoxNume.TabIndex = 3;
            this.textBoxNume.TextChanged += new System.EventHandler(this.textBoxNume_TextChanged);
            // 
            // textBoxAdresa
            // 
            this.textBoxAdresa.Location = new System.Drawing.Point(328, 320);
            this.textBoxAdresa.Name = "textBoxAdresa";
            this.textBoxAdresa.Size = new System.Drawing.Size(100, 22);
            this.textBoxAdresa.TabIndex = 4;
            // 
            // textBoxNrTelefon
            // 
            this.textBoxNrTelefon.Location = new System.Drawing.Point(328, 371);
            this.textBoxNrTelefon.Name = "textBoxNrTelefon";
            this.textBoxNrTelefon.Size = new System.Drawing.Size(100, 22);
            this.textBoxNrTelefon.TabIndex = 5;
            // 
            // textBoxSumaDonatie
            // 
            this.textBoxSumaDonatie.Location = new System.Drawing.Point(328, 428);
            this.textBoxSumaDonatie.Name = "textBoxSumaDonatie";
            this.textBoxSumaDonatie.Size = new System.Drawing.Size(100, 22);
            this.textBoxSumaDonatie.TabIndex = 6;
            // 
            // LogOut
            // 
            this.LogOut.Location = new System.Drawing.Point(746, 97);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(134, 64);
            this.LogOut.TabIndex = 7;
            this.LogOut.Text = "LogOut";
            this.LogOut.UseVisualStyleBackColor = true;
            this.LogOut.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(252, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nume";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(252, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Adresa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(228, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "NrTelefon";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(199, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Suma Donata";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 516);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogOut);
            this.Controls.Add(this.textBoxSumaDonatie);
            this.Controls.Add(this.textBoxNrTelefon);
            this.Controls.Add(this.textBoxAdresa);
            this.Controls.Add(this.textBoxNume);
            this.Controls.Add(this.dataGridViewDonatori);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewCazuri);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCazuri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDonatori)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
       

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCazuri;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewDonatori;
        
        private System.Windows.Forms.TextBox textBoxNume;
        private System.Windows.Forms.TextBox textBoxAdresa;
        private System.Windows.Forms.TextBox textBoxNrTelefon;
        private System.Windows.Forms.TextBox textBoxSumaDonatie;
        private System.Windows.Forms.Button LogOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}