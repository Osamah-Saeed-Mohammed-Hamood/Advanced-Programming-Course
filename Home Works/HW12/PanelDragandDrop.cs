using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW12
{
    class PanelDragandDrop : GroupBox
    {
        TextBox t;
        ListBox lst;

        public enum Accept { Yes, No }

        Accept accept;

        public Accept AcceptDragDrop
        {
            get { return accept; }

            set
                {
                accept = value;

                if (value == Accept.Yes)
                {
                    lst.AllowDrop = t.AllowDrop = true;
                    Invalidate();
                }
                else
                {
                    lst.AllowDrop = t.AllowDrop = false;
                    Invalidate();
                }
            }
        }
        public PanelDragandDrop()
        {
            Text = "Text && List";
            t = new TextBox();
            lst = new ListBox();
            t.Size = new Size(80, 50);
            lst.Size = new Size(80, 100);
            t.Location = new Point(10, 50);
            lst.Location = new Point(100, 10);
            t.MouseDown += TakeData;
            lst.DragEnter += EffectDrag;
            lst.DragDrop += PutData;
            AcceptDragDrop = Accept.Yes; 
            lst.MouseDown += TakeData2;
            t.DragEnter += EffectDrag;
            t.DragDrop += PutData2;


            Controls.AddRange(new Control[] { t, lst });
        }

        void TakeData(object s, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (t.SelectedText != "")
                {
                    DoDragDrop(t.SelectedText, DragDropEffects.Copy);
                }
            }
        }

        void PutData(object s, DragEventArgs e)
        {
            lst.Items.Add((string)e.Data.GetData(typeof(string)));
        }


        void EffectDrag(object s, DragEventArgs e)
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

        void TakeData2(object s, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lst.SelectedIndex != -1)
                {
                    DoDragDrop(lst.SelectedItem, DragDropEffects.Copy);
                }
            }
        }
        void PutData2(object s, DragEventArgs e)
        {
            t.Text = (string)e.Data.GetData(typeof(string));
        }
    }
}
