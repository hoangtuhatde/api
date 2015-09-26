using FlickrNet;
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
    public partial class searchForm : Form
    {
        Flickr flickr;
        public PhotoCollection result;
        public searchForm()
        {
            InitializeComponent();
            flickr = new Flickr();
            flickr.ApiKey = "02d9d42e5874595ec784899f266eb706";
            flickr.ApiSecret = "bc63ffe27560e18b";
        }

        private void search_Click(object sender, EventArgs e)
        {
            string str = text.Text;
            if (str != "")
            {
                PhotoSearchOptions opt = new PhotoSearchOptions(null, null, FlickrNet.TagMode.AnyTag, str);
                result = flickr.PhotosSearch(opt);
                this.Hide();
            }
        }

        private void searchForm_Load(object sender, EventArgs e)
        {

        }

        private void searchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            result = null;
        }
    }
}
