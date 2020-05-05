namespace 컴퓨터_비전_권순석__Ver_0._1
{
    partial class MoveScreen
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
            this.numeric_Yindex = new System.Windows.Forms.NumericUpDown();
            this.numeric_Xindex = new System.Windows.Forms.NumericUpDown();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Yindex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Xindex)).BeginInit();
            this.SuspendLayout();
            // 
            // numeric_Yindex
            // 
            this.numeric_Yindex.Location = new System.Drawing.Point(131, 35);
            this.numeric_Yindex.Name = "numeric_Yindex";
            this.numeric_Yindex.Size = new System.Drawing.Size(75, 25);
            this.numeric_Yindex.TabIndex = 27;
            this.numeric_Yindex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numeric_Xindex
            // 
            this.numeric_Xindex.Location = new System.Drawing.Point(131, 3);
            this.numeric_Xindex.Name = "numeric_Xindex";
            this.numeric_Xindex.Size = new System.Drawing.Size(75, 25);
            this.numeric_Xindex.TabIndex = 26;
            this.numeric_Xindex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(131, 82);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 25;
            this.btn_cancel.Text = "취소";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(31, 82);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 24;
            this.btn_ok.Text = "적용";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F);
            this.label2.Location = new System.Drawing.Point(32, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Y Index";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F);
            this.label1.Location = new System.Drawing.Point(32, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "X Index";
            // 
            // MoveScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 113);
            this.Controls.Add(this.numeric_Yindex);
            this.Controls.Add(this.numeric_Xindex);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MoveScreen";
            this.Text = "MoveScreen";
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Yindex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Xindex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NumericUpDown numeric_Yindex;
        public System.Windows.Forms.NumericUpDown numeric_Xindex;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}