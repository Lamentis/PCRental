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
using PCRental;

namespace PCRental
{
    public partial class UserForm : Form
    {
        private int userId;

        public UserForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadPCs();
            InitializeDurationComboBox();
        }

        private void InitializeDurationComboBox()
        {
            cmbDuration.Items.Clear();
            cmbDuration.Items.Add("1 день");
            cmbDuration.Items.Add("1 неделя");
            cmbDuration.Items.Add("1 месяц");
            cmbDuration.Items.Add("Другое (свяжитесь с админом)");
            cmbDuration.SelectedIndex = 0;
        }

        private void LoadPCs()
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                string query = "SELECT Name, CPU, GPU, RAM, SSD, PricePerHour, Status, ContactPhone FROM PCs";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvPCs.DataSource = table;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPCs();
        }

        private void btnContactLandlord_Click(object sender, EventArgs e)
        {
            if (dgvPCs.CurrentRow != null)
            {
                string status = dgvPCs.CurrentRow.Cells["Status"].Value.ToString();
                if (status != "Свободен")
                {
                    MessageBox.Show("Этот ПК уже арендован.");
                    return;
                }

                string phone = dgvPCs.CurrentRow.Cells["ContactPhone"].Value.ToString();
                string selectedDuration = cmbDuration.SelectedItem?.ToString();

                if (selectedDuration == "Другое (свяжитесь с админом)")
                {
                    MessageBox.Show($"Для обсуждения длительной аренды свяжитесь с админом.\nEmail: admin@example.com\nТелефон: 89001234567");
                }
                else
                {
                    MessageBox.Show($"Позвоните арендодателю по номеру: {phone}\nВыбранная длительность аренды: {selectedDuration}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите ПК.");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

    }
}