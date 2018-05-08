using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CHW : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        Pen pen = new Pen(Color.LightCoral, 6);
       
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
        public CHW()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            Paint += CHW_Paint;
            MenuP.Visible = true;
            this.Size = new Size(898, 592);
            comboBox1.SelectedIndex = 1;
            EmergencyP.Visible = false;

        }

        private void CHW_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, Width, Height));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Application.OpenForms[0].Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            NewCase newcase = new NewCase();
            newcase.Show();
        }



        private void button6_Click(object sender, EventArgs e)
        {
            MenuP.Visible = false;
        
            EmergencyP.Visible = true;
            EmergencyP.Location = new Point(7, 7);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MenuP.Visible = true;
            MenuP.Location = new Point(7, 7);
        }


    }
}
