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
    public partial class AddPCForm : Form
    {
        private int landlordId;

        public AddPCForm(int landlordId)
        {
            InitializeComponent();
            this.landlordId = landlordId;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string cpu = txtCPU.Text.Trim();
            string gpu = txtGPU.Text.Trim();
            string ram = txtRAM.Text.Trim();
            string ssd = txtSSD.Text.Trim();
            string priceText = txtPrice.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(cpu) || string.IsNullOrEmpty(gpu) ||
                string.IsNullOrEmpty(ram) || string.IsNullOrEmpty(ssd) || string.IsNullOrEmpty(priceText) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Введите корректную цену.");
                return;
            }

            using (SqlConnection conn = DB.GetConnection())
            {
                string query = @"INSERT INTO PCs (Name, CPU, GPU, RAM, SSD, PricePerHour, Status, LandlordID, ContactPhone)
                                 VALUES (@Name, @CPU, @GPU, @RAM, @SSD, @PricePerHour, @Status, @LandlordID, @ContactPhone)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@CPU", cpu);
                cmd.Parameters.AddWithValue("@GPU", gpu);
                cmd.Parameters.AddWithValue("@RAM", ram);
                cmd.Parameters.AddWithValue("@SSD", ssd);
                cmd.Parameters.AddWithValue("@PricePerHour", price);
                cmd.Parameters.AddWithValue("@Status", "Свободен");
                cmd.Parameters.AddWithValue("@LandlordID", landlordId);
                cmd.Parameters.AddWithValue("@ContactPhone", phone);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            MessageBox.Show("ПК успешно добавлен.");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

