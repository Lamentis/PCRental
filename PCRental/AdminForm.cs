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
    public partial class AdminForm : Form
    {
        private int adminId;

        public AdminForm(int userId)
        {
            InitializeComponent();
            adminId = userId;
            LoadPCs();
        }

        private void LoadPCs()
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                string query = @"SELECT PCs.PCID, PCs.Name, PCs.CPU, PCs.GPU, PCs.RAM, PCs.SSD, 
                                PCs.PricePerHour, PCs.Status, Users.FullName AS LandlordName, PCs.ContactPhone
                                FROM PCs
                                INNER JOIN Users ON PCs.LandlordID = Users.UserID";

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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void btnDeletePC_Click(object sender, EventArgs e)
        {
            if (dgvPCs.CurrentRow != null)
            {
                string pcName = dgvPCs.CurrentRow.Cells["Name"].Value.ToString();
                DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить ПК '{pcName}'?", "Подтверждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int pcId = Convert.ToInt32(dgvPCs.CurrentRow.Cells["PCID"].Value);

                    using (SqlConnection conn = DB.GetConnection())
                    {
                        string query = "DELETE FROM PCs WHERE PCID = @PCID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@PCID", pcId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    LoadPCs();
                    MessageBox.Show("ПК удалён.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите ПК для удаления.");
            }
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (dgvPCs.CurrentRow != null)
            {
                int pcId = Convert.ToInt32(dgvPCs.CurrentRow.Cells["PCID"].Value);
                string newStatus = cmbStatus.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(newStatus))
                {
                    MessageBox.Show("Пожалуйста, выберите новый статус.");
                    return;
                }

                using (SqlConnection conn = DB.GetConnection())
                {
                    string query = "UPDATE PCs SET Status = @Status WHERE PCID = @PCID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@PCID", pcId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                LoadPCs();
                MessageBox.Show("Статус обновлён.");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите ПК.");
            }
        }
    }
}

