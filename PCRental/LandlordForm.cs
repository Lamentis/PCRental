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
    public partial class LandlordForm : Form
    {
        private int landlordId;

        public LandlordForm(int userId)
        {
            InitializeComponent();
            landlordId = userId;
            LoadPCs();
        }

        private void LoadPCs()
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                string query = @"SELECT PCID, Name, CPU, GPU, RAM, SSD, PricePerHour, Status, ContactPhone
                                 FROM PCs
                                 WHERE LandlordID = @LandlordID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LandlordID", landlordId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvLandlordPCs.DataSource = table;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPCs();
        }

        private void btnAddPC_Click(object sender, EventArgs e)
        {
            AddPCForm addForm = new AddPCForm(landlordId);
            addForm.ShowDialog();
            LoadPCs(); // Обновим список после добавления
        }
    }
}
