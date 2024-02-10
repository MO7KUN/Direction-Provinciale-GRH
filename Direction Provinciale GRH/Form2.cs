using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Direction_Provinciale_GRH
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            this.Close();
            Form1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Text = "salut " + Globale.getusername() + " c'est le " + DateTime.Now.ToString("dd/MM/yyyy");
            guna2HtmlLabel2.Text = "";
            string role = Globale.getrole();
            switch (role) 
            {
                case "directeur":
                    guna2Button4.Enabled = false;
                    break;
                case "consulteur":
                    guna2Button2.Enabled = false;
                    guna2Button5.Enabled = false;
                    guna2Button4.Enabled = false;
                    break;
                case "Archive":
                    guna2Button5.Enabled = false;
                    guna2Button4.Enabled = false;
                    break;
                case "admin":
                    break;
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Gestion_des_etablissement gde = new Gestion_des_etablissement();
            gde.Show();
        }

        private void guna2Button1_MouseHover(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Text = "Consulter les personnel sans modification";
        }

        private void guna2Button2_MouseHover(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Text = "Modifier les informations des personnels";
        }

        private void guna2Button4_MouseHover(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Text = "Gérer les rôles des comptes";
        }

        private void guna2Button5_MouseHover(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Text = "Modifier les informations des établissement";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Consultation consul = new Consultation();
            consul.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Gestion_des_personnel gdp = new Gestion_des_personnel();
            this.Close();
            gdp.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Gestion_des_rôles gdr = new Gestion_des_rôles();
            this.Close();
            gdr.Show();
        }

        private void Form2_MouseHover(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Text = "";
        }
    }
}
