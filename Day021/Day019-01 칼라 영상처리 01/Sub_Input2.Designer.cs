namespace Day019_01_칼라_영상처리_01
{
    partial class Sub_Input2
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
            this.label2 = new System.Windows.Forms.Label();
            this.numeric_double2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.numeric_double1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_double2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_double1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(27, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "두 번째 숫자";
            // 
            // numeric_double2
            // 
            this.numeric_double2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numeric_double2.Location = new System.Drawing.Point(136, 53);
            this.numeric_double2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numeric_double2.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.numeric_double2.Name = "numeric_double2";
            this.numeric_double2.Size = new System.Drawing.Size(120, 25);
            this.numeric_double2.TabIndex = 14;
            this.numeric_double2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeric_double2_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "첫 번째 숫자";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(149, 88);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 12;
            this.btn_cancel.Text = "취소";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(55, 88);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 11;
            this.btn_ok.Text = "확인";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // numeric_double1
            // 
            this.numeric_double1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numeric_double1.Location = new System.Drawing.Point(136, 22);
            this.numeric_double1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numeric_double1.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.numeric_double1.Name = "numeric_double1";
            this.numeric_double1.Size = new System.Drawing.Size(120, 25);
            this.numeric_double1.TabIndex = 10;
            // 
            // Sub_Input2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 133);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numeric_double2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.numeric_double1);
            this.Name = "Sub_Input2";
            this.Text = "Sub_Input2";
            ((System.ComponentModel.ISupportInitialize)(this.numeric_double2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_double1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown numeric_double2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        public System.Windows.Forms.NumericUpDown numeric_double1;
    }
}