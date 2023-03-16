using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace lab1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        
        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
         Dictionary<char, char> k = new Dictionary<char, char> { };
        private void button5_Click(object sender, EventArgs e)
        {
            char[] a = new char[26];
            char[] b = new char[26];
            for (int i = 97; i < 123; i++)
            {
                a[i - 97] = Convert.ToChar(i);
                b[i - 97] = Convert.ToChar(i);
            }
            char[] x = new char[33];
            char[] y = new char[33];
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
           y[0] = 'й';
            y[1] = 'ц';
            y[2] = 'у';
            y[3] = 'к';
            y[4] = 'е';
            y[5] = 'н';
            y[6] = 'г';
            y[7] = 'ґ';
            y[8] = 'ш';
            y[9] = 'щ';
            y[10] = 'з';
            y[11] = 'х';
            y[12] = 'ї';
            y[13] = 'ф';
            y[14] = 'і';
            y[15] = 'в';
            y[16] = 'а';
            y[17] = 'п';
            y[18] = 'р';
            y[19] = 'о';
            y[20] = 'л';
            y[21] = 'д';
            y[22] = 'ж';
            y[23] = 'є';
            y[24] = 'я';
            y[25] = 'ч';
            y[26] = 'с';
            y[27] = 'м';
            y[28] = 'и';
            y[29] = 'т';
            y[30] = 'ь';
            y[31] = 'б';
            y[32] = 'ю';
            Array.Sort(x);
            Array.Sort(y);
            k.Clear();
            int n = 26;
            for(int i=0;i<26;i++)
            {
                Random r = new Random();
                int l = r.Next(0, n);
                k.Add(a[l], b[i]);
                char f = a[l];
                a[l] = a[n - 1];
                a[n - 1] = f;
                n--;
            }
            n = 33;
            for (int i = 0; i < 33; i++)
            {
                Random r = new Random();
                int l = r.Next(0, n);
                k.Add(x[l], y[i]);
                char f = x[l];
                x[l] = x[n - 1];
                x[n - 1] = f;
                n--;

            }
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Letter";
            column1.Name = "letter";
            column1.CellTemplate = new DataGridViewTextBoxCell();
            column1.SortMode = DataGridViewColumnSortMode.Automatic;

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Substitute";
            column2.Name = "substitute";
            column2.CellTemplate = new DataGridViewTextBoxCell();
            column2.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            foreach (KeyValuePair<char, char> i in k)
            {
                dataGridView1.Rows.Add(i.Key.ToString(), i.Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Stream f = saveFileDialog1.OpenFile();
            StreamWriter rx = new StreamWriter(f);
            foreach (KeyValuePair<char, char> i in k)
            {
                string z = i.Key.ToString() + "," + i.Value.ToString();
                rx.WriteLine(z);
            }
            rx.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            StringBuilder v = new StringBuilder();
            
            for(int i=0;i<s.Length;i++)
            {
                v.Append(k[s[i]].ToString());
            }
            richTextBox2.Text = v.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            k.Clear();
            Dictionary<char, char> k1 = new Dictionary<char, char> { };
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Stream f = openFileDialog1.OpenFile();
            StreamReader rx = new StreamReader(f);
            string[] s = rx.ReadToEnd().Split('\n');
            for (int i = 0; i < s.Length - 1; i++)
            {
                s[i] = s[i].Replace('\r', ' ');
                k.Add(Convert.ToChar(s[i][0]), Convert.ToChar(s[i][2]));
                k1.Add(Convert.ToChar(s[i][2]), Convert.ToChar(s[i][0]));
            }
            string x = richTextBox1.Text;
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Letter";
            column1.Name = "letter";
            column1.CellTemplate = new DataGridViewTextBoxCell();
            column1.SortMode = DataGridViewColumnSortMode.Automatic;

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Substitute";
            column2.Name = "substitute";
            column2.CellTemplate = new DataGridViewTextBoxCell();
            column2.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            foreach (KeyValuePair<char, char> i in k)
            {
                dataGridView1.Rows.Add(i.Key.ToString(), i.Value.ToString());
            }
            StringBuilder v = new StringBuilder();

            for (int i = 0; i < x.Length; i++)
            {
                v.Append(k1[x[i]].ToString());
            }
            richTextBox2.Text = v.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if( openFileDialog1.ShowDialog()==DialogResult.Cancel )
            {
                return;
            }
            Stream f = openFileDialog1.OpenFile();
            StreamReader rx = new StreamReader(f);
            richTextBox1.Text = rx.ReadToEnd();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Stream f = saveFileDialog1.OpenFile();
            StreamWriter rx = new StreamWriter(f);
            rx.Write(richTextBox2.Text);
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            dataGridView1.Height = Convert.ToInt32(0.8 * this.Height);
            dataGridView1.Width = Convert.ToInt32(0.2 * this.Width);
            richTextBox1.Height = Convert.ToInt32(0.8 * this.Height);
            richTextBox1.Width = Convert.ToInt32(0.35 * this.Width);
            richTextBox2.Width = Convert.ToInt32(0.35*this.Width);
            richTextBox2.Height = Convert.ToInt32(0.8*this.Height);
            richTextBox1.Location = new Point(button1.Location.X, button5.Location.Y + button5.Height + 10);
            dataGridView1.Location = new Point(richTextBox1.Location.X + richTextBox1.Width + 10, button6.Location.Y + button6.Height + 10);
            richTextBox2.Location = new Point(dataGridView1.Location.X+dataGridView1.Width+10,button7.Location.Y+10+button7.Height);
            button1.Width = Convert.ToInt32(0.13 * this.Width);
            button2.Width = Convert.ToInt32(0.13 * this.Width);
            button3.Width = Convert.ToInt32(0.13 * this.Width);
            button4.Width = Convert.ToInt32(0.13 * this.Width);
            button5.Width = Convert.ToInt32(0.13 * this.Width);
            button6.Width = Convert.ToInt32(0.13 * this.Width);
            button7.Width = Convert.ToInt32(0.13*this.Width);
            button1.Location = new Point(button1.Location.X, 5);
            button2.Location = new Point(button1.Location.X + button1.Width, 5);
            button3.Location = new Point(button2.Location.X + button2.Width, 5);
            button4.Location = new Point(button3.Location.X + button3.Width, 5);
            button5.Location = new Point(button4.Location.X + button4.Width, 5);
            button6.Location = new Point(button5.Location.X + button5.Width, 5);
            button7.Location = new Point(button6.Location.X + button6.Width, 5);
        }
    }
}
