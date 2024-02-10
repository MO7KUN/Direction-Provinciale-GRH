using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Direction_Provinciale_GRH
{
     public class Globale
    {
        static public MySqlConnection connection = new MySqlConnection();
        static private String role;
        static private String username;

        static public void connect()
        {
            try
            {
                string connectionString = "server=localhost;database=gestion personnel;user=root;password=";
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        static public void setrole(String r)
        {
            role = r;
        }

        static public void setusername(String user)
        {
            username = user;
        }


        static public String getrole()
        {
            return role;
        }

        static public String getusername()
        {
            return username;
        }

    }
}
