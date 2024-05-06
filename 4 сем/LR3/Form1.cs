using System.Diagnostics;
using System.Windows.Forms;

namespace LR2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(new Form2().ShowDialog() == DialogResult.OK)
            {
                var lastItem = Program.owners.Last();
                string fullName = lastItem._FIO.Surname + " " + lastItem._FIO.Name + " " + lastItem._FIO.Patronymic;
                this.listBox1.Items.Add(fullName);

                lastAction = "���������� ���������";
                this.toolStripStatusLabel2.Text = "��������� ��������: " + lastAction;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.label6.Text = this.trackBar1.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Account validate = ValidateAccount();
            if (validate != null)
            {
                Program.accounts.Add(validate);
                this.listBox2.Items.Add(validate.Number);
                toolStripStatusLabel1.Text = $"�������: {Program.accounts.Count}";
                ClearForm();

                lastAction = "�������� �����";
                this.toolStripStatusLabel2.Text = "��������� ��������: " + lastAction;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Program.accounts.Count == 0)
            {
                MessageBox.Show("�������� �� ������� ���� ���� ����!");
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (var fileStream = saveFileDialog1.OpenFile())
                    {
                        xmlSerializer.Serialize(fileStream, Program.accounts);
                    }

                    lastAction = "���������� � ����";
                    this.toolStripStatusLabel2.Text = "��������� ��������: " + lastAction;
                }
                else
                {
                    MessageBox.Show("������ ���������� � ����!");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Program.owners.Clear();
                Program.accounts.Clear();
                this.listBox1.Items.Clear();
                this.listBox2.Items.Clear();

                using (var fileStream = openFileDialog1.OpenFile())
                {
                    Program.accounts = xmlSerializer.Deserialize(fileStream) as List<Account>;
                }

                foreach (var item in Program.accounts)
                {
                    Program.owners.Add(item._Owner);
                    listBox2.Items.Add(item.Number);
                    string fullName = item._Owner._FIO.Surname + " " + item._Owner._FIO.Name + " " + item._Owner._FIO.Patronymic;
                    listBox1.Items.Add(fullName);
                }
                toolStripStatusLabel1.Text = $"�������: {Program.accounts.Count}";

                lastAction = "������ �� �����";
                this.toolStripStatusLabel2.Text = "��������� ��������: " + lastAction;
            }
            else
            {
                MessageBox.Show("������ �������������� �� �����!");
            }   
        }

        private void listBox2_doubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Rectangle selectedRect = listBox2.GetItemRectangle(listBox2.SelectedIndex);

            if (selectedRect.Contains(me.Location))
            {
                Account item = Program.accounts.First(t => t.Number == (int)listBox2.SelectedItem);
                string info = "";
                info += $"����� �����: {item.Number}\n";
                info += $"��� ������: {item.DepositeType}\n";
                info += $"������: {item.Balance}\n";
                info += $"���� ��������: {item.FoundationDate.ToString()}\n";
                info += $"��������: {item._Owner._FIO.ToString()}\n";

                info += $"SMS-����������: ";
                if(item.SMSNotify)
                {
                    info += "��\n";
                }
                else
                {
                    info += "���\n";
                }

                info += $"��������-�������: ";
                if (item.InternetBanking)
                {
                    info += "��\n";
                }
                else
                {
                    info += "���\n";
                }

                MessageBox.Show(info);
            }
        }

        private void listBox1_doubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Rectangle selectedRect = listBox1.GetItemRectangle(listBox1.SelectedIndex);

            if (selectedRect.Contains(me.Location))
            {
                Owner item = Program.owners.First(t => t._FIO.ToString() == (string)listBox1.SelectedItem);
                string info = "";
                info += $"������ ���: {item._FIO.ToString()}\n";
                info += $"���� ��������: {item.BirthDay.ToString()}\n";
                info += $"����� � ����� ���������: {item.Passport.ToString()}\n";
                info += "����������� �����:\n";
                if(Program.accounts.Where(t => t._Owner == item).Count() == 0)
                {
                    info += " - ��� ����������� ������";
                }
                else
                {
                    foreach(var el in Program.accounts)
                    {
                        if(el._Owner == item)
                        {
                            info += $" - {el.Number}\n";
                        }
                    }
                }

                MessageBox.Show(info);
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.example.com") { UseShellExecute = true });
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(this.lightMode)
            {
                this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            }
            else
            {
                this.BackColor = System.Drawing.SystemColors.Control;
            }

            lightMode = !lightMode;
        }

        private void searchByBalance_Click(object sender, EventArgs e)
        {
            new Form3("Balance").ShowDialog();
        }

        private void searchByFIO_Click(object sender, EventArgs e)
        {
            new Form3("FIO").ShowDialog();
        }

        private void searchByType_Click(object sender, EventArgs e)
        {
            new Form3("Type").ShowDialog();
        }

        private void searchByNumber_Click(object sender, EventArgs e)
        {
            new Form3("Number").ShowDialog();
        }
        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("������: 2.0\n���������: �������� ����");
        }

        private void sort_Click(object sender, EventArgs e)
        {
            new Form3("").ShowDialog();
            this.toolStripStatusLabel2.Text = "��������� ��������: " + "����������";
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (Program.tempAccounts.Count == 0)
            {
                MessageBox.Show("������ �� ���������!");
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (var fileStream = saveFileDialog1.OpenFile())
                    {
                        xmlSerializer.Serialize(fileStream, Program.tempAccounts);
                    }
                }
                else
                {
                    MessageBox.Show("������ ���������� � ����!");
                }
            }
        }

        private void menuItem_CheckedChanged(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            if(item.CheckState == CheckState.Unchecked)
            {
                foreach(ToolStripMenuItem el in this.menuStrip1.Items)
                {
                    if(el.Text == item.Text)
                    {
                        el.Visible = false;
                        return;
                    }
                }
            }
            else
            {
                foreach (ToolStripMenuItem el in this.menuStrip1.Items)
                {
                    if (el.Text == item.Text)
                    {
                        el.Visible = true;
                        return;
                    }
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = DateTime.Now.ToLongDateString();
            toolStripStatusLabel5.Text = DateTime.Now.ToLongTimeString();
        }
    }
}