namespace LR1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if(this.textBox2.Enabled)
            {
                this.label2.Text = "Унарный оператор";
                this.textBox2.Enabled = false;
            }
            else
            {
                this.label2.Text = "Второе значение";
                this.textBox2.Enabled = true;
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Compute();
            }
            catch(FormatException)
            {
                MessageBox.Show("Некорректные данные!");
            }
            catch(Exception)
            {
                MessageBox.Show("Выберите радиокнопку");
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Reset();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}