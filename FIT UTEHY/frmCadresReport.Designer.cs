namespace FIT_UTEHY
{
    partial class frmCadresReport
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
            this.crystalReportCadres = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportCadres
            // 
            this.crystalReportCadres.ActiveViewIndex = -1;
            this.crystalReportCadres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportCadres.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportCadres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportCadres.Location = new System.Drawing.Point(0, 0);
            this.crystalReportCadres.Name = "crystalReportCadres";
            this.crystalReportCadres.Size = new System.Drawing.Size(1092, 570);
            this.crystalReportCadres.TabIndex = 0;
            // 
            // frmCadresReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 570);
            this.Controls.Add(this.crystalReportCadres);
            this.Name = "frmCadresReport";
            this.Text = "frmCadresReport";
            this.Load += new System.EventHandler(this.frmCadresReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportCadres;
    }
}