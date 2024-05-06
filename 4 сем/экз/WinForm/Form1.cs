namespace WinForm
{
    public partial class Form1 : Form
    {
        int[] array;

        public Form1()
        {
            InitializeComponent();

            array = new int[10];
            for(int i = 0; i < 10; i++)
            {
                array[i] = (new Random()).Next(1, 100);
                listView1.Items.Add(i.ToString());
                listView2.Items.Add(array[i].ToString());
            }

            statusStrip1.Items[0].Text = DateTime.Now.Year.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>(array);
            textBox3.Text = list.IndexOf(list.Max()).ToString();
            textBox4.Text = list.Max().ToString();

           
        }
    }
}