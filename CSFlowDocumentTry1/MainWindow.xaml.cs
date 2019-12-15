using CSAc4yClass.Class;
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

namespace CSFlowDocumentTry1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Ac4yClass> Ac4yClassList = new List<Ac4yClass>();

        public MainWindow()
        {
            InitializeComponent();

           // uiListViewFlowDocument.Items.Add(uiListViewItem);
           // uiListViewFlowDocument.Items.Add(uiListViewItem);
        }

        private void AddTextBox(object subject, RoutedEventArgs e)
        {
            BlockUIContainer uiContainer = new BlockUIContainer()
            {
                Child = new TextBox() { Width = 200 }
            };

            uiFlowDocument.Blocks.Add(uiContainer);
        }

        private void ButtonAction(object subject, RoutedEventArgs e)
        {
            Ac4yClass ac4yClass = new Ac4yClass()
            {
                Name = uiTextBoxName.Text.ToString(),
                Ancestor = uiTextBoxAncestor.Text.ToString(),
                GUID = uiTextBoxGUID.Text.ToString(),
                Namespace = uiTextBoxNamespace.Text.ToString()
            };

            Ac4yClassList.Add(ac4yClass);
            uiListView.Items.Add(ac4yClass);

            uiTextBoxName.Text = "";
            uiTextBoxAncestor.Text = "";
            uiTextBoxGUID.Text = "";
            uiTextBoxNamespace.Text = "";

        }

        public class Person
        {
            public string name { get; set; }
            public string age { get; set; }
        }
    }
}
