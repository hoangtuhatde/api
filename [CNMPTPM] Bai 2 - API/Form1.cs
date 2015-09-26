using FlickrNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _CNMPTPM__Bai_2___API
{
    public partial class Form1 : Form
    {
        Flickr flickr;
        List<PictureBox> listPB;
        PhotoDisplay photoDisplayPanel;
        PhotoCollection photoList;
        String savedFolder;
        public Form1()
        {
            InitializeComponent();
            flickr = new Flickr();
            flickr.ApiKey = "02d9d42e5874595ec784899f266eb706";
            flickr.ApiSecret = "bc63ffe27560e18b";
            photoDisplayPanel = new PhotoDisplay();
            this.Controls.Add(photoDisplayPanel);
            photoDisplayPanel.Dock = DockStyle.Fill;
            lastestPhotosToolStripMenuItem_Click(null, null);
            //savedFolder = Application.StartupPath + "\\Photos";
            savedFolder = "Photos";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void lastestPhotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clean(); 
            listPB = new List<PictureBox>();
            photoList = flickr.InterestingnessGetList();
            showPhoto(photoList);
        }
        private void clean()
        {
            try
            {
                foreach(PictureBox p in listPB)
                {
                    photoDisplayPanel.Controls.Remove(p);
                }
                
                listPB.Clear();
            }
            catch (Exception)
            {
                
                return;
            }
            
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchForm s = new searchForm();
            s.ShowDialog();
            if (s.result != null)
            {
                photoList = s.result;
                showPhoto(photoList);
            }
        }
        private void showPhoto(PhotoCollection pc)
        {
            clean(); 
            int i = 0;
            foreach (Photo p in pc)
            {
                PictureBox pb = new PictureBox();
                Point location = new Point(20 + i % 4 * 320 + i % 4 * 10, 50 + i / 4 * 320 + i / 4 * 10);
                pb.Location = location;
                pb.Width = 320;
                pb.Height = 320;
                pb.SizeMode = PictureBoxSizeMode.CenterImage;
                pb.ImageLocation = p.Small320Url;
                pb.Parent = photoDisplayPanel;
                pb.ContextMenuStrip = photoContext;
                pb.Tag = i;
                listPB.Add(pb);
                i++;
            }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        public class PhotoDisplay : Panel
        {
            public PhotoDisplay()
            {
                this.AutoScroll = true;
                
            }
            protected override void OnScroll(ScrollEventArgs se)
            {
                this.Refresh();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ContextMenuStrip owner = saveToolStripMenuItem.Owner as ContextMenuStrip;
            Control sourceControl = owner.SourceControl;
            PictureBox pb = (PictureBox)sourceControl;
            WebClient webClient = new WebClient();
            int i = (int)pb.Tag;
            Photo p = photoList.ElementAt(i);
            Uri link = new Uri(p.LargeUrl);
            string name = p.Title;
            if (!System.IO.Directory.Exists(savedFolder))
                System.IO.Directory.CreateDirectory(savedFolder);
            string path = savedFolder + "\\" + name + ".jpg";
            webClient.DownloadFile(link, path);
        }

        private void savedFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            savedFolder = folderBrowserDialog1.SelectedPath;
        }
    }
}
