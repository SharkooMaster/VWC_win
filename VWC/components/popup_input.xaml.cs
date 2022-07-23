using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace vwc.components
{
    /// <summary>
    /// Interaction logic for popup_input.xaml
    /// </summary>
    public partial class popup_input : Window
    {
        private bool done = false;
        private string name;

        public popup_input(string _commandTitle)
        {
            InitializeComponent();
            commandTitle.Text = _commandTitle;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        public bool isResult()
        {
            return done;
        }

        public string getResult()
        {
            return name;
        }

        private void Done_btn_Click(object sender, RoutedEventArgs e)
        {
            name = result.Text;
            done = true;
            this.Close();
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
