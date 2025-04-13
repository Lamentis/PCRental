using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PCRental
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (email == "" || password == "")
            {
                MessageBox.Show("Пожалуйста, введите email и пароль.");
                return;
            }

            using (SqlConnection conn = DB.GetConnection())
            {
                string query = "SELECT UserID, RoleID FROM Users WHERE Email=@Email AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int userId = reader.GetInt32(0);
                    int roleId = reader.GetInt32(1);

                    this.Hide();

                    switch (roleId)
                    {
                        case 1:
                            new AdminForm(userId).Show();
                            break;
                        case 2:
                            new LandlordForm(userId).Show();
                            break;
                        case 3:
                            new UserForm(userId).Show();
                            break;
                        default:
                            MessageBox.Show("Неизвестная роль.");
                            this.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный email или пароль.");
                }

                conn.Close();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            this.Show();
        }
    }
}
