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

using htmlInterpreter;
using htmlInterpreter.Debug;
using htmlInterpreter.Caching;
using htmlInterpreter.Components;
using htmlInterpreter.Compiler.CPFM.Vanilla;

using vwc.components;

namespace vwc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        tp_inp projName_Input;
        public string projectPath;
        public MainWindow()
        {
            InitializeComponent();

            projName_Input = new tp_inp();
            projName_Input.placeholder = "project name";
            projName_Input.title = "New project name";
            //topPanel.Children.Add(projName_Input);
            topPanel.Children.Insert(0, projName_Input);
        }

        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        public void BrowseButton_Loaded()
        {
            tp_fileBrowser tp_FileBrowser = new tp_fileBrowser("C://");
            tp_FileBrowser.ShowDialog();

            if(tp_FileBrowser.isResult())
            {
                projectPath = tp_FileBrowser.getResult();
                pathView.Text = $"path: {projectPath}";

                Save.path = projectPath;
                Save.solutionName = projName_Input.getValue();
                Save.solutionExtension= "vwc";
                CreateSolution solution = new CreateSolution(projectPath, $"/{projName_Input.getValue()}", ".vwc");

                Editor editorwin = new Editor();
                editorwin.ShowDialog();
                this.Close();
            }
        }
    }
}
