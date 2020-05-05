using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 컴퓨터_비전_권순석__Ver_0._1
{
    public partial class Gamma : Form
    {
        public Gamma()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void trackBar_Gamma_Scroll(object sender, EventArgs e)
        {
            int trackbarVal = trackBar_Gamma.Value;
            Gamma_Val.Text = trackbarVal.ToString();
        }
    }
}
