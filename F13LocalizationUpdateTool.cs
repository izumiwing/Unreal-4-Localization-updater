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

namespace FTH13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();
            fbd.Filter = "Decompiled Locres|*.txt";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = fbd.FileName;
                if (fbd.ShowDialog() == DialogResult.OK) {
                    this.textBox2.Text = fbd.FileName;
                    if (fbd.ShowDialog() == DialogResult.OK) {
                        this.textBox3.Text = fbd.FileName;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox4.Visible = true;
                string[] source_a, new_a, old_a;
                textBox4.AppendText("\r\n Created string Array cache."); 
                source_a = File.ReadAllLines(textBox1.Text, Encoding.UTF8);
                old_a = File.ReadAllLines(textBox2.Text, Encoding.UTF8);
                new_a = File.ReadAllLines(textBox3.Text, Encoding.UTF8);
                textBox4.AppendText("\r\n Reading text from selected file."); 
                String[] newTranslation = new string[new_a.GetLength(0)];
                textBox4.AppendText("\r\n Created output string data."); 
                int loop = -1;
                foreach (string i in new_a)
                {
                    textBox4.AppendText("\r\n A text Found in new version translation."); 
                    string result = i;
                    loop = loop + 1;
                    int loop_ = -1;
                    foreach (string i_ in old_a)
                    {
                        loop_ = loop_ + 1;
                        if (i == i_)
                        {
                            textBox4.AppendText("\r\n A text was Found in old version is same as new version of this text."); 
                            result = source_a[loop_];
                            break;
                        }
                    }
                    newTranslation[loop] = result;
                }
                textBox4.AppendText("\r\n Ready to write stream."); 
                string newTranslation_str = "";
                foreach (string i__ in newTranslation)
                {
                    textBox4.AppendText("\r\n A text is added to stream."); 
                    newTranslation_str = newTranslation_str + i__ + "\r\n";
                }
                textBox4.AppendText("\r\n Writing stream."); 
                File.WriteAllText("new.txt", newTranslation_str);
            }
            else 
            {
                textBox4.Visible = false;
                string[] source_a, new_a, old_a;
                source_a = File.ReadAllLines(textBox1.Text, Encoding.UTF8);
                old_a = File.ReadAllLines(textBox2.Text, Encoding.UTF8);
                new_a = File.ReadAllLines(textBox3.Text, Encoding.UTF8);
                String[] newTranslation = new string[new_a.GetLength(0)];
                int loop = -1;
                foreach (string i in new_a)
                {
                    string result = i;
                    loop = loop + 1;
                    int loop_ = -1;
                    foreach (string i_ in old_a)
                    {
                        loop_ = loop_ + 1;
                        if (i == i_)
                        {
                            result = source_a[loop_];
                            break;
                        }
                    }
                    newTranslation[loop] = result;
                }
                string newTranslation_str = "";
                foreach (string i__ in newTranslation)
                {
                    newTranslation_str = newTranslation_str + i__ + "\r\n";
                }
                File.WriteAllText("new.txt", newTranslation_str);
            }

        }

    }
}
