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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace vwc.components
{
    /// <summary>
    /// Interaction logic for tp_btn.xaml
    /// </summary>
    public partial class tp_inp : UserControl
    {
        public static readonly DependencyProperty title_property =
            DependencyProperty.Register("title", typeof(string), typeof(tp_inp), new PropertyMetadata(string.Empty));

        public string title
        {
            get { return (string)GetValue(title_property); }
            set { SetValue(title_property, value); }
        }


        public static readonly DependencyProperty placeholder_property =
            DependencyProperty.Register("placeholder", typeof(string), typeof(tp_inp), new PropertyMetadata(string.Empty));

        public string placeholder
        {
            get { return (string)GetValue(placeholder_property); }
            set { SetValue(placeholder_property, value); }
        }

        public string getValue()
        {
            return valueBox.Text;
        }

        public tp_inp()
        {
            InitializeComponent();
        }
    }
}
