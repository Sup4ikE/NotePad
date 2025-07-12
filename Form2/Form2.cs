using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_Pro
{
    public partial class Form2 : Form
    {
        private RichTextBox _richTextBox;
        private bool ukrEng;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(bool UrkEng, RichTextBox RichTextBox)
        {
            InitializeComponent();

            ukrEng = UrkEng;
            _richTextBox = RichTextBox;

            if (ukrEng == true)
            {
                button1.Text = "Знайти";
                button2.Text = "Замінити";
            }
            if (ukrEng == false)
            {
                button1.Text = "Find";
                button2.Text = "Replace";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string word = textBox1.Text;

                int startIndex = 0;
                _richTextBox.SelectionBackColor = _richTextBox.BackColor;

                while ((startIndex = _richTextBox.Text.IndexOf(word, startIndex, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    _richTextBox.Select(startIndex, word.Length);
                    _richTextBox.SelectionBackColor = Color.Yellow;
                    startIndex += word.Length;
                }
            }
            else 
            {
                if (ukrEng == true)
                {
                    MessageBox.Show("Перше поле має бути заповнене!");
                }
                if (ukrEng == false)
                {
                    MessageBox.Show("The first field must be filled!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string word = textBox1.Text;
                string newWord = textBox2.Text;

                int startIndex = 0;
                _richTextBox.SelectionBackColor = _richTextBox.BackColor;

                while ((startIndex = _richTextBox.Text.IndexOf(word, startIndex, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    _richTextBox.Select(startIndex, word.Length);
                    _richTextBox.SelectedText = newWord;
                    startIndex += word.Length;
                }
            }
            else 
            {
                if (ukrEng == true)
                {
                    MessageBox.Show("Обидва поля мають бути заповнені!");
                }
                if (ukrEng == false)
                {
                    MessageBox.Show("Both fields must be filled!");
                }
            }
        }
    }
}
