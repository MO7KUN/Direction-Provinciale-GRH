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
    public partial class Gestion_des_personnel : Form
    {
        
        public Gestion_des_personnel()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Globale.connect();
                string query = "SELECT PPR, CIN, Genre, Position, Diplome_scholaire, Diplome_Pro, GSM, Specialite, Adresse, Nom_Latin, Fonction, grade, cadre, Id_etablissement, NomLatin, Adresse FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement and P.PPR LIKE @ppr";
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@ppr", "%" + guna2TextBox1.Text + "%");
                MySqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Load(reader);


                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            
        }

        

        private void Gestion_des_personnel_Load(object sender, EventArgs e)
        {
            try
            {
                Globale.connect();
                guna2HtmlLabel1.Text = "salut " + Globale.getusername() + " c'est le " + DateTime.Now.ToString("dd/MM/yyyy");
                string query = "SELECT PPR, CIN, Genre, Position, Diplome_scholaire, Diplome_Pro, GSM, Specialite, Adresse, Nom_Latin, Fonction, grade, cadre, Id_etablissement, NomLatin, Adresse FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement";
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@ppr", guna2TextBox1.Text);
                MySqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Load(reader);

                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            try
            {
                Globale.connect();
                string query = "UPDATE personnel SET CIN='@cin',Position='@poste',Adresse='@adr',Nom_Latin='@nom',WHERE PPR=@ppr";
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@ppr", guna2TextBox1.Text);
                command.Parameters.AddWithValue("@cin", guna2TextBox2.Text);
                command.Parameters.AddWithValue("@poste", guna2TextBox4.Text);
                command.Parameters.AddWithValue("@adr", guna2TextBox5.Text);
                command.Parameters.AddWithValue("@nom", guna2TextBox3.Text);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Affectués avec succée");

                }
                else
                {
                    MessageBox.Show("Failed to insert data!");
                }
                Globale.connection.Close();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                Globale.connect();
                String query = "DELETE FROM situation WHERE Personne = @ppr";
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@ppr", guna2TextBox1.Text);

                int rowsAffected = command.ExecuteNonQuery();


                if (rowsAffected > 0)
                {
                    query = "DELETE FROM personnel WHERE PPR = @ppr";
                    command = new MySqlCommand(query, Globale.connection);
                    command.Parameters.AddWithValue("@ppr", guna2TextBox1.Text);
                    int a = command.ExecuteNonQuery();

                    if (a > 0)
                    {
                        MessageBox.Show("Supprimée avec succée");

                    }
                    else
                    {
                        MessageBox.Show("Failed to delete data!");
                    }

                }
                else
                {
                    MessageBox.Show("Failed to delete data!");
                }



                Globale.connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
                guna2TextBox1.Clear();
                guna2TextBox2.Clear();
                guna2TextBox3.Clear();
                guna2TextBox4.Clear();
                guna2TextBox5.Clear();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Ajouter_un_personnel aup = new Ajouter_un_personnel();
            aup.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 Form2 = new Form2();
            Form2.Show();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Globale.connect();
                string query = "SELECT PPR, CIN, Genre, Position, Diplome_scholaire, Diplome_Pro, GSM, Specialite, Adresse, Nom_Latin, Fonction, grade, cadre, Id_etablissement, NomLatin, Adresse FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement and P.CIN LIKE @cin";
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@cin", "%" + guna2TextBox2.Text + "%");
                MySqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Load(reader);

                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Globale.connect();
                string query = "SELECT PPR, CIN, Genre, Position, Diplome_scholaire, Diplome_Pro, GSM, Specialite, Adresse, Nom_Latin, Fonction, grade, cadre, Id_etablissement, NomLatin, Adresse FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement and P.Nom_Latin LIKE @nom";
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@nom", "%" + guna2TextBox3.Text + "%");
                MySqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Load(reader);

                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Globale.connect();
                string query = "SELECT PPR, CIN, Genre, Position, Diplome_scholaire, Diplome_Pro, GSM, Specialite, Adresse, Nom_Latin, Fonction, grade, cadre, Id_etablissement, NomLatin, Adresse FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement and P.Position LIKE @poste";
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@poste", "%" + guna2TextBox4.Text + "%");
                MySqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Load(reader);

                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Globale.connect();
                string query = "SELECT PPR, CIN, Genre, Position, Diplome_scholaire, Diplome_Pro, GSM, Specialite, Adresse, Nom_Latin, Fonction, grade, cadre, Id_etablissement, NomLatin, Adresse FROM personnel P, etablissement E, situation S WHERE P.PPR = S.Personne AND E.Id_etablissement = S.Etablissement and P.Adresse LIKE @adr";
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@adr", "%" + guna2TextBox5.Text + "%");
                MySqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Load(reader);

                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
