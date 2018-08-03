using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNS.UI
{
    public partial class SNSUserControl : UserControl
    {
        public BackgroundWorker BackWorker { get; set; }
        public ProgressBar Progress { get; set; }

        public SNSUserControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            BackWorker = new BackgroundWorker();
            BackWorker.DoWork += BackWorker_DoWork;
            BackWorker.RunWorkerCompleted += BackWorker_RunWorkerCompleted;

            Progress = new ProgressBar();
            Progress.Style = ProgressBarStyle.Marquee;
            Progress.MarqueeAnimationSpeed = 10;
            this.Controls.Add(Progress);
            Progress.Visible = false;
            Progress.BringToFront();
        }

        public delegate void ProgressVisible(bool var);
        public delegate void ProgressLocation(Point var);

        public void RunProgress()
        {
            Progress.Invoke(new ProgressVisible(ProgressView), true);
            Progress.Invoke(new ProgressLocation(ProgressLoc), new Point(this.Width / 2, this.Height / 2));
        }

        public void RunBackWorker()
        {
            BackWorker.RunWorkerAsync();
        }

        private void ProgressView(bool val)
        {
            Progress.Visible = val;
        }

        private void ProgressLoc(Point val)
        {
            Progress.Location = val;
        }

        #region [ Event ]
        public virtual void BackWorker_RunWorkerCompleted(object send, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public virtual void BackWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
