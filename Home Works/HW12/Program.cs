using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace HW12
{
    class Program : Form
    {
        TextBox t;
        ListBox lst;
        RichTextBox rct;
        private ListBox lstImages;
        private PictureBox pic;
        private Dictionary<string, string> imagePaths = new Dictionary<string, string>();
        PanelDragandDrop p;
        SortListBox lstsort;
        Button btnPlay;
        public Program()
        {
            //   1

            AutoSize = true;
            Text = "HW for Lab 12";
            t = new TextBox();
            lst = new ListBox();

            t.Size = new Size(80, 50);
            lst.Size = new Size(80, 100);
            t.Location = new Point(10, 50);
            lst.Location = new Point(100, 10);
            lst.AllowDrop = t.AllowDrop = true;
            t.MouseDown += TakeData;
            lst.DragEnter += EffectDrag;
            lst.DragDrop += PutData;

            Controls.AddRange(new Control[] { t, lst });

            //   2  

            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;

            //   3 

            rct = new RichTextBox();
            rct.Size = new Size(170, 150);
            rct.Location = new Point(10, 120);
            rct.AllowDrop = true;
            rct.DragEnter += Rct_DragEnter;
            rct.DragDrop += Rct_DragDrop;
            Controls.Add(rct);

            //   4 
            pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.Location = new Point(210, 10);
            pic.SizeMode = PictureBoxSizeMode.Zoom;

            lstImages = new ListBox();
            lstImages.Size = new Size(100, 155);
            lstImages.Location = new Point(210, 120);
            lstImages.AllowDrop = true;

            lstImages.DragEnter += LstImages_DragEnter;
            lstImages.DragDrop += LstImages_DragDrop2;
            lstImages.SelectedIndexChanged += LstImages_SelectedIndexChanged;

            Controls.AddRange(new Control[] { lstImages, pic });

            //   5 
            p = new PanelDragandDrop();
            p.Size = new Size(170, 110);
            p.Location = new Point(350, 10);
            Controls.Add(p);

            //   6 
            lstsort = new SortListBox();
            lstsort.Size = new Size(100, 160);
            lstsort.Location = new Point(350, 125);
            Controls.Add(lstsort);

            btnPlay = new Button();
            btnPlay.Size = new Size(100, 50);
            btnPlay.Location = new Point(460, 170);
            btnPlay.Text = "Play Now";
            btnPlay.Click += Play;
            Controls.Add((btnPlay));

        }

        void TakeData(object s,MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (t.SelectedText!="")
                {
                    DoDragDrop(t.SelectedText, DragDropEffects.Copy);
                }
            }
        }

        void PutData(object s,DragEventArgs e)
        {
            lst.Items.Add((string)e.Data.GetData(typeof(string)));
        }


        void EffectDrag(object s,DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        //   2

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                if (IsImageFile(file))
                {
                    ShowImage imgForm = new ShowImage(file);
                    imgForm.Show();
                }
            }
        }
        private bool IsImageFile(string file)
        {
            string ext = System.IO.Path.GetExtension(file).ToLower();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif";
        }

        //   3 

        void Rct_DragEnter(object s ,DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        void Rct_DragDrop(object s ,DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                try
                {
                    string ext = Path.GetExtension(file).ToLower();
                    if (ext == ".txt")
                    {
                        string content = File.ReadAllText(file);
                        rct.AppendText("===== " + Path.GetFileName(file) + " =====\n");
                        rct.AppendText(content + "\n\n");
                    }
                    else
                    {
                        rct.AppendText("الملف " + Path.GetFileName(file) + " ليس ملف نصي\n\n");
                    }
                }
                catch (Exception ex)
                {
                    rct.AppendText("خطأ في قراءة الملف: " + file + "\n" + ex.Message + "\n\n");
                }
            }
        }

        //   4
        void LstImages_DragEnter(object s,DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        void LstImages_DragDrop(object s,DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void LstImages_DragDrop2(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                if (IsImageFile(file))
                {
                    string fileName = Path.GetFileName(file);
                    if (!imagePaths.ContainsKey(fileName))
                    {
                        lstImages.Items.Add(fileName);
                        imagePaths[fileName] = file; 
                    }
                }
            }
        }
        void LstImages_SelectedIndexChanged(object s,EventArgs e)
        {
            if (lstImages.SelectedItem != null)
            {
                string fileName = lstImages.SelectedItem.ToString();
                if (imagePaths.TryGetValue(fileName, out string path))
                {
                    if (pic.Image != null)
                        pic.Image.Dispose();
                    pic.Image = Image.FromFile(path);
                }
            }
        }

        //   7
        void Play(object s,EventArgs e)
        {
            ImagesGame g = new ImagesGame();
            g.ShowDialog();
        }

        [STAThread]
        static void Main(string[] args)
        {
            Program p = new Program();
            p.ShowDialog();
        }
    }
}
