namespace 컴퓨터_비전_권순석__Ver_0._1
{
    partial class Zoom
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
            this.Scale_Val = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_Scale = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Scale)).BeginInit();
            this.SuspendLayout();
            // 
            // Scale_Val
            // 
            this.Scale_Val.Location = new System.Drawing.Point(373, 24);
            this.Scale_Val.Name = "Scale_Val";
            this.Scale_Val.Size = new System.Drawing.Size(26, 25);
            this.Scale_Val.TabIndex = 24;
            this.Scale_Val.Text = "0";
            this.Scale_Val.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(231, 86);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 23;
            this.btn_cancel.Text = "취소";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(131, 86);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 22;
            this.btn_ok.Text = "적용";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 11F);
            this.label3.Location = new System.Drawing.Point(42, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 19);
            this.label3.TabIndex = 21;
            this.label3.Text = "Scale";
            // 
            // trackBar_Scale
            // 
            this.trackBar_Scale.LargeChange = 1;
            this.trackBar_Scale.Location = new System.Drawing.Point(101, 24);
            this.trackBar_Scale.Minimum = 1;
            this.trackBar_Scale.Name = "trackBar_Scale";
            this.trackBar_Scale.Size = new System.Drawing.Size(266, 56);
            this.trackBar_Scale.TabIndex = 20;
            this.trackBar_Scale.Value = 1;
            this.trackBar_Scale.Scroll += new System.EventHandler(this.trackBar_Scale_Scroll);
            // 
            // Zoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 133);
            this.Controls.Add(this.Scale_Val);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar_Scale);
            this.Name = "Zoom";
            this.Text = "ZoomOut";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Scale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Scale_Val;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TrackBar trackBar_Scale;
    }
}