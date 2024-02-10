using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Direction_Provinciale_GRH
{
    public partial class Gestion_des_rôles : Form
    {
        static public string a;
        public Gestion_des_rôles()
        {
            InitializeComponent();
        }



        private void Gestion_des_rôles_Load(object sender, EventArgs e)
        {
            try
            {

                guna2HtmlLabel1.Text = "salut " + Globale.getusername() + " c'est le " + DateTime.Now.ToString("dd/MM/yyyy");
                Globale.connect();
                string query = "SELECT username, role FROM compte";
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2CustomRadioButton1.Checked)
                {
                    a = "consulteur";
                }
                else if (guna2CustomRadioButton2.Checked)
                {
                    a = "admin";
                }
                else if (guna2CustomRadioButton3.Checked)
                {
                    a = "directeur";
                }
                else if (guna2CustomRadioButton4.Checked)
                {
                    a = "Archive";
                }
                Globale.connect();
                string query = "UPDATE compte SET role = @role WHERE username = @user";
                MySqlCommand command = new MySqlCommand(query, Globale.connection);
                command.Parameters.AddWithValue("@user", guna2TextBox1.Text);
                command.Parameters.AddWithValue("@role", a);
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            Globale.connect();
            string query = "SELECT username, role FROM compte WHERE username LIKE @user";
            MySqlCommand command = new MySqlCommand(query, Globale.connection);
            command.Parameters.AddWithValue("@user", "%" + guna2TextBox1.Text + "%");

            MySqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();

            dataTable.Load(reader);

            guna2DataGridView1.DataSource = dataTable;
            Globale.connection.Close();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (guna2CustomRadioButton1.Checked)
            {
                a = "consulteur";
            }
            else if (guna2CustomRadioButton2.Checked)
            {
                a = "admin";
            }
            else if (guna2CustomRadioButton3.Checked)
            {
                a = "directeur";
            }
            else if (guna2CustomRadioButton4.Checked)
            {
                a = "Archive";
            }
            Globale.connect();
            string query = "INSERT INTO compte(username,role) values(@user,@role)";
            MySqlCommand command = new MySqlCommand(query, Globale.connection);
            command.Parameters.AddWithValue("@user", guna2TextBox1.Text);
            command.Parameters.AddWithValue("@role", a);
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
            guna2CustomRadioButton1.Checked = false;
            guna2CustomRadioButton2.Checked = false;
            guna2CustomRadioButton3.Checked = false;
            guna2CustomRadioButton4.Checked = false;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = guna2DataGridView1.SelectedCells[0].RowIndex;



            DataGridViewRow selectedRow = guna2DataGridView1.Rows[selectedRowIndex];


            string uner = selectedRow.Cells["username"].Value.ToString();
            string role = selectedRow.Cells["role"].Value.ToString();


            if (role == "consulteur")
            {
                guna2CustomRadioButton1.Checked = true;
            }
            else if (role == "admin")
            {
                guna2CustomRadioButton2.Checked = true;
            }
            else if (role == "directeur")
            {
                guna2CustomRadioButton3.Checked = true;
            }
            else if (role == "Archive")
            {
                guna2CustomRadioButton4.Checked = true;
            }
            guna2TextBox1.Text = uner;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
            this.Close();
        }

        private void guna2CustomRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Globale.connect();
            string query = "SELECT username, role FROM compte WHERE role = @role";
            MySqlCommand command = new MySqlCommand(query, Globale.connection);
            command.Parameters.AddWithValue("@role", "consulteur");

            MySqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();

            dataTable.Load(reader);

            guna2DataGridView1.DataSource = dataTable;
            Globale.connection.Close();
        }

        private void guna2CustomRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Globale.connect();
            string query = "SELECT username, role FROM compte WHERE role = @role";
            MySqlCommand command = new MySqlCommand(query, Globale.connection);
            command.Parameters.AddWithValue("@role", "Archive");

            MySqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();

            dataTable.Load(reader);

            guna2DataGridView1.DataSource = dataTable;
            Globale.connection.Close();
        }

        private void guna2CustomRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Globale.connect();
            string query = "SELECT username, role FROM compte WHERE role = @role";
            MySqlCommand command = new MySqlCommand(query, Globale.connection);
            command.Parameters.AddWithValue("@role", "directeur");

            MySqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();

            dataTable.Load(reader);

            guna2DataGridView1.DataSource = dataTable;
            Globale.connection.Close();
        }

        private void guna2CustomRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Globale.connect();
            string query = "SELECT username, role FROM compte WHERE role = @role";
            MySqlCommand command = new MySqlCommand(query, Globale.connection);
            command.Parameters.AddWithValue("@role", "admin");

            MySqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();

            dataTable.Load(reader);

            guna2DataGridView1.DataSource = dataTable;
            Globale.connection.Close();
        }
    }
}
