using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace DB_GUI
{
    public partial class Manual : Form
    {
        private Timer fadeTimer;
        private bool fadeMode = false;
        public Manual()
        {
            InitializeComponent();
            InitializeFadeIn();
        }

        private void InitializeFadeIn()
        {
            this.Opacity = 0;  // Set form to be fully transparent initially
            fadeTimer = new Timer();
            fadeMode = false;
            fadeTimer.Interval = 10;  // Set the interval to 50ms
            fadeTimer.Tick += new EventHandler(FadeEffect);
            fadeTimer.Start();
        }

        private void FadeEffect(object sender, EventArgs e)
        {
            if (!fadeMode)
            {
                if (this.Opacity < 1) this.Opacity += 0.05;
                else fadeTimer.Stop();
            }
            else
            {
                if (this.Opacity > 0) this.Opacity -= 0.05;
                else
                {
                    fadeTimer.Stop();
                    this.Close();
                }
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.Opacity > 0)
            {
                e.Cancel = true;
                fadeMode = true;
                fadeTimer.Start();
            }
            else
            {
                base.OnFormClosing(e);
            }
        }
    }
}
