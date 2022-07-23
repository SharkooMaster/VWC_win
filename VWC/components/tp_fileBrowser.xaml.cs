using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for tp_fileBrowser.xaml
    /// </summary>
    public partial class tp_fileBrowser : Window
    {
        private string path;
        private bool done = false;

        public string _pathSet
        {
            get { return path; }
            set {
                dirsList.Children.Clear();
                path = value;

                var temp = getSubDirs();
                for (int i = 0; i < temp.Length; i++)
                {
                    fileBrowser_interactable _obj = new fileBrowser_interactable();
                    _obj.path = temp[i];
                    _obj.type = "D";
                    Func<string, string> f = (_p) => _pathSet = _p;
                    dirsList.Children.Add(_obj.getUI(f));
                }

                temp = getSubFiles();
                for (int i = 0; i < temp.Length; i++)
                {
                    fileBrowser_interactable _obj = new fileBrowser_interactable();
                    _obj.path = temp[i];
                    _obj.type = "F";
                    Func<string, string> f = (_p) => _pathSet = _pathSet;
                    dirsList.Children.Add(_obj.getUI(f));
                }
            }
        }

        private string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string RecentPath = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
        private string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string musicPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        private string picturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        public tp_fileBrowser(string _path = "")
        {
            if (_path != "") { path = _path; }

            InitializeComponent();
        }

        public bool isResult()
        {
            return done;
        }

        public string getResult()
        {
            return _pathSet;
        }

        private string[] getSubDirs()
        {
            return Directory.GetDirectories(path);
        }

        private string[] getSubFiles()
        {
            syncPathText();
            return Directory.GetFiles(path);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void syncPathText() { pathText.Text = path; }

        private void Desktop_btn_MouseDown(object sender, RoutedEventArgs e)
        {
            _pathSet = desktopPath;
            syncPathText();
        }

        private void Recent_btn_MouseDown(object sender, RoutedEventArgs e)
        {
            _pathSet = RecentPath;
            syncPathText();
        }
        private void Document_btn_MouseDown(object sender, RoutedEventArgs e)
        {
            _pathSet = documentsPath;
            syncPathText();
        }
        private void Music_btn_MouseDown(object sender, RoutedEventArgs e)
        {
            _pathSet = musicPath;
            syncPathText();
        }
        private void Pictures_btn_MouseDown(object sender, RoutedEventArgs e)
        {
            _pathSet = picturesPath;
            syncPathText();
        }

        private void Done_btn_Click(object sender, RoutedEventArgs e)
        {
            done = true;
            this.Close();
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void newFolder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string newFolderName = "";
            popup_input inputName = new popup_input("Provide the required folder name.");
            inputName.ShowDialog();
            if(inputName.isResult())
            {
                newFolderName = inputName.getResult();
                Directory.CreateDirectory($"{_pathSet}/{newFolderName}/");
                _pathSet = path;
            }
        }
    }

    public class fileBrowser_interactable
    {
        public string type { get; set; }
        public string path { get; set; }

        public WrapPanel getUI(Func<string, string> setPath)
        {
            WrapPanel sp = new WrapPanel();

            Image img = new Image();
            TextBlock tb = new TextBlock();

            if (type == "D")
            {
                img.Source = GetImage("/ui/folder.png");
                tb.Width = 120;
                tb.TextAlignment = TextAlignment.Center;
                img.Width = 100;
                sp.Width = 120;
                sp.Margin = new Thickness(4);

                //sp.MouseDown += ()
            }
            else if(type == "F")
            {
                img.Source = GetImage("/ui/htmlFile.png");
                tb.Width = 120;
                tb.TextAlignment = TextAlignment.Center;
                img.Width = 50;
                sp.Width = 120;
                sp.Margin = new Thickness(4);
            }

            tb.Text = System.IO.Path.GetFileName(path);
            tb.HorizontalAlignment = HorizontalAlignment.Center;

            sp.Orientation = Orientation.Vertical;
            sp.HorizontalAlignment = HorizontalAlignment.Center;
            sp.FlowDirection = FlowDirection.LeftToRight;

            sp.MouseEnter += (object sender, MouseEventArgs e) => { sp.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#0C000000"); };
            sp.MouseLeave += (object sender, MouseEventArgs e) => { sp.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFFFF"); };

            sp.MouseDown  += (object sender, MouseButtonEventArgs e) => { setPath(path); };

            sp.Children.Add(img);
            sp.Children.Add(tb);

            return sp;
        }

        // {/Content/Images/test.png}
        private BitmapImage GetImage(string imageUri)
        {
            var bitmapImage = new BitmapImage();

            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imageUri, UriKind.Relative);
            bitmapImage.EndInit();

            return bitmapImage;
        }
    }
}
