using System.Configuration;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Notepad_Pro
{
    public partial class Form1 : Form
    {
        public bool UkrEng = true;

        public int countC = 0;

        public Form1()
        {
            InitializeComponent();
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            notifyIcon1.Visible = false;
            richTextBox1.DetectUrls = true;
        }


        // Basic menu
        // Файл
        private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "All Files(*.*)|*.*|TextFile(*.txt)|*.txt||";
            openFileDialog1.FilterIndex = 2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }
        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                StreamWriter sw = new StreamWriter(openFileDialog1.FileName);
                sw.Write(richTextBox1.Text);
                sw.Close();
            }
            else
            {
                зберегтиЯкToolStripMenuItem_Click(sender, e);
            }
        }
        private void зберегтиЯкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "file";
            saveFileDialog1.Filter = "All Files(*.*)|*.*|TextFile(*.txt)|*.txt||";
            saveFileDialog1.FilterIndex = 2;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.Write(richTextBox1.Text);
                sw.Close();
            }
        }
        private void зберегтиЯкToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Поки що недоступно | Not available yet");
        }
        private void попереднToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(richTextBox1.Text);
        }
        private void друкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Поки що недоступно | Not available yet");
        }
        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Правка
        private void вирізатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        private void копіюватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }
        private void зробитиТекстЗахищенимToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionProtected = true;
        }
        private void зробитиВесьТекстНезахищенимToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionProtected = false;
        }
        private void вставитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }
        private void виділитиВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }
        private void відмінитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }


        // Формат
        private void colibriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("Calibri", richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
        }
        private void verdanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("Verdana", richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
        }
        private void timesNewRomanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("Times New Roman", richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
        }
        private void arialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("Arial", richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
        }
        private void arialbasicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Red;
        }
        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Blue;
        }
        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Green;
        }
        private void pinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Pink;
        }
        private void basicblackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Black;
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, FontStyle.Bold);
        }
        private void cursedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, FontStyle.Italic);
        }
        private void emphaticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, FontStyle.Underline);
        }
        private void crossedOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, FontStyle.Strikeout);
        }
        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, FontStyle.Regular);
        }

        private void зліваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }
        private void поЦентруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }
        private void справаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }


        //Пошук
        private void пошукToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(UkrEng, richTextBox1);
            form2.Show();
        }


        // Довідка
        private void інформаціяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About Notepad Program\r\nVersion: 10.0.18363 (or another version number depending on your operating system)\r\nLicense: Owned by Microsoft Corporation. All rights reserved.\r\nProgram authors: Microsoft Corporation.\r\nOperating system: Windows 10 (or another version of Windows).");
        }
        private void підтримкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("https://support.microsoft.com");
        }


        // Мова
        private void уркаїнськаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            файлToolStripMenuItem.Text = "Файл";
            створитиToolStripMenuItem.Text = "Створити";
            відкритиToolStripMenuItem.Text = "Відкрити";
            зберегтиToolStripMenuItem.Text = "Зберегти";
            зберегтиЯкToolStripMenuItem.Text = "Зберегти як";
            зберегтиЯкToolStripMenuItem1.Text = "Параметри сторінки";
            попереднToolStripMenuItem.Text = "Попередній перегляд";
            друкToolStripMenuItem.Text = "Друк";
            вихідToolStripMenuItem.Text = "Вихід";

            правкаToolStripMenuItem.Text = "Правка";
            відмінитиToolStripMenuItem.Text = "Відмінити";
            вирізатиToolStripMenuItem.Text = "Вирізати";
            копіюватиToolStripMenuItem.Text = "Копіювати";
            зробитиТекстЗахищенимToolStripMenuItem.Text = "Зробити текст захищеним";
            зробитиВесьТекстНезахищенимToolStripMenuItem.Text = "Зробити текст незахищеним";
            вставитиToolStripMenuItem.Text = "Вставити";
            видалитиToolStripMenuItem.Text = "Видалити";
            виділитиВсеToolStripMenuItem.Text = "Виділити все";

            форматToolStripMenuItem.Text = "Формат";
            шрифтToolStripMenuItem.Text = "Шрифт";
            basicblackToolStripMenuItem.Text = "Звичайний";
            колірToolStripMenuItem.Text = "Колір";
            redToolStripMenuItem.Text = "Червоний";
            blueToolStripMenuItem.Text = "Голубий";
            greenToolStripMenuItem.Text = "Зелений";
            pinkToolStripMenuItem.Text = "Рожевий";
            basicblackToolStripMenuItem.Text = "Звичайний(чорний)";

            стильСимволівToolStripMenuItem.Text = "Стиль символів";
            boldToolStripMenuItem.Text = "Напівжирий";
            cursedToolStripMenuItem.Text = "Курсив";
            emphaticToolStripMenuItem.Text = "Підкреслений";
            crossedOutToolStripMenuItem.Text = "Закреслений";
            defaultToolStripMenuItem.Text = "Звичайний";

            вирівнюванняToolStripMenuItem.Text = "Вирівнювання";
            зліваToolStripMenuItem.Text = "Зліва";
            поЦентруToolStripMenuItem.Text = "По центру";
            справаToolStripMenuItem.Text = "Справа";

            пошукToolStripMenuItem.Text = "Пошук";
            довідкаToolStripMenuItem.Text = "Довідка";
            інформаціяToolStripMenuItem.Text = "Про NotePad";
            підтримкаToolStripMenuItem.Text = "Підтримка";

            моваToolStripMenuItem.Text = "Мова";
            уркаїнськаToolStripMenuItem.Text = "Українська";
            англійськаToolStripMenuItem.Text = "Англійська";

            toolStripStatusLabel1.Text = "Кількість символів:";
            toolStripStatusLabel3.Text = "Кількість рядків:";

            toolStripSplitButton1.Text = "Шрифт";
            toolStripDropDownButton1.Text = "Розмір тексту";

            червонийToolStripMenuItem.Text = "Червоний";
            голубийToolStripMenuItem.Text = "Голубий";
            зеленийToolStripMenuItem.Text = "Зелений";
            рожевийToolStripMenuItem.Text = "Рожевий";
            звичайнийчорнийToolStripMenuItem.Text = "Звичайний(чорний)";

            перетянітьСюдиФайлToolStripMenuItem.Text = "Перетяніть сюди файл";

            UkrEng = true;
        }

        private void англійськаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            файлToolStripMenuItem.Text = "File";
            створитиToolStripMenuItem.Text = "Create";
            відкритиToolStripMenuItem.Text = "Open";
            зберегтиToolStripMenuItem.Text = "Save";
            зберегтиЯкToolStripMenuItem.Text = "Save As";
            зберегтиЯкToolStripMenuItem1.Text = "Page Setup";
            попереднToolStripMenuItem.Text = "Preview";
            друкToolStripMenuItem.Text = "Print";
            вихідToolStripMenuItem.Text = "Exit";

            правкаToolStripMenuItem.Text = "Edit";
            відмінитиToolStripMenuItem.Text = "Undo";
            вирізатиToolStripMenuItem.Text = "Cut";
            копіюватиToolStripMenuItem.Text = "Copy";
            зробитиТекстЗахищенимToolStripMenuItem.Text = "Make text protected";
            зробитиВесьТекстНезахищенимToolStripMenuItem.Text = "Make text unprotected";
            вставитиToolStripMenuItem.Text = "Paste";
            видалитиToolStripMenuItem.Text = "Delete";
            виділитиВсеToolStripMenuItem.Text = "Select All";

            форматToolStripMenuItem.Text = "Format";
            шрифтToolStripMenuItem.Text = "Font";
            basicblackToolStripMenuItem.Text = "Normal";
            колірToolStripMenuItem.Text = "Color";
            redToolStripMenuItem.Text = "Red";
            blueToolStripMenuItem.Text = "Blue";
            greenToolStripMenuItem.Text = "Green";
            pinkToolStripMenuItem.Text = "Pink";
            basicblackToolStripMenuItem.Text = "Default (Black)";

            стильСимволівToolStripMenuItem.Text = "Text Style";
            boldToolStripMenuItem.Text = "Bold";
            cursedToolStripMenuItem.Text = "Italic";
            emphaticToolStripMenuItem.Text = "Underlined";
            crossedOutToolStripMenuItem.Text = "Strikethrough";
            defaultToolStripMenuItem.Text = "Default";

            вирівнюванняToolStripMenuItem.Text = "Alignment";
            зліваToolStripMenuItem.Text = "Left";
            поЦентруToolStripMenuItem.Text = "Center";
            справаToolStripMenuItem.Text = "Right";

            пошукToolStripMenuItem.Text = "Search";
            довідкаToolStripMenuItem.Text = "Help";
            інформаціяToolStripMenuItem.Text = "About NotePad";
            підтримкаToolStripMenuItem.Text = "Support";

            моваToolStripMenuItem.Text = "Language";
            уркаїнськаToolStripMenuItem.Text = "Ukrainian";
            англійськаToolStripMenuItem.Text = "English";

            toolStripStatusLabel1.Text = "Character Count:";
            toolStripStatusLabel3.Text = "Line Count:";

            toolStripSplitButton1.Text = "Type";
            toolStripDropDownButton1.Text = "Text size";

            червонийToolStripMenuItem.Text = "Red";
            голубийToolStripMenuItem.Text = "Blue";
            зеленийToolStripMenuItem.Text = "Green";
            рожевийToolStripMenuItem.Text = "Pink";
            звичайнийчорнийToolStripMenuItem.Text = "Basic(Black)";

            перетянітьСюдиФайлToolStripMenuItem.Text = "Drag file here";

            UkrEng = false;
        }



        // Tool Strip
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "All Files(*.*)|*.*|TextFile(*.txt)|*.txt||";
            openFileDialog1.FilterIndex = 2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "file";
            saveFileDialog1.Filter = "All Files(*.*)|*.*|TextFile(*.txt)|*.txt||";
            saveFileDialog1.FilterIndex = 2;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.Write(richTextBox1.Text);
                sw.Close();
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                StreamWriter sw = new StreamWriter(openFileDialog1.FileName);
                sw.Write(richTextBox1.Text);
                sw.Close();
            }
            else
            {
                зберегтиЯкToolStripMenuItem_Click(sender, e);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Поки що недоступно | Not available yet");
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(UkrEng, richTextBox1);
            form2.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void червонийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Red;
        }
        private void голубийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Blue;
        }
        private void зеленийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Green;
        }
        private void рожевийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Pink;
        }
        private void звичайнийчорнийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Black;
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Поки що недоступно | Not available yet");
        }
        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Поки що недоступно | Not available yet");
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, FontStyle.Bold);
        }
        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, FontStyle.Italic);
        }
        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, FontStyle.Underline);
        }

        private void calibriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("Calibri", richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
        }
        private void verdanaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("Verdana", richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
        }
        private void timesNewRomanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("Times New Roman", richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
        }
        private void arialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("Arial", richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
        }
        private void basicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, 8, richTextBox1.SelectionFont.Style);
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, 12, richTextBox1.SelectionFont.Style);
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, 14, richTextBox1.SelectionFont.Style);
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, 16, richTextBox1.SelectionFont.Style);
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, 18, richTextBox1.SelectionFont.Style);
        }



        // Status Strip

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (UkrEng == true)
            {
                toolStripStatusLabel1.Text = $"Символи: {richTextBox1.Text.Length}";
                toolStripStatusLabel3.Text = $"Рядки: {richTextBox1.Lines.Length}";
            }
            if (UkrEng == false)
            {
                toolStripStatusLabel1.Text = $"Characters: {richTextBox1.Text.Length}";
                toolStripStatusLabel3.Text = $"Lines: {richTextBox1.Lines.Length}";
            }
        }



        // Trey

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.Text = "NotePad Pro";
                notifyIcon1.BalloonTipTitle = "NotePad Pro";
                notifyIcon1.BalloonTipText = "NotePad Pro was closed";
                notifyIcon1.ShowBalloonTip(5000);
            }

            //if (!string.IsNullOrEmpty(openFileDialog1.FileName))
            //{
            //    StreamWriter sw = new StreamWriter(openFileDialog1.FileName);
            //    sw.Write(richTextBox1.Text);
            //    sw.Close();
            //}
            //else
            //{
            //    зберегтиЯкToolStripMenuItem_Click(sender, e);
            //}
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }



        // Link

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = e.LinkText,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося відкрити посилання: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Form close (review or closed file)

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                string text = richTextBox1.Text;

                if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    StreamReader sw = new StreamReader(openFileDialog1.FileName);

                    if (sw.ReadToEnd() == text)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        if (UkrEng == true)
                        {
                            MessageBox.Show("Ви не зберегли файл");
                        }
                        else if (UkrEng == false)
                        {
                            MessageBox.Show("You don't save file");
                        }
                        e.Cancel = true;
                    }
                    sw.Close();
                }
            }
        }



        // DragAndDrop
        private void Form1_Load(object sender, EventArgs e)
        {
            AllowDrop = true;

            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 5000;
            timer1.Tick += TitleResetTimer_Tick;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                foreach (string filePath in fileList)
                {
                    try
                    {
                        string text = File.ReadAllText(filePath);
                        richTextBox1.AppendText(text + Environment.NewLine);

                        string fileName = Path.GetFileName(filePath);

                        this.Text = $"NodePad Pro | {fileName}";

                        timer1.Stop();
                        timer1.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при читанні файлу: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Text = "NodePad Pro";
        }

        private void TitleResetTimer_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Text = "NodePad Pro";
        }

    }
}
