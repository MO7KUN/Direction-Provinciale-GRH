using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
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
    public partial class Ajouter_un_personnel : Form
    {
        public Ajouter_un_personnel()
        {
            InitializeComponent();
        }

        

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
            guna2TextBox4.Clear();
            guna2TextBox6.Clear();
            guna2TextBox7.Clear();
            guna2TextBox8.Clear();
            guna2TextBox9.Clear();
            guna2TextBox10.Clear();
            guna2TextBox11.Clear();
            guna2TextBox12.Clear();
            guna2ComboBox2.SelectedIndex = -1;
            guna2ComboBox3.SelectedIndex = -1;
            guna2ComboBox4.SelectedIndex = -1;
            guna2ComboBox5.SelectedIndex = -1;

        }

        private void Ajouter_un_personnel_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Text = "salut " + Globale.getusername() + " c'est le " + DateTime.Now.ToString("dd/MM/yyyy");


            try
            {
                Globale.connect();
                string query = "SELECT ID_Grade, Libelle_Grade FROM grade";
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                MySqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Load(reader);
                guna2ComboBox3.DisplayMember = "Libelle_Grade";
                guna2ComboBox3.ValueMember = "ID_Grade";

                guna2ComboBox3.DataSource = dataTable;



                query = "SELECT ID_Fonction, Libelle_Fonction FROM fonction";
                command = new MySqlCommand(query, Globale.connection);
                reader = command.ExecuteReader();

                dataTable = new DataTable();

                dataTable.Load(reader);
                guna2ComboBox4.DisplayMember = "Libelle_Fonction";
                guna2ComboBox4.ValueMember = "ID_Fonction";

                guna2ComboBox4.DataSource = dataTable;




                query = "SELECT ID_Cadre, Libelle_Cadre FROM cadre";
                command = new MySqlCommand(query, Globale.connection);
                reader = command.ExecuteReader();

                dataTable = new DataTable();

                dataTable.Load(reader);
                guna2ComboBox2.DisplayMember = "Libelle_Cadre";
                guna2ComboBox2.ValueMember = "ID_Cadre";

                guna2ComboBox2.DataSource = dataTable;




                query = "SELECT Id_etablissement, NomLatin FROM etablissement";
                command = new MySqlCommand(query, Globale.connection);
                reader = command.ExecuteReader();

                dataTable = new DataTable();

                dataTable.Load(reader);
                guna2ComboBox5.DisplayMember = "NomLatin";
                guna2ComboBox5.ValueMember = "Id_etablissement";

                guna2ComboBox5.DataSource = dataTable;



                Globale.connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DateTime date_naiss = guna2DateTimePicker1.Value;
            DateTime date_rec = guna2DateTimePicker2.Value;
            DateTime date_affict = guna2DateTimePicker3.Value;


            string F_date_niass = date_naiss.ToString("yyyy/MM/dd");
            string F_date_rec = date_rec.ToString("yyyy/MM/dd");
            string F_date_affict = date_affict.ToString("yyyy/MM/dd");


            try
            {
                Globale.connect();
                string query = "INSERT INTO personnel VALUES (@ppr, @cin, @genre, @poste, @datenaiss, @DipScho, @DipPro, @GSM, @apecial, @adr, @lnaiss, @nom, @fonc, @grade, @cadre)";
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@ppr", guna2TextBox1.Text);
                command.Parameters.AddWithValue("@cin", guna2TextBox2.Text);
                command.Parameters.AddWithValue("@genre", guna2TextBox3.Text);
                command.Parameters.AddWithValue("@poste", guna2TextBox4.Text);
                command.Parameters.AddWithValue("@adr", guna2TextBox12.Text);
                command.Parameters.AddWithValue("@nom", guna2TextBox9.Text);
                command.Parameters.AddWithValue("@DipScho", guna2TextBox7.Text);
                command.Parameters.AddWithValue("@DipPro", guna2TextBox6.Text);
                command.Parameters.AddWithValue("@GSM", guna2TextBox8.Text);
                command.Parameters.AddWithValue("@apecial", guna2TextBox11.Text);
                command.Parameters.AddWithValue("@lnaiss", guna2TextBox10.Text);
                command.Parameters.AddWithValue("@fonc", guna2ComboBox4.SelectedValue);
                command.Parameters.AddWithValue("@grade", guna2ComboBox3.SelectedValue);
                command.Parameters.AddWithValue("@cadre", guna2ComboBox2.SelectedValue);
                command.Parameters.AddWithValue("@datenaiss", F_date_niass);

                int rowsAffected = command.ExecuteNonQuery();


                query = "INSERT INTO situation VALUES(@ppr,@etab,@datrec,@dataff)";
                command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@ppr", guna2TextBox1.Text);
                command.Parameters.AddWithValue("@etab", guna2ComboBox5.SelectedValue);
                command.Parameters.AddWithValue("@datrec", F_date_rec);
                command.Parameters.AddWithValue("@dataff", F_date_affict);


                int rowsnbr = command.ExecuteNonQuery();



                if (rowsAffected > 0 && rowsnbr > 0)
                {
                    MessageBox.Show("Affectués avec succée");

                }
                else
                {
                    MessageBox.Show("Failed to insert data!");
                }
                Globale.connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
