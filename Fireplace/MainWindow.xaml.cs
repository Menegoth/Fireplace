using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fireplace {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        //create a timer object 
        Timer countdown = new Timer(10);

        //create firewood object
        Firewood wood = new Firewood();

        public MainWindow() {
            InitializeComponent();


            //intialize timer
            countdown.SetDisplayLabel(timeLabel);
            countdown.SetBackgroundCanvas(backgroundCanvas);
            countdown.InitializeTimer();

            //initialize wood
            wood.SetDisplayLabel(woodLabel);
            wood.InitializeWood();

        }

        private void addButton_Click(object sender, RoutedEventArgs e) {

            //check if player has at least 10 wood
            if (wood.GetAmount() >= 10) {
                wood.UseWood(10);
                countdown.addTime(10);
            }

        }

        private void woodButton_Click(object sender, RoutedEventArgs e) {
            wood.ChopWood();
        }
    }
}
