
namespace QLBH
{
    partial class crNhanVien
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
            this.CRViewerNV = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRViewerNV
            // 
            this.CRViewerNV.ActiveViewIndex = -1;
            this.CRViewerNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRViewerNV.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRViewerNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRViewerNV.Location = new System.Drawing.Point(0, 0);
            this.CRViewerNV.Name = "CRViewerNV";
            this.CRViewerNV.Size = new System.Drawing.Size(800, 450);
            this.CRViewerNV.TabIndex = 0;
            this.CRViewerNV.Load += new System.EventHandler(this.CRViewerNV_Load);
            // 
            // crNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CRViewerNV);
            this.Name = "crNhanVien";
            this.Text = "crNhanVien";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRViewerNV;
    }
}