using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace YouTubeDL
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
   (

            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
   );
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            label1.Text = Environment.UserName;
            label1.Refresh();
            label2.Text = Environment.MachineName;
            label2.Refresh();
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlNav.Visible = true;
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            pnlFormLoader.Visible = true;
            lblTitle.Text = "Media Player";
            this.pnlFormLoader.Controls.Clear();
            frmMedia frmMedia_vrb = new frmMedia() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmMedia_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmMedia_vrb);
            frmMedia_vrb.Show();
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            pnlNav.Visible = true;
            pnlNav.Height = btnCalculator.Height;
            pnlNav.Top = btnCalculator.Top;
            pnlNav.Left = btnCalculator.Left;
            btnCalculator.BackColor = Color.FromArgb(46, 51, 73);

            pnlFormLoader.Visible = true;
            lblTitle.Text = "Calculator";
            this.pnlFormLoader.Controls.Clear();
            frmCalculator frmCalculator_vrb = new frmCalculator() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmCalculator_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmCalculator_vrb);
            frmCalculator_vrb.Show();
        }

        private void btnVideoDL_Click(object sender, EventArgs e)
        {
            pnlNav.Visible = true;
            pnlNav.Height = btnVideoDL.Height;
            pnlNav.Top = btnVideoDL.Top;
            pnlNav.Left = btnVideoDL.Left;
            btnVideoDL.BackColor = Color.FromArgb(46, 51, 73);

            pnlFormLoader.Visible = true;
            lblTitle.Text = "Video Downloader";
            this.pnlFormLoader.Controls.Clear();
            frmVideoDL frmVideoDL_vrb = new frmVideoDL() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmVideoDL_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmVideoDL_vrb);
            frmVideoDL_vrb.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            pnlNav.Visible = true;
            pnlNav.Height = btnHelp.Height;
            pnlNav.Top = btnHelp.Top;
            pnlNav.Left = btnHelp.Left;
            btnHelp.BackColor = Color.FromArgb(46, 51, 73);

            pnlFormLoader.Visible = true;
            lblTitle.Text = "Contact";
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnCalculator_Leave(object sender, EventArgs e)
        {
            btnCalculator.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnVideoDL_Leave(object sender, EventArgs e)
        {
            btnVideoDL.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnHelp_Leave(object sender, EventArgs e)
        {
            btnHelp.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_CursorChanged(object sender, EventArgs e)
        {

        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            pnlNav.Visible = true;
            pnlNav.Height = btnCalendar.Height;
            pnlNav.Top = btnCalendar.Top;
            pnlNav.Left = btnCalendar.Left;
            btnCalendar.BackColor = Color.FromArgb(46, 51, 73);

            pnlFormLoader.Visible = true;
            lblTitle.Text = "Calendar";
        }

        private void btnCalendar_Leave(object sender, EventArgs e)
        {
            btnCalendar.BackColor = Color.FromArgb(24, 30, 54);
        }
    }
}
