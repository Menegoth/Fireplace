using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Fireplace {
    public class Firewood {

        //instance variables
        private int amount = 0;
        private System.Windows.Controls.Label displayLabel;

        //random number generator
        Random generator = new Random();

        //get amount
        public int GetAmount() {
            return amount;
        }

        //set DisplayLabel
        public void SetDisplayLabel(System.Windows.Controls.Label displayLabel) {
            this.displayLabel = displayLabel;
        }

        //initiliaze wood
        public void InitializeWood() {
            UpdateLabel();
        }

        public void UseWood(int amount) {
            this.amount -= amount;
            UpdateLabel();
        }

        //chop for a random amount of wood
        public void ChopWood() {
            //add a random number between 1 and 3 to total
            amount += generator.Next(1, 4);

            //update label
            UpdateLabel();
        }

        //update label with current amount
        private void UpdateLabel() {
            displayLabel.Content = "You currently have " + amount.ToString() + " pieces of wood.";
        }

    }
}
