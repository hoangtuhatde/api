using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _CNMPTPM__Bai_2___API
{
    public partial class uploadForm : Form
    {
        public string path;
        public string title;
        public string des;
        public uploadForm()
        {
            InitializeComponent();
        }

        private void bChoose_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                labelTitle.Text = openFileDialog1.SafeFileName;
            }
        }

        private void bUpload_Click(object sender, EventArgs e)
        {
            title = txtTitle.Text;
            des = txtDes.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
