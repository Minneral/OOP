using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR2
{
    public partial class Form3 : Form
    {
        public Form3(string type)
        {
            InitializeComponent();

            switch(type)
            {
                case "FIO":
                    this.checkBox2.Checked = true;
                    this.textBox2.Enabled = true;
                    break;
                case "Balance":
                    this.checkBox3.Checked = true;
                    this.textBox3.Enabled = true;
                    break;
                case "Type":
                    this.checkBox4.Checked = true;
                    this.textBox4.Enabled = true;
                    break;
                case "Number":
                    this.checkBox1.Checked = true;
                    this.textBox1.Enabled = true;
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Change(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string pattern = textBox1.Text;
            Regex reg = new Regex($@"^{pattern}");

            foreach(var item in Program.accounts)
            {
                Match m = reg.Match(item.Number.ToString());
                if(m.Success)
                {
                    listBox1.Items.Add(item.Number);
                }
            }
        }

        private void textBox2_Change(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string pattern = textBox2.Text;
            Regex reg = new Regex($@"{pattern}");

            foreach (var item in Program.accounts)
            {
                Match m = reg.Match(item._Owner._FIO.ToString());
                if (m.Success)
                {
                    listBox1.Items.Add(item.Number);
                }
            }
        }

        private void textBox_Change(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            bool bNumber = this.checkBox1.Checked;
            bool bFIO = this.checkBox2.Checked;
            bool bBalance = this.checkBox3.Checked;
            bool bType = this.checkBox4.Checked;
            bool bTry = true;

            List<Account> enters = new List<Account>();

            string pattern = "";

            if(bNumber)
            {
                pattern = $@"^{textBox1.Text}";

                if (enters.Count == 0 && bTry)
                {
                    for(int i = 0; i < Program.accounts.Count; i++)
                    {
                        var item = Program.accounts[i];
                        if (Regex.Match(item.Number.ToString(), pattern).Success)
                        {
                            enters.Add(item);
                        }
                    }

                    bTry = false;
                }
                else
                {
                    for (int i = 0; i < enters.Count; i++)
                    {
                        var item = enters[i];
                        if (Regex.Match(item.Number.ToString(), pattern).Success == false)
                        {
                            enters.Remove(item);
                        }
                    }
                }
            }

            if (bFIO)
            {
                pattern = $@"{textBox2.Text}";

                if (enters.Count == 0 && bTry)
                {
                    for (int i = 0; i < Program.accounts.Count; i++)
                    {
                        var item = Program.accounts[i];
                        if (Regex.Match(item._Owner._FIO.ToString(), pattern, RegexOptions.IgnoreCase).Success)
                        {
                            enters.Add(item);
                        }
                    }

                    bTry = false;
                }
                else
                {
                    for (int i = 0; i < enters.Count; i++)
                    {
                        var item = enters[i];
                        if (Regex.Match(item._Owner._FIO.ToString(), pattern, RegexOptions.IgnoreCase).Success == false)
                        {
                            enters.Remove(item);
                        }
                    }
                }
            }

            if (bBalance)
            {
                pattern = $@"^{textBox3.Text}";

                if (enters.Count == 0 && bTry )
                {
                    for (int i = 0; i < Program.accounts.Count; i++)
                    {
                        var item = Program.accounts[i];
                        if (Regex.Match(item.Balance.ToString(), pattern).Success)
                        {
                            enters.Add(item);
                        }
                    }

                    bTry = false;
                }
                else
                {
                    for (int i = 0; i < enters.Count; i++)
                    {
                        var item = enters[i];
                        if (Regex.Match(item.Balance.ToString(), pattern).Success == false)
                        {
                            enters.Remove(item);
                        }
                    }
                }
            }

            if (bType)
            {
                pattern = $@"^{textBox4.Text}";

                if (enters.Count == 0 && bTry )
                {
                    for (int i = 0; i < Program.accounts.Count; i++)
                    {
                        var item = Program.accounts[i];
                        if (Regex.Match(item.DepositeType, pattern, RegexOptions.IgnoreCase).Success)
                        {
                            enters.Add(item);
                        }
                    }

                    bTry = false;
                }
                else
                {
                    for (int i = 0; i < enters.Count; i++)
                    {
                        var item = enters[i];
                        if (Regex.Match(item.DepositeType, pattern, RegexOptions.IgnoreCase).Success == false)
                        {
                            enters.Remove(item);
                        }
                    }
                }
            }

            result = enters;
            foreach (var item in enters)
            {
                listBox1.Items.Add(item.Number);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                textBox4.Enabled = true;
            }
            else
            {
                textBox4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
                result = result.OrderBy(t => t.DepositeType).ToList();

                foreach (var item in result)
                {
                    listBox1.Items.Add(item.Number);
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
                result = result.OrderBy(t => t.FoundationDate).ToList();

                foreach (var item in result)
                {
                    listBox1.Items.Add(item.Number);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.tempAccounts = result;
        }

        private void listBox1_doubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Rectangle selectedRect = listBox1.GetItemRectangle(listBox1.SelectedIndex);

            if (selectedRect.Contains(me.Location))
            {
                Account item = Program.accounts.First(t => t.Number == (int)listBox1.SelectedItem);
                string info = "";
                info += $"Номер счета: {item.Number}\n";
                info += $"Тип вклада: {item.DepositeType}\n";
                info += $"Баланс: {item.Balance}\n";
                info += $"Дата открытия: {item.FoundationDate.ToString()}\n";
                info += $"Владелец: {item._Owner._FIO.ToString()}\n";

                info += $"SMS-Оповещения: ";
                if (item.SMSNotify)
                {
                    info += "Да\n";
                }
                else
                {
                    info += "Нет\n";
                }

                info += $"Интернет-Банкинг: ";
                if (item.InternetBanking)
                {
                    info += "Да\n";
                }
                else
                {
                    info += "Нет\n";
                }

                MessageBox.Show(info);
            }
        }
    }
}
