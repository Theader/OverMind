
namespace UI
{
    partial class frmDogsFacts
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDogs = new System.Windows.Forms.Label();
            this.cboPlanilha = new System.Windows.Forms.ComboBox();
            this.cboEndPoint = new System.Windows.Forms.ComboBox();
            this.btnGerarExcel = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // lblDogs
            // 
            this.lblDogs.AutoSize = true;
            this.lblDogs.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDogs.Location = new System.Drawing.Point(78, 26);
            this.lblDogs.Name = "lblDogs";
            this.lblDogs.Size = new System.Drawing.Size(178, 37);
            this.lblDogs.TabIndex = 0;
            this.lblDogs.Text = "DOGS FACTS";
            // 
            // cboPlanilha
            // 
            this.cboPlanilha.FormattingEnabled = true;
            this.cboPlanilha.Location = new System.Drawing.Point(135, 75);
            this.cboPlanilha.Name = "cboPlanilha";
            this.cboPlanilha.Size = new System.Drawing.Size(121, 23);
            this.cboPlanilha.TabIndex = 1;
            this.cboPlanilha.Visible = false;
            // 
            // cboEndPoint
            // 
            this.cboEndPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndPoint.FormattingEnabled = true;
            this.cboEndPoint.Location = new System.Drawing.Point(78, 75);
            this.cboEndPoint.Name = "cboEndPoint";
            this.cboEndPoint.Size = new System.Drawing.Size(178, 23);
            this.cboEndPoint.TabIndex = 2;
            // 
            // btnGerarExcel
            // 
            this.btnGerarExcel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGerarExcel.Location = new System.Drawing.Point(78, 135);
            this.btnGerarExcel.Name = "btnGerarExcel";
            this.btnGerarExcel.Size = new System.Drawing.Size(178, 65);
            this.btnGerarExcel.TabIndex = 3;
            this.btnGerarExcel.Text = "Gerar Excel";
            this.btnGerarExcel.UseVisualStyleBackColor = true;
            this.btnGerarExcel.Click += new System.EventHandler(this.btnGerarExcel_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // frmDogsFacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 228);
            this.Controls.Add(this.btnGerarExcel);
            this.Controls.Add(this.cboEndPoint);
            this.Controls.Add(this.cboPlanilha);
            this.Controls.Add(this.lblDogs);
            this.Name = "frmDogsFacts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dogs Facts";
            this.Load += new System.EventHandler(this.frmDogsFacts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDogs;
        private System.Windows.Forms.ComboBox cboPlanilha;
        private System.Windows.Forms.ComboBox cboEndPoint;
        private System.Windows.Forms.Button btnGerarExcel;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SaveFileDialog saveFile;
    }
}

