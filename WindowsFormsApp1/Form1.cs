using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        
        private void btn_send_Click(object sender, EventArgs e)
        {
            IntPtr WindowHandle = FindWindow(textBox2.Text, textBox1.Text);
            if (WindowHandle == IntPtr.Zero)
            {
                Thread.Sleep(1000);
                WindowHandle = FindWindow(textBox2.Text, textBox1.Text);
            }
            SetForegroundWindow(WindowHandle);

           
        }
            private void button1_Click(object sender, EventArgs e)
        {
            IntPtr WindowHandle = FindWindow(textBox2.Text, textBox1.Text);
            if (button1.Enabled)
            {
                textBox1.Text = "*Untitled - Notepad";
            }
            if (WindowHandle == IntPtr.Zero)
            {
                MessageBox.Show(textBox1.Text + " Ứng dụng không tồn tại");
                return;
            }
            SetForegroundWindow(WindowHandle);

            SendKeys.SendWait(textBox3.Text);           
            SendKeys.SendWait("{ENTER}");
        }

        private void btn_send_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
