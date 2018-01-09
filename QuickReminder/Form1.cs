using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuickReminder
{
    public partial class main : Form
    {

        bool started = false;

        enum timerState { running, stopped, paused }
        timerState state = timerState.stopped;

        public main()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (state != timerState.running)
            {

                if (titleText.Text == "")
                {
                    MessageBox.Show("Please enter a title."); //Dissalowing empty title field.
                }
                else
                {
                    startButton.Enabled = false;
                    stopButton.Enabled = true;
                    state = timerState.running;
                }
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if ( state == timerState.running )
            {
                startButton.Enabled = true;
                startButton.Text = "Resume";
                pauseButton.Enabled = false;
                state = timerState.paused;
                
            }
  
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (state != timerState.stopped)
            {
                startButton.Enabled = true;
                stopButton.Enabled = false;
                state = timerState.stopped;
            }
        }

        int t_i = 0; // Time elapsed
        private void elapsedTime_Tick(object sender, EventArgs e)
        {
            if (state == timerState.running)
            {
                t_i++;
                timeLabel.Text = t_i + " Seconds passed."; //Label displaying time

                if (t_i % ((60 + secondsNumeric.Value) * timeNumeric.Value) == 1)
                {

                    if (t_i != 1)
                    {

                        if (descriptionText.Text == "")
                        {
                            // If description is left blank, it will be replaced by the title.
                            descriptionText.Text = titleText.Text; 
                        }

                        //Notification Balloon
                        messageNotification.Icon = SystemIcons.Application; // Icon for balloon

                        messageNotification.BalloonTipTitle = titleText.Text; // Title
                        messageNotification.BalloonTipText = descriptionText.Text; // Text

                        messageNotification.ShowBalloonTip(1000); // Duration balloon is shown
                    }
                }
            }
            else if (state == timerState.stopped)
            {
                t_i = 0; // Reset time when stopped
            }
        }

        
        private void main_Load(object sender, EventArgs e)
        {

        }

       
    }
}
