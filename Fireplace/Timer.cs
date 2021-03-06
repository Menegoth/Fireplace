﻿using System;
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

        //get label
        public System.Windows.Controls.Label GetLabel() {
            return displayLabel;
        }

        //set label
        public void SetDisplayLabel(System.Windows.Controls.Label displayLabel) {
            this.displayLabel = displayLabel;
        }

        //get canvas
        public System.Windows.Controls.Canvas GetCanvas() {
            return backgroundCanvas;
        }

        //set canvas
        public void SetBackgroundCanvas(System.Windows.Controls.Canvas backgroundCanvas) {
            this.backgroundCanvas = backgroundCanvas;
        }

        private void UpdateLabel() {
            displayLabel.Content = time.ToString();
        }

        /// <summary>
        /// Initialize timer
        /// </summary>
        public void InitializeTimer() {

            countdownTimer.Interval = 1000; //one second
            UpdateLabel(); //display original time on label
            countdownTimer.Tick += new EventHandler(countdownTimer_Tick);
            ChangeBackground(orangeColor); //change to orange
            StartTimer();

        }

        private void countdownTimer_Tick(object sender, EventArgs e) {

            //update time
            time--;
            UpdateLabel();
            
            //check if 0
            if (time == 0) {
                StopTimer();
                ChangeBackground(blackColor); //change to black
            }

        }

        //start the timer
        private void StartTimer() {
            countdownTimer.Start();
        }

        //stop timer
        private void StopTimer() {
            countdownTimer.Stop();
        }

        /// <summary>
        /// Add time to the current timer
        /// </summary>
        /// <param name="amount">Amount to add</param>
        public void addTime(int amount) {

            //restart timer if ran out
            if (time == 0) {
                StartTimer();
                ChangeBackground(orangeColor); //change back to orange
            }

            time += amount;

            //display new amount
            UpdateLabel();
        }

        //change canvas background
        private void ChangeBackground(SolidColorBrush color) {
            backgroundCanvas.Background = color;
        }

    }
}
