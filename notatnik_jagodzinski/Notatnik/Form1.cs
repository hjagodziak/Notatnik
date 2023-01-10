using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Notatnik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string name;
        private string schowek = "";
        private bool zapisano = false;
        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = openFileDialog1.FileName;
                textBox1.Clear();
                textBox1.Text = File.ReadAllText(name);
            }
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = saveFileDialog1.FileName;
                File.WriteAllText(name + ".txt", textBox1.Text);
                zapisano = true;
            }
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            form1.Location = new Point(this.Location.X + 10, this.Location.Y + 10);
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.Location = new Point(this.Location.X + 10, this.Location.Y + 10);
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zapisano) this.Close();
            else
            {
                DialogResult dialogResult = MessageBox.Show("MASZ NIEZAPISANE ZMIANY, KONTYNUOWAĆ?", "UWAGA", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
        
        private void wytnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schowek = textBox1.SelectedText;
            textBox1.SelectedText = "";
        }

        private void kopiujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schowek = textBox1.SelectedText;
        }

        private void wklejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (schowek != "")
            {
                textBox1.Paste(schowek);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if(zapisano) File.WriteAllText(name + ".txt", textBox1.Text);
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    name = saveFileDialog1.FileName;
                    if (name.EndsWith(".txt")) File.WriteAllText(name, textBox1.Text);
                    else File.WriteAllText(name + ".txt", textBox1.Text);
                    zapisano = true;
                }
            }
        }
    }
}
