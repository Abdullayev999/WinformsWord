using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            fontSizeToolStripComboBox2.SelectedIndex = 0;
            
        }

        private void colorToolStripButton_Click(object sender, EventArgs e)
        {
            var dialog= new ColorDialog();
            var result=dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                richTextBox1.SelectionColor=dialog.Color;
                colorToolStripButton.Text = dialog.Color.Name.ToString();

                Bitmap bmp=new Bitmap(100,100);
                Graphics g=Graphics.FromImage(bmp);
                g.Clear(dialog.Color);

                colorToolStripButton.Image = bmp;
            }
           
        }

        private void fontToolStripButton_Click(object sender, EventArgs e)
        {
            var dialog=new FontDialog();
            var result= dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                richTextBox1.SelectionFont = dialog.Font;
                fontToolStripButton.Text = dialog.Font.Name;
            }
        }

        private void fontSizeToolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          var fontSize=float.Parse(fontSizeToolStripComboBox2.SelectedItem.ToString());
          var font = new Font(richTextBox1.Font.FontFamily,fontSize);
          richTextBox1.SelectionFont = font;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tXTFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var text=richTextBox1.Text;
            var dialog=new SaveFileDialog();
            dialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            var result=dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, text);
            }
        }

        private void rTFFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var text = richTextBox1.Rtf;
            var dialog = new SaveFileDialog();
            dialog.Filter = "RTF file (*.rtf)|*.rtf|All files (*.*)|*.*";
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Text file (*.rtf,*.txt)|*.rtf;*.txt|All files (*.*)|*.*";
            var result=dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var text = File.ReadAllText(dialog.FileName);
                if (Path.GetExtension(dialog.FileName)==".txt")
                {
                    richTextBox1.Text = text;
                }else if (Path.GetExtension(dialog.FileName) == ".rtf")
                {
                    richTextBox1.Rtf = text;
                }
                else
                {
                    MessageBox.Show("Invalide file format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }


        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
