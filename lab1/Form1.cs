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

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Dictionary<char, double> chars = new Dictionary<char, double> { };
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string s = richTextBox1.Text;
            s = s.ToLower();  
            s = s.Replace('"',' ');
            s = s.Replace(" ", "");
            s = s.Replace(")", "");
            s = s.Replace("(", "");
            s = s.Replace(",", "");
            s = s.Replace(".", "");
            s = s.Replace("!", "");
            s = s.Replace("?", "");
            s = s.Replace("-", "");
            s = s.Replace("'", "");
            s = s.Replace("1", "");
            s = s.Replace("2", "");
            s = s.Replace("3", "");
            s = s.Replace("4", "");
            s = s.Replace("5", "");
            s = s.Replace("6", "");
            s = s.Replace("7", "");
            s = s.Replace("8", "");
            s = s.Replace("9", "");
            s = s.Replace("0", "");
            s = s.Replace("\n", "");
            s = s.Replace("'", "");
            s = s.Replace("*", "");
            s = s.Replace(":", "");
            s = s.Replace(";", "");
            s = s.Replace("/", ""); 
         
            for (int i=0;i<s.Length;i++)
            {
                if (chars.ContainsKey(s[i]))
                {
                    chars[s[i]] += 1;
                }
                else
                {
                    chars.Add (s[i], 1);
                }
            }
            
            for (int i = 97; i <123 ; i++)
            {
                if (chars.ContainsKey(Convert.ToChar(i)))
                {
                    chars[Convert.ToChar(i)] = chars[Convert.ToChar(i)] / s.Length ;
                }
                else
                {
                    chars.Add(Convert.ToChar(i), 0);
                }
            }
            chars = chars.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

            string z = "";
            foreach (KeyValuePair<char, double> i in chars)
            {
                dataGridView1.Rows.Add(i.Key, i.Value);
                z += i.Key.ToString() + " " + i.Value.ToString() + '\n';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            chars.Clear();
            string s = richTextBox1.Text;
            s = s.ToLower();
            s = s.Replace('"', ' ');
            s = s.Replace(" ", "");
            s = s.Replace(")", "");
            s = s.Replace("(", "");
            s = s.Replace(",", "");
            s = s.Replace(".", "");
            s = s.Replace("!", "");
            s = s.Replace("?", "");
            s = s.Replace("-", "");
            s = s.Replace("'", "");
            s = s.Replace("1", "");
            s = s.Replace("2", "");
            s = s.Replace("3", "");
            s = s.Replace("4", "");
            s = s.Replace("5", "");
            s = s.Replace("6", "");
            s = s.Replace("7", "");
            s = s.Replace("8", "");
            s = s.Replace("9", "");
            s = s.Replace("0", "");
            s = s.Replace("\n", "");
            s = s.Replace("'", "");
            s = s.Replace("*", "");
            s = s.Replace(":", "");
            s = s.Replace(";", "");
            s = s.Replace("/", "");
            
            for (int i = 0; i < s.Length; i++)
            {
                if (chars.ContainsKey(s[i]))
                {
                    chars[s[i]] += 1;
                }
                else
                {
                    chars.Add(s[i], 1);
                }
            }
            char[] x = new char[33];
            x[0] = 'й';
            x[1] = 'ц';
            x[2] = 'у';
            x[3] = 'к';
            x[4] = 'е';
            x[5] = 'н';
            x[6] = 'г';
            x[7] = 'ґ';
            x[8] = 'ш';
            x[9] = 'щ';
            x[10] = 'з';
            x[11] = 'х';
            x[12] = 'ї';
            x[13] = 'ф';
            x[14] = 'і';
            x[15] = 'в';
            x[16] = 'а';
            x[17] = 'п';
            x[18] = 'р';
            x[19] = 'о';
            x[20] = 'л';
            x[21] = 'д';
            x[22] = 'ж';
            x[23] = 'є';
            x[24] = 'я';
            x[25] = 'ч';
            x[26] = 'с';
            x[27] = 'м';
            x[28] = 'и';
            x[29] = 'т';
            x[30] = 'ь';
            x[31] = 'б';
            x[32] = 'ю';
            foreach (char i in x)
            {
                if (chars.ContainsKey(i))
                {
                    chars[i] = chars[i] / s.Length;
                }
                else
                {
                    chars.Add(i, 0);
                }
            }

            chars = chars.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            
            string z = "";
            foreach (KeyValuePair<char, double> i in chars)
            {
                dataGridView1.Rows.Add(i.Key,i.Value);
                z += i.Key.ToString() + " " + i.Value.ToString() + '\n';
            }
           

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Stream f = saveFileDialog1.OpenFile();
            StreamWriter rx = new StreamWriter(f);
            foreach (KeyValuePair<char, double> i in chars)
            {
                string z = i.Key.ToString() + " " + i.Value.ToString();
                rx.WriteLine(z);
            }
            rx.Close();
            label1.Text = "Table saved";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Stream f = openFileDialog1.OpenFile();
            StreamReader rw = new StreamReader(f);
            richTextBox1.Text = rw.ReadToEnd();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Stream f = openFileDialog1.OpenFile();
            StreamReader rw = new StreamReader(f);
            string[] s=rw.ReadToEnd().Split('\n');
            for( int i=0; i< s.Length;i++)
            {
                string[] vs = s[i].Split(" ");
                richTextBox1.Text=vs[0];
                dataGridView1.Rows.Add(vs[0],vs[1]);
               
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            dataGridView1.Height=Convert.ToInt32(0.6*this.Height);
            dataGridView1.Width = Convert.ToInt32(0.3*this.Width);
            richTextBox1.Height = Convert.ToInt32(0.6 * this.Height);
            richTextBox1.Width= Convert.ToInt32(0.65 * this.Width);
            richTextBox1.Location=new Point(button5.Location.X,button5.Location.Y+button5.Height+10);
            dataGridView1.Location=new Point(richTextBox1.Location.X+ richTextBox1.Width+10, button6.Location.Y+button6.Height+10);
            button5.Width= Convert.ToInt32(0.15 *this.Width);
            button1.Width = Convert.ToInt32(0.15 * this.Width);
            button2.Width = Convert.ToInt32(0.15 * this.Width);
            button3.Width = Convert.ToInt32(0.15 * this.Width);
            button4.Width = Convert.ToInt32(0.15 * this.Width);
            button6.Width = Convert.ToInt32(0.15 * this.Width);
            button5.Location = new Point(button5.Location.X,5);
            button2.Location = new Point(button5.Location.X+ button5.Width,5);
            button1.Location = new Point(button2.Location.X + button2.Width, 5);
            button4.Location = new Point(button1.Location.X + button1.Width, 5);
            button6.Location = new Point(button4.Location.X + button4.Width, 5);
            button3.Location = new Point(button6.Location.X + button6.Width, 5);
        }
    }
}
