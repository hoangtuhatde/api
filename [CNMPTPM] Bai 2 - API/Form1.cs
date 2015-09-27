using FlickrNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _CNMPTPM__Bai_2___API
{
    public partial class Form1 : Form
    {
        Flickr flickr;
        List<PictureBox> listPB;
        PhotoDisplay photoDisplayPanel;
        //PhotoCollection photoList;
        String savedFolder;
        String appName;
        public Form1()
        {
            InitializeComponent();
            appName = "Flickr Api Test App";
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
            this.Text =  appName + " - Top 100 photos";
            listPB = new List<PictureBox>();
            var photoList = flickr.InterestingnessGetList();
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
            this.Text = appName + " - Photos with keyword \"" + s.name + "\"";
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var photoList = s.result;
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
                pb.Tag = p;
                pb.MouseHover += photo_Hover;
                pb.MouseLeave += photo_unHover;
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
            Photo p = (Photo)pb.Tag;
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
        private void photo_Hover(object sender, EventArgs e)
        {
            var pb = (PictureBox)sender;
            pb.BorderStyle = BorderStyle.FixedSingle;
            var p = (Photo)pb.Tag;
            string tip;
            var info = flickr.PhotosGetInfo(p.PhotoId);
            var t = new ToolTip();
            tip = "Title: " + info.Title + "\n" + "Owner: " + info.OwnerUserName + "\n" + "Description: " + info.Description + "\n" + "Link: " + info.WebUrl + "\n";
            t.SetToolTip((PictureBox)sender, tip);
        }
        private void photo_unHover(object sender, EventArgs e)
        {
            var pb = (PictureBox)sender;
            pb.BorderStyle = BorderStyle.None;
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var uf = new uploadForm();
            if (uf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var flickrFrob = flickr.AuthGetFrob();
                string url = flickr.AuthCalcUrl(flickrFrob, FlickrNet.AuthLevel.Write);
                System.Diagnostics.Process.Start(url);
                MessageBox.Show("Press Ok when completed authentication");
                try
                {
                    FlickrNet.Auth auth = flickr.AuthGetToken(flickrFrob);
                    flickr.AuthToken = auth.Token;
                }
                catch (FlickrNet.FlickrException ex)
                {
                    MessageBox.Show("User didn't approve!\n\n" + ex.Message);
                    return;
                }
                try
                {
                    System.Threading.Thread threadUpload = new System.Threading.Thread(delegate()
                    {
                        string id = flickr.UploadPicture(uf.path, uf.title, uf.des);
                        var info = flickr.PhotosGetInfo(id);
                        var link = info.WebUrl;
                        Thread threadClipboard = new Thread(() => Clipboard.SetText(link));
                        threadClipboard.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                        threadClipboard.Start(); 
                        MessageBox.Show("Upload completed. Link to photo has been copied to clipboard.");
                    });
                    threadUpload.Start();
                }
                catch (Exception)
                {
                    MessageBox.Show("Upload failed");
                }
            }

            
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchForm s = new searchForm();
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    var user = flickr.PeopleFindByUserName(s.name);
                    var photos = flickr.PeopleGetPublicPhotos(user.UserId);
                    this.Text = appName + " - Photos by \"" + s.name + "\"";
                    showPhoto(photos);
                }
                catch (FlickrException ex)
                {
                    MessageBox.Show("Something wrong!\n\n" + ex.Message);
                    return;
                }
            }
        }

    }
}
