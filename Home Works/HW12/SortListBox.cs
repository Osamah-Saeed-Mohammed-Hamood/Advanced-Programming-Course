using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HW12
{
    class SortListBox : ListBox
    {
        private int indexFrom;

        public SortListBox()
        {
            Items.AddRange(new string[] { "Osama", "Saeed", "Mohammed", "Hamood", "Saeed" });
            this.AllowDrop = true;
            this.MouseDown += SortListBox_MouseDown;
            this.DragOver += SortListBox_DragOver;
            this.DragDrop += SortListBox_DragDrop;
        }

        void SortListBox_MouseDown(object s,MouseEventArgs e)
        {
            indexFrom = this.IndexFromPoint(e.Location);
            if (indexFrom >= 0 && indexFrom < Items.Count)
            {
                DoDragDrop(Items[indexFrom], DragDropEffects.Move);
            }
        }
        void SortListBox_DragOver(object s,DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void SortListBox_DragDrop(object s,DragEventArgs e)
        {
            Point point = this.PointToClient(new Point(e.X, e.Y));
            int indexTo = this.IndexFromPoint(point);

            if (indexTo < 0) indexTo = this.Items.Count - 1;
            if (indexTo == indexFrom) return;

            object data = e.Data.GetData(typeof(string));

            this.Items.RemoveAt(indexFrom);
            this.Items.Insert(indexTo, data);
        }
    }
}
