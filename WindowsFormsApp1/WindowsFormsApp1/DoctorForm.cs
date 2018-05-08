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
    public partial class Doctor : Form
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
        public Doctor()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            Paint += Doctor_paint;
            CaseP.Visible = false;
            EvaluateCP.Visible = false;
            MenuPan.Visible = true;
            CaseP.Location = new Point(6, 6);
            EvaluateCP.Location = new Point(6, 6);
            MenuPan.Location = new Point(6, 6);
            Size = new Size(910, 623);
        }

        private void Doctor_paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, 910, 623));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Application.OpenForms[0].Show();
           
        }

        private void button2_Click(object sender, EventArgs e) //Database view
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Surname", typeof(String));
            dt.Columns.Add("DoB", typeof(String));
            dt.Columns.Add("Status", typeof(String));
            dt.Rows.Add(new Object[] { "John", "Doe","16/06/1954","Pending" });
            dt.Rows.Add(new Object[] { "Steve", "Smith", "01/06/1951", "Pending" });
            dt.Rows.Add(new Object[] { "Melania", "Parker", "12/08/1964", "Pending" });
            dt.Rows.Add(new Object[] { "Ion", "Gramada", "07/02/1983", "Pending" });
            dt.Rows.Add(new Object[] { "David", "Johnson", "02/05/1974", "Pending" });
            dt.Rows.Add(new Object[] { "Howard", "Gillman", "19/03/1984", "Pending" });
            dt.Rows.Add(new Object[] { "Patrick", "Brown", "13/12/1944", "Pending" });
            dataGridView1.DataSource = dt;
            CaseP.Visible = false;
            EvaluateCP.Visible = true;
            MenuPan.Visible = false;

        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            CaseP.Visible = false;
            EvaluateCP.Visible = false;
            MenuPan.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CaseP.Visible = true;
            EvaluateCP.Visible = false;
            MenuPan.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            CaseP.Visible = false;
            EvaluateCP.Visible = true;
            MenuPan.Visible = false;
            MessageBox.Show("Solution was successfully sent!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CaseP.Visible = false;
            EvaluateCP.Visible = true;
            MenuPan.Visible = false;
        }


        private void button8_Click(object sender, EventArgs e)
        {
            CaseP.Visible = false;
            EvaluateCP.Visible = false;
            MenuPan.Visible = true;
        }
        
    }
}
