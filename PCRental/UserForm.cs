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
            cmbDuration.SelectedIndexChanged += cmbDuration_SelectedIndexChanged;
            dgvPCs.SelectionChanged += dgvPCs_SelectionChanged;
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

        private void cmbDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        private void dgvPCs_SelectionChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            if (dgvPCs.CurrentRow == null || cmbDuration.SelectedItem == null)
            {
                lblTotalPrice.Text = "Итоговая стоимость: 0 руб.";
                return;
            }

            string duration = cmbDuration.SelectedItem.ToString();
            if (duration == "Другое (свяжитесь с админом)")
            {
                lblTotalPrice.Text = "Обсудите цену с админом.";
                return;
            }

            if (!decimal.TryParse(dgvPCs.CurrentRow.Cells["PricePerHour"].Value.ToString(), out decimal pricePerHour))
            {
                lblTotalPrice.Text = "Ошибка в цене.";
                return;
            }

            int totalHours = 0;

            switch (duration)
            {
                case "1 день":
                    totalHours = 24;
                    break;
                case "1 неделя":
                    totalHours = 7 * 24;
                    break;
                case "1 месяц":
                    totalHours = 30 * 24;
                    break;
            }

            decimal total = pricePerHour * totalHours;
            lblTotalPrice.Text = $"Итоговая стоимость: {total} руб.";
        }
    }
}
