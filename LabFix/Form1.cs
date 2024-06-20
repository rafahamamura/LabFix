namespace LabFix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form configIP = new frm_configIP();
            configIP.ShowDialog();
        }
    }
}
