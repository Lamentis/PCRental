namespace PCRental
{
    partial class LandlordForm
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
            this.dgvLandlordPCs = new System.Windows.Forms.DataGridView();
            this.btnAddPC = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLandlordPCs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLandlordPCs
            // 
            this.dgvLandlordPCs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLandlordPCs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLandlordPCs.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvLandlordPCs.Location = new System.Drawing.Point(0, 0);
            this.dgvLandlordPCs.Name = "dgvLandlordPCs";
            this.dgvLandlordPCs.Size = new System.Drawing.Size(800, 300);
            this.dgvLandlordPCs.TabIndex = 0;
            // 
            // btnAddPC
            // 
            this.btnAddPC.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddPC.Location = new System.Drawing.Point(0, 427);
            this.btnAddPC.Name = "btnAddPC";
            this.btnAddPC.Size = new System.Drawing.Size(800, 23);
            this.btnAddPC.TabIndex = 1;
            this.btnAddPC.Text = "Добавить ПК";
            this.btnAddPC.UseVisualStyleBackColor = true;
            this.btnAddPC.Click += new System.EventHandler(this.btnAddPC_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRefresh.Location = new System.Drawing.Point(0, 404);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(800, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Обновить список";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // LandlordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAddPC);
            this.Controls.Add(this.dgvLandlordPCs);
            this.Name = "LandlordForm";
            this.Text = "LandlordForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLandlordPCs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLandlordPCs;
        private System.Windows.Forms.Button btnAddPC;
        private System.Windows.Forms.Button btnRefresh;
    }
}