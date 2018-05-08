using System;
using System.Drawing;
using System.Windows.Forms;


namespace WindowsFormsApp1
{

    public partial class Login : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public Pen pen = new Pen(Color.LightCoral, 6);

        
        public Login()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            Paint += Login_Paint;
            

        }

        private void Login_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, Width, Height));
        }
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
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Doctor doc = new Doctor();
            CHW chw = new CHW();
            if (textBox1.Text == "DoctorStar" && textBox2.Text == "qwerty")
            {
                // Doc Form
                doc.Show();
                Hide();

            }
            else
                if (textBox1.Text == "CommunityWorker" && textBox2.Text == "123456")

            {
                //CW Form
                chw.Show();
                Hide();

            }
            else
                MessageBox.Show("Username or password is incorrect");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




    }
}
