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
        public List<Person> personList = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAction(object subject, RoutedEventArgs e)
        {
            Person person = new Person()
            {
                name = uiTextBoxNev.Text.ToString(),
                age = uiTextBoxKor.Text.ToString()
            };

            personList.Add(person);
            uiListView.Items.Add(person);

            uiTextBoxKor.Text = "";
            uiTextBoxNev.Text = "";

        }

        public class Person
        {
            public string name { get; set; }
            public string age { get; set; }
        }
    }
}
