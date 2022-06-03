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
    public partial class tp_btn : UserControl
    {
        public static readonly DependencyProperty inner_content_property =
        DependencyProperty.Register("inner_content", typeof(string), typeof(tp_btn), new PropertyMetadata(string.Empty));

        public string inner_content
        {
            get { return (string)GetValue(inner_content_property); }
            set { SetValue(inner_content_property, value); }
        }

        public tp_btn()
        {
            InitializeComponent();
        }
    }
}
