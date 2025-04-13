namespace PCRental
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPCs = new System.Windows.Forms.DataGridView();
            this.lblAdminContact = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPCs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPCs
            // 
            this.dgvPCs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPCs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPCs.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPCs.Location = new System.Drawing.Point(0, 0);
            this.dgvPCs.Name = "dgvPCs";
            this.dgvPCs.ReadOnly = true;
            this.dgvPCs.Size = new System.Drawing.Size(800, 300);
            this.dgvPCs.TabIndex = 0;
            // 
            // lblAdminContact
            // 
            this.lblAdminContact.AutoSize = true;
            this.lblAdminContact.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAdminContact.Location = new System.Drawing.Point(0, 437);
            this.lblAdminContact.Name = "lblAdminContact";
            this.lblAdminContact.Size = new System.Drawing.Size(191, 13);
            this.lblAdminContact.TabIndex = 1;
            this.lblAdminContact.Text = "Связаться с админом: 89001234567";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRefresh.Location = new System.Drawing.Point(0, 414);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(800, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Обновить список";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblAdminContact);
            this.Controls.Add(this.dgvPCs);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPCs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPCs;
        private System.Windows.Forms.Label lblAdminContact;
        private System.Windows.Forms.Button btnRefresh;
    }
}