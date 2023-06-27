
namespace QLBH
{
    partial class crNhieuNhat
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
            this.CRHoaDonNhieuNhat = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRHoaDonNhieuNhat
            // 
            this.CRHoaDonNhieuNhat.ActiveViewIndex = -1;
            this.CRHoaDonNhieuNhat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRHoaDonNhieuNhat.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRHoaDonNhieuNhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRHoaDonNhieuNhat.Location = new System.Drawing.Point(0, 0);
            this.CRHoaDonNhieuNhat.Name = "CRHoaDonNhieuNhat";
            this.CRHoaDonNhieuNhat.Size = new System.Drawing.Size(800, 450);
            this.CRHoaDonNhieuNhat.TabIndex = 0;
            this.CRHoaDonNhieuNhat.Load += new System.EventHandler(this.CRHoaDonNhieuNhat_Load);
            // 
            // crNhieuNhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CRHoaDonNhieuNhat);
            this.Name = "crNhieuNhat";
            this.Text = "crNhieuNhat";
            this.Load += new System.EventHandler(this.crNhieuNhat_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer CRHoaDonNhieuNhat;
    }
}