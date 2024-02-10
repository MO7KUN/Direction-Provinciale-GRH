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
using System.Web.Security;
using System.Windows.Forms;

namespace Direction_Provinciale_GRH
{
    public partial class Gestion_des_etablissement : Form
    {
        string role = Globale.getrole();
        public Gestion_des_etablissement()
        {
            InitializeComponent();
        }

        private void Gestion_des_etablissement_Load(object sender, EventArgs e)
        {
            try
            {
                guna2HtmlLabel1.Text = "salut " + Globale.getusername() + " c'est le " + DateTime.Now.ToString("dd/MM/yyyy");
                Globale.connect();
                string query = "";
                MySqlCommand command;
                MySqlDataReader reader;


                query = "SELECT * FROM etablissement";






                command = new MySqlCommand(query, Globale.connection);
                reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();

                dataTable.Load(reader);

                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (role == "admin")
                {
                    Globale.connect();
                    string query = "INSERT INTO etablissement values(@id,@nom,@adr)";
                    MySqlCommand command = new MySqlCommand(query, Globale.connection);
                    command.Parameters.AddWithValue("@id", guna2TextBox1.Text);
                    command.Parameters.AddWithValue("@nom", guna2TextBox2.Text);
                    command.Parameters.AddWithValue("@adr", guna2TextBox3.Text);

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
                else
                {
                    MessageBox.Show("Vou ne pouvez pas ajouter une établissement !!");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Globale.connect();
                string query = "UPDATE etablissement SET NomLatin = @nom, AdresseEtab = @adr WHERE Id_etablissement = @id";
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@id", guna2TextBox1.Text);
                command.Parameters.AddWithValue("@nom", guna2TextBox2.Text);
                command.Parameters.AddWithValue("@adr", guna2TextBox3.Text);
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
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Globale.connect();
                string query = "";
                MySqlCommand command;
                MySqlDataReader reader;
                string role = Globale.getrole();


                query = "SELECT * FROM etablissement WHERE Id_etablissement LIKE @id";





                command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@id", "%" + guna2TextBox1.Text + "%");
                reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();

                dataTable.Load(reader);

                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int selectedRowIndex = guna2DataGridView1.SelectedCells[0].RowIndex;


            
            DataGridViewRow selectedRow = guna2DataGridView1.Rows[selectedRowIndex];

            
            string idetab = selectedRow.Cells["Id_etablissement"].Value.ToString();
            string nometab = selectedRow.Cells["NomLatin"].Value.ToString();
            string adretab = selectedRow.Cells["Adresse"].Value.ToString();

            guna2TextBox1.Text = idetab;
            guna2TextBox2.Text = nometab;
            guna2TextBox3.Text = adretab;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Globale.connect();
                string query = "";
                MySqlCommand command;
                MySqlDataReader reader;
                string role = Globale.getrole();

                query = "SELECT * FROM etablissement WHERE NomLatin LIKE @id";





                command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@id", "%" + guna2TextBox2.Text + "%");
                reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();

                dataTable.Load(reader);

                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Globale.connect();
                string query = "";
                MySqlCommand command;
                MySqlDataReader reader;
                string role = Globale.getrole();

                query = "SELECT * FROM etablissement WHERE AdresseEtab LIKE @id";





                command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@id", "%" + guna2TextBox3.Text + "%");
                reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();

                dataTable.Load(reader);

                guna2DataGridView1.DataSource = dataTable;
                Globale.connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            this.Close();
            Form2.Show();
        }
    }
}
