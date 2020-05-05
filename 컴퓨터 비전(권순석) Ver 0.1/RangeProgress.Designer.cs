namespace 컴퓨터_비전_권순석__Ver_0._1
{
    partial class RangeProgress
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.numeric_First = new System.Windows.Forms.NumericUpDown();
            this.numeric_Second = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_First)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Second)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F);
            this.label1.Location = new System.Drawing.Point(44, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F);
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Second Index";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(131, 82);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 19;
            this.btn_cancel.Text = "취소";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(31, 82);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 18;
            this.btn_ok.Text = "적용";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // numeric_First
            // 
            this.numeric_First.Location = new System.Drawing.Point(145, 7);
            this.numeric_First.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numeric_First.Name = "numeric_First";
            this.numeric_First.Size = new System.Drawing.Size(75, 25);
            this.numeric_First.TabIndex = 20;
            this.numeric_First.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numeric_Second
            // 
            this.numeric_Second.Location = new System.Drawing.Point(145, 39);
            this.numeric_Second.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numeric_Second.Name = "numeric_Second";
            this.numeric_Second.Size = new System.Drawing.Size(75, 25);
            this.numeric_Second.TabIndex = 21;
            this.numeric_Second.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RangeProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 117);
            this.Controls.Add(this.numeric_Second);
            this.Controls.Add(this.numeric_First);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RangeProgress";
            this.Text = "RangeProgress";
            ((System.ComponentModel.ISupportInitialize)(this.numeric_First)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Second)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        public System.Windows.Forms.NumericUpDown numeric_First;
        public System.Windows.Forms.NumericUpDown numeric_Second;
    }
}