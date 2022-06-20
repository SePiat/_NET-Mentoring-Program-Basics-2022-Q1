using HandlerOfGreetingSt;
using System;
using System.Windows.Forms;

namespace DotNET_Framework___WinForms
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
            var handler = new GreetingHandler();
            var usernameWithDate = handler.GreetHandle(textBox1.Text);
            MessageBox.Show(
                usernameWithDate,
                "Greeting user",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
