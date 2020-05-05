namespace 컴퓨터_비전_권순석__Ver_0._1
{
    partial class Rotate
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
            this.Degree_Val = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_Degree = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Degree)).BeginInit();
            this.SuspendLayout();
            // 
            // Degree_Val
            // 
            this.Degree_Val.Location = new System.Drawing.Point(374, 24);
            this.Degree_Val.Name = "Degree_Val";
            this.Degree_Val.Size = new System.Drawing.Size(37, 25);
            this.Degree_Val.TabIndex = 29;
            this.Degree_Val.Text = "0";
            this.Degree_Val.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(232, 86);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 28;
            this.btn_cancel.Text = "취소";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(132, 86);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 27;
            this.btn_ok.Text = "적용";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 11F);
            this.label3.Location = new System.Drawing.Point(30, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "Degree";
            // 
            // trackBar_Degree
            // 
            this.trackBar_Degree.LargeChange = 10;
            this.trackBar_Degree.Location = new System.Drawing.Point(102, 24);
            this.trackBar_Degree.Maximum = 360;
            this.trackBar_Degree.Name = "trackBar_Degree";
            this.trackBar_Degree.Size = new System.Drawing.Size(266, 56);
            this.trackBar_Degree.TabIndex = 25;
            this.trackBar_Degree.Value = 1;
            this.trackBar_Degree.Scroll += new System.EventHandler(this.trackBar_Degree_Scroll);
            // 
            // Rotate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 133);
            this.Controls.Add(this.Degree_Val);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar_Degree);
            this.Name = "Rotate";
            this.Text = "Rotate";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Degree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Degree_Val;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TrackBar trackBar_Degree;
    }
}