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
    }
}

