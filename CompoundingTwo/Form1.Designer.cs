namespace CompoundingTwo {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtPrinc = new System.Windows.Forms.TextBox();
            this.txtInterest = new System.Windows.Forms.TextBox();
            this.lblPrinc = new System.Windows.Forms.Label();
            this.lblInterest = new System.Windows.Forms.Label();
            this.lblCompMeth = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.txtIntEarned = new System.Windows.Forms.TextBox();
            this.lblIntEarned = new System.Windows.Forms.Label();
            this.cboCompMeth = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtPrinc
            // 
            this.txtPrinc.Location = new System.Drawing.Point(139, 12);
            this.txtPrinc.Name = "txtPrinc";
            this.txtPrinc.Size = new System.Drawing.Size(100, 20);
            this.txtPrinc.TabIndex = 1;
            this.txtPrinc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInterest
            // 
            this.txtInterest.Location = new System.Drawing.Point(139, 38);
            this.txtInterest.Name = "txtInterest";
            this.txtInterest.Size = new System.Drawing.Size(100, 20);
            this.txtInterest.TabIndex = 3;
            this.txtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrinc
            // 
            this.lblPrinc.AutoSize = true;
            this.lblPrinc.Location = new System.Drawing.Point(12, 15);
            this.lblPrinc.Name = "lblPrinc";
            this.lblPrinc.Size = new System.Drawing.Size(89, 13);
            this.lblPrinc.TabIndex = 0;
            this.lblPrinc.Text = "Initial Principal ($)";
            // 
            // lblInterest
            // 
            this.lblInterest.AutoSize = true;
            this.lblInterest.Location = new System.Drawing.Point(12, 41);
            this.lblInterest.Name = "lblInterest";
            this.lblInterest.Size = new System.Drawing.Size(121, 13);
            this.lblInterest.TabIndex = 2;
            this.lblInterest.Text = "Annual Interest Rate (%)";
            // 
            // lblCompMeth
            // 
            this.lblCompMeth.AutoSize = true;
            this.lblCompMeth.Location = new System.Drawing.Point(12, 67);
            this.lblCompMeth.Name = "lblCompMeth";
            this.lblCompMeth.Size = new System.Drawing.Size(111, 13);
            this.lblCompMeth.TabIndex = 4;
            this.lblCompMeth.Text = "Compounding Method";
            // 
            // btnCalc
            // 
            this.btnCalc.Enabled = false;
            this.btnCalc.Location = new System.Drawing.Point(88, 105);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 6;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // txtIntEarned
            // 
            this.txtIntEarned.Location = new System.Drawing.Point(139, 145);
            this.txtIntEarned.Name = "txtIntEarned";
            this.txtIntEarned.ReadOnly = true;
            this.txtIntEarned.Size = new System.Drawing.Size(100, 20);
            this.txtIntEarned.TabIndex = 8;
            this.txtIntEarned.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIntEarned
            // 
            this.lblIntEarned.AutoSize = true;
            this.lblIntEarned.Location = new System.Drawing.Point(12, 148);
            this.lblIntEarned.Name = "lblIntEarned";
            this.lblIntEarned.Size = new System.Drawing.Size(79, 13);
            this.lblIntEarned.TabIndex = 7;
            this.lblIntEarned.Text = "Interest Earned";
            // 
            // cboCompMeth
            // 
            this.cboCompMeth.FormattingEnabled = true;
            this.cboCompMeth.Location = new System.Drawing.Point(139, 64);
            this.cboCompMeth.Name = "cboCompMeth";
            this.cboCompMeth.Size = new System.Drawing.Size(100, 21);
            this.cboCompMeth.TabIndex = 9;
            this.cboCompMeth.SelectedIndexChanged += new System.EventHandler(this.cboCompMeth_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 177);
            this.Controls.Add(this.cboCompMeth);
            this.Controls.Add(this.lblIntEarned);
            this.Controls.Add(this.txtIntEarned);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.lblCompMeth);
            this.Controls.Add(this.lblInterest);
            this.Controls.Add(this.lblPrinc);
            this.Controls.Add(this.txtInterest);
            this.Controls.Add(this.txtPrinc);
            this.Name = "Form1";
            this.Text = "Interest Earned";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrinc;
        private System.Windows.Forms.TextBox txtInterest;
        private System.Windows.Forms.Label lblPrinc;
        private System.Windows.Forms.Label lblInterest;
        private System.Windows.Forms.Label lblCompMeth;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.TextBox txtIntEarned;
        private System.Windows.Forms.Label lblIntEarned;
        private System.Windows.Forms.ComboBox cboCompMeth;
    }
}

