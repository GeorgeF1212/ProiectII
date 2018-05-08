using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class NewCase : Form
    {
        #region dragable

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, Login.WM_NCLBUTTONDOWN, Login.HT_CAPTION, 0);
            }
        }
        #endregion
        Pen pen = new Pen(Color.LightCoral, 6);
        public NewCase()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            Paint += Case_paint;
            groupBox2.Enabled = false;
        }

        private void Case_paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, Width, Height));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (Application.OpenForms[i].Name != "CHW")
                i++;
            Application.OpenForms[i].Show();
            Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            textBox8.Clear();
            groupBox2.Enabled = true;
            textBox8.AppendText ("-Diabetes");
            textBox8.AppendText(Environment.NewLine);
            textBox8.AppendText ("-Gluten Allergy");
            textBox8.AppendText(Environment.NewLine);
            textBox8.AppendText ("-Pollen Allergy");
            textBox8.AppendText(Environment.NewLine);
            textBox8.AppendText ("-Hemophilia");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            Thread.Sleep(1000);
            double temp = 60 + r.NextDouble() * 10+r.NextDouble() * 5;
            temp = (int)temp;
            textBox11.Text =temp.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (Application.OpenForms[i].Name != "CHW")
                i++;
            MessageBox.Show("Medical report successfully");
            Application.OpenForms[i].Show();
            Close();
        }
    }
}
