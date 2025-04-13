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

namespace PCRental
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            // Заполняем роли
            cmbRole.Items.Add("User");
            cmbRole.Items.Add("Landlord");
            cmbRole.SelectedIndex = 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text.Trim();
            string roleName = cmbRole.SelectedItem.ToString();

            if (fullName == "" || email == "" || phone == "" || password == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            int roleId = roleName == "User" ? 3 : 2;

            using (SqlConnection conn = DB.GetConnection())
            {
                string query = "INSERT INTO Users (FullName, Email, Phone, Password, RoleID) VALUES (@FullName, @Email, @Phone, @Password, @RoleID)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@RoleID", roleId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Регистрация прошла успешно!");
                    this.Close(); // Закрываем форму, возвращаемся к LoginForm
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при регистрации: " + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
