using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;

namespace Fireplace {
    public class Timer {

        //variables
        private int time;
        private System.Windows.Controls.Label displayLabel;
        private System.Windows.Controls.Canvas backgroundCanvas;

        //background colors for different states
        private SolidColorBrush orangeColor = new SolidColorBrush(Color.FromRgb(255, 172, 51));
        private SolidColorBrush blackColor = new SolidColorBrush(Color.FromRgb(0, 0, 0));

        //set a timer
        System.Windows.Forms.Timer countdownTimer = new System.Windows.Forms.Timer();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="interval">Amount of time between each tick</param>
        public Timer(int time) {
            this.time = time;
        }

        //get time
        public int GetTime() {
            return time;
        }

        //set label
        public void SetDisplayLabel(System.Windows.Controls.Label displayLabel) {
            this.displayLabel = displayLabel;
        }

        //set canvas
        public void SetBackgroundCanvas(System.Windows.Controls.Canvas backgroundCanvas) {
            this.backgroundCanvas = backgroundCanvas;
        }

        /// <summary>
        /// Initialize timer
        /// </summary>
        public void InitializeTimer() {

            countdownTimer.Interval = 1000; //one second
            displayLabel.Content = time.ToString(); //display original time on label
            countdownTimer.Tick += new EventHandler(countdownTimer_Tick);
            ChangeBackground(orangeColor);

        }

        private void countdownTimer_Tick(object sender, EventArgs e) {

            //update time
            time--;
            displayLabel.Content = time.ToString();
            
            //check if 0
            if (time == 0) {
                countdownTimer.Stop();
                ChangeBackground(blackColor);
            }

        }

        //start the timer
        public void startTimer() {
            countdownTimer.Start();
        }

        /// <summary>
        /// Add time to the current timer
        /// </summary>
        /// <param name="amount">Amount to add</param>
        public void addTime(int amount) {

            //restart timer if ran out
            if (time == 0) {
                countdownTimer.Start();
                ChangeBackground(orangeColor);
            }

            time += amount;

            //display new amount
            displayLabel.Content = time.ToString();
        }

        //change canvas background
        public void ChangeBackground(SolidColorBrush color) {
            backgroundCanvas.Background = color;
        }

    }
}
