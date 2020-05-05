namespace 컴퓨터_비전_권순석__Ver_0._1
{
    partial class Gamma
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_Gamma = new System.Windows.Forms.TrackBar();
            this.Gamma_Val = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Gamma)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(240, 86);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 17;
            this.btn_cancel.Text = "취소";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(140, 86);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 16;
            this.btn_ok.Text = "적용";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 11F);
            this.label3.Location = new System.Drawing.Point(27, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "Gamma";
            // 
            // trackBar_Gamma
            // 
            this.trackBar_Gamma.Location = new System.Drawing.Point(104, 24);
            this.trackBar_Gamma.Maximum = 50;
            this.trackBar_Gamma.Minimum = 1;
            this.trackBar_Gamma.Name = "trackBar_Gamma";
            this.trackBar_Gamma.Size = new System.Drawing.Size(266, 56);
            this.trackBar_Gamma.TabIndex = 14;
            this.trackBar_Gamma.Value = 1;
            this.trackBar_Gamma.Scroll += new System.EventHandler(this.trackBar_Gamma_Scroll);
            // 
            // Gamma_Val
            // 
            this.Gamma_Val.Location = new System.Drawing.Point(376, 24);
            this.Gamma_Val.Name = "Gamma_Val";
            this.Gamma_Val.Size = new System.Drawing.Size(26, 25);
            this.Gamma_Val.TabIndex = 19;
            this.Gamma_Val.Text = "0";
            // 
            // Gamma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 133);
            this.Controls.Add(this.Gamma_Val);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar_Gamma);
            this.Name = "Gamma";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Gamma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TrackBar trackBar_Gamma;
        private System.Windows.Forms.TextBox Gamma_Val;
    }
}