using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Enviroment
{
    class MainForm : Form
    {
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem newItem, openItem, saveItem, saveAsItem, exitItem;
        private ToolStripMenuItem editMenu;
        private ToolStripMenuItem undoItem, cutItem, copyItem, pasteItem, selectAllItem;
        private ToolStripMenuItem formatMenu, fontItem;
        private ToolStripMenuItem ToggleMode;
        private ToolStripMenuItem DarkMode, LightMode;
        private RichTextBox textBox;
        private Label statusLabel;
        private string currentFilePath = string.Empty;
        public MainForm()
        {
            this.Text = "Enviroment";
            this.Width = 800;
            this.Height = 600;

            textBox = new RichTextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 12),
                EnableAutoDragDrop = true
            };
            textBox.TextChanged += TextBox_TextChanged;
            this.Controls.Add(textBox);

            menuStrip = new MenuStrip();

            fileMenu = new ToolStripMenuItem("File");
            newItem = new ToolStripMenuItem("New", null, OnNew);
            openItem = new ToolStripMenuItem("Open", null, OnOpen);
            saveItem = new ToolStripMenuItem("Save", null, OnSave);
            saveAsItem = new ToolStripMenuItem("Save As", null, OnSaveAs);
            exitItem = new ToolStripMenuItem("Exit", null, (s, e) => this.Close());

            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { newItem, openItem, saveItem, saveAsItem, new ToolStripSeparator(), exitItem });
            menuStrip.Items.Add(fileMenu);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            statusLabel = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 25,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
                BackColor = SystemColors.Control
            };
            this.Controls.Add(statusLabel);


            // إنشاء قائمة Edit
            editMenu = new ToolStripMenuItem("Edit");

            undoItem = new ToolStripMenuItem("Undo", null, (s, e) => textBox.Undo());
            cutItem = new ToolStripMenuItem("Cut", null, (s, e) => textBox.Cut());
            copyItem = new ToolStripMenuItem("Copy", null, (s, e) => textBox.Copy());
            pasteItem = new ToolStripMenuItem("Paste", null, (s, e) => textBox.Paste());
            selectAllItem = new ToolStripMenuItem("Select All", null, (s, e) => textBox.SelectAll());

            editMenu.DropDownItems.AddRange(new ToolStripItem[]
            {
               undoItem,new ToolStripSeparator(),cutItem, copyItem, pasteItem,
                new ToolStripSeparator(),selectAllItem
            });
            menuStrip.Items.Add(editMenu);

            formatMenu = new ToolStripMenuItem("Format");
            fontItem = new ToolStripMenuItem("Font", null, OnChangeFont);

            formatMenu.DropDownItems.Add(fontItem);
            menuStrip.Items.Add(formatMenu);

            ToolStripMenuItem styleMenu = new ToolStripMenuItem("Style");
            ToolStripMenuItem boldItem = new ToolStripMenuItem("Bold", null, OnBold);
            ToolStripMenuItem italicItem = new ToolStripMenuItem("Italic", null, OnItalic);
            ToolStripMenuItem underlineItem = new ToolStripMenuItem("Underline", null, OnUnderline);

            styleMenu.DropDownItems.AddRange(new ToolStripItem[] { boldItem, italicItem, underlineItem });
            menuStrip.Items.Add(styleMenu);


            ToggleMode = new ToolStripMenuItem("Toggle Mode");
            DarkMode = new ToolStripMenuItem("Dark Mode", null, ToggleMode_Click);
            LightMode = new ToolStripMenuItem("Light Mode", null, ToggleMode_Click);

            ToggleMode.DropDownItems.AddRange(new ToolStripItem[]
           {
               DarkMode,LightMode
           });
            menuStrip.Items.Add(ToggleMode);

            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;

            ToolStripMenuItem textColorItem = new ToolStripMenuItem("Text Color", null, OnTextColor);
            ToolStripMenuItem backColorItem = new ToolStripMenuItem("Background Color", null, OnBackColor);
            formatMenu.DropDownItems.Add(textColorItem);
            formatMenu.DropDownItems.Add(backColorItem);

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (textBox.Text.Length > 0)
            {
                char firstChar = textBox.Text[0];
                if ((firstChar >= 'A' && firstChar <= 'Z') || (firstChar >= 'a' && firstChar <= 'z'))
                {
                    textBox.RightToLeft = RightToLeft.No;
                }
                else
                {
                    textBox.RightToLeft = RightToLeft.Yes;
                }
            }

            int wordCount = textBox.Text.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
            int lineCount = textBox.Lines.Length;
            statusLabel.Text = $"Words: {wordCount}  |  Lines: {lineCount}";
        }
        private void OnNew(object sender, EventArgs e)
        {
            textBox.Clear();
            currentFilePath = string.Empty;
        }
        private void OnOpen(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = File.ReadAllText(ofd.FileName);
                    currentFilePath = ofd.FileName;
                }
            }
        }
        private void OnSave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                File.WriteAllText(currentFilePath, textBox.Text);
            }
            else
            {
                OnSaveAs(sender, e);
            }
        }
        private void OnSaveAs(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, textBox.Text);
                    currentFilePath = sfd.FileName;
                }
            }
        }
        private void OnChangeFont(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                fontDialog.Font = textBox.Font;
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox.Font = fontDialog.Font;
                }
            }
        }

        private void OnBold(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold);
        }

        private void OnItalic(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic);
        }

        private void OnUnderline(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Underline);
        }

        private void ToggleFontStyle(FontStyle style)
        {
            if (textBox.SelectionFont != null)
            {
                Font currentFont = textBox.SelectionFont;
                FontStyle newStyle;

                if (currentFont.Style.HasFlag(style))
                    newStyle = currentFont.Style & ~style;
                else
                    newStyle = currentFont.Style | style;

                textBox.SelectionFont = new Font(currentFont, newStyle);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S && !e.Shift)
            {
                OnSave(sender, e);
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.S)
            {
                OnSaveAs(sender, e);
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                OnOpen(sender, e);
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                OnChangeFont(sender, e);
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                textBox.SelectAll();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                OnNew(sender, e);
                e.SuppressKeyPress = true;
            }
        }
        private void ToggleMode_Click(object sender, EventArgs e)
        {
            if (sender == DarkMode)
            {
                this.BackColor = Color.FromArgb(30, 30, 30); // لون خلفية الفورم
                menuStrip.BackColor = Color.FromArgb(45, 45, 45); // خلفية القوائم
                menuStrip.ForeColor = Color.White; // لون النص في القوائم

                foreach (ToolStripMenuItem item in menuStrip.Items)
                {
                    item.ForeColor = Color.White;
                    item.BackColor = Color.FromArgb(45, 45, 45);
                }

                textBox.BackColor = Color.FromArgb(45, 45, 45);
                textBox.ForeColor = Color.White;

            }
            else if (sender == LightMode)
            {
                this.BackColor = SystemColors.Control;
                menuStrip.BackColor = SystemColors.Control;
                menuStrip.ForeColor = Color.Black;

                foreach (ToolStripMenuItem item in menuStrip.Items)
                {
                    item.ForeColor = Color.Black;
                    item.BackColor = SystemColors.Control;
                }

                textBox.BackColor = Color.White;
                textBox.ForeColor = Color.Black;

            }
        }

        private void OnTextColor(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox.SelectionColor = colorDialog.Color;
                }
            }
        }

        private void OnBackColor(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox.SelectionBackColor = colorDialog.Color;
                }
            }
        }

    }
}
