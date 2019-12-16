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
        public Dictionary<string, Ac4yClass> Ac4yClassDictionary = new Dictionary<string, Ac4yClass>();
        public List<Ac4yClass> ac4YClasses = new List<Ac4yClass>();
        public int i = 1;

        public MainWindow()
        {
            InitializeComponent();

           // uiListViewFlowDocument.Items.Add(uiListViewItem);
           // uiListViewFlowDocument.Items.Add(uiListViewItem);
        }

        private void AddTextBox(object subject, RoutedEventArgs e)
        { 
            WrapPanel uiMainWrapPanel = new WrapPanel() {
                Orientation = Orientation.Vertical,
                Width = 750,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            WrapPanel uiInnerWrapPanel1 = new WrapPanel() {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness()
                {
                    Top = 12,
                    Left = 25
                }
            };

            uiInnerWrapPanel1.Children.Add(
                new Label() {
                    Content = "Name: ",
                    Width = 100
                });

            uiInnerWrapPanel1.Children.Add(
                new TextBox()
                {
                    Name = "uiTextBoxName",
                    Width = 250,
                    Height = 25
                });

            uiInnerWrapPanel1.Children.Add(
                new Label()
                {
                    Content = "Ancestor: ",
                    Width = 100
                });

            uiInnerWrapPanel1.Children.Add(
                new TextBox()
                {
                    Name = "uiTextBoxAncestor",
                    Width = 250,
                    Height = 25
                });

            WrapPanel uiInnerWrapPanel2 = new WrapPanel() {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness()
                {
                    Top = 12,
                    Left = 25
                }
            };

            uiInnerWrapPanel2.Children.Add(
                new Label()
                {
                    Content = "GUID: ",
                    Width = 100
                });

            uiInnerWrapPanel2.Children.Add(
                new TextBox()
                {
                    Name = "uiTextBoxGUID",
                    Width = 250,
                    Height = 25
                });

            uiInnerWrapPanel2.Children.Add(
                new Label()
                {
                    Content = "Namespace: ",
                    Width = 100
                });

            uiInnerWrapPanel2.Children.Add(
                new TextBox()
                {
                    Name = "uiTextBoxNamespace",
                    Width = 250,
                    Height = 25
                });
            BlockUIContainer uiContainer = new BlockUIContainer()
            {
                Child = uiMainWrapPanel,
                BorderBrush = new SolidColorBrush(Color.FromRgb(0,0,0)),
                BorderThickness = new Thickness()
                {
                    Bottom = 1,
                    Left = 1,
                    Top = 1,
                    Right = 1
                }
                
            };
            Section sectionFromCode = new Section()
            {
                Background = new SolidColorBrush(Color.FromRgb(248, 248, 255)),
                Name = "section" + i
            };

            Button uiTorlesButton = new Button()
            {
                Width = 200,
                Content = "Törlés",
                Tag = sectionFromCode.Name
            };

            uiTorlesButton.Click += deleteButton;

            uiMainWrapPanel.Children.Add(uiInnerWrapPanel1);
            uiMainWrapPanel.Children.Add(uiInnerWrapPanel2);
            uiMainWrapPanel.Children.Add(uiTorlesButton);


            sectionFromCode.Blocks.Add(uiContainer);
            uiFlowDocument.Blocks.Add(sectionFromCode);

            
            Ac4yClassDictionary.Add(sectionFromCode.Name, new Ac4yClass());

            i++;
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

            uiListView.Items.Add(ac4yClass);
            
            foreach (var block in uiFlowDocument.Blocks)
            {
                foreach (var dictionary in Ac4yClassDictionary)
                {
                    if (block.Name.Equals(dictionary.Key))
                    {
                        Section sectionBlock = (Section)block;
                        BlockUIContainer uiContainmer = (BlockUIContainer)sectionBlock.Blocks.FirstBlock;
                        WrapPanel uiMainWrapPanel = (WrapPanel)uiContainmer.Child;
                        UIElementCollection uiInnerWrapPanels = uiMainWrapPanel.Children;
                        foreach(var uiInnerWrapPanel in uiInnerWrapPanels)
                        {
                            UIElementCollection uiWrapPanelElements = uiMainWrapPanel.Children;
                            foreach(var element in uiWrapPanelElements)
                            {
                                if (element.GetType().Name.Equals("WrapPanel"))
                                {
                                    WrapPanel wrapPanel = (WrapPanel)element;
                                    foreach(var elem in wrapPanel.Children)
                                    {
                                        if (elem.GetType().Name.Equals("TextBox"))
                                        {
                                            TextBox uiTextBox = (TextBox)elem;
                                            if (uiTextBox.Name.Equals("uiTextBoxName"))
                                            {
                                                dictionary.Value.Name = uiTextBox.Text;
                                            }
                                            else if (uiTextBox.Name.Equals("uiTextBoxAncestor"))
                                            {
                                                dictionary.Value.Ancestor = uiTextBox.Text;
                                            }
                                            else if (uiTextBox.Name.Equals("uiTextBoxGUID"))
                                            {
                                                dictionary.Value.GUID = uiTextBox.Text;
                                            }
                                            else if (uiTextBox.Name.Equals("uiTextBoxNamespace"))
                                            {
                                                dictionary.Value.Namespace = uiTextBox.Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach (var ac4y in Ac4yClassDictionary)
            {
                uiListView.Items.Add(ac4y.Value);
            }
            /*
            uiTextBoxName.Text = "";
            uiTextBoxAncestor.Text = "";
            uiTextBoxGUID.Text = "";
            uiTextBoxNamespace.Text = "";
            */
        }

        private void deleteButton(object subject, RoutedEventArgs e)
        {
            var clickedButton = subject as Button;
            string sectionName = clickedButton.Tag.ToString();

            List<Block> flowDocumentBlockList = uiFlowDocument.Blocks.ToList();
            uiFlowDocument.Blocks.Clear();

            foreach(var block in flowDocumentBlockList)
            {
                if (!block.Name.Equals(sectionName))
                {
                    uiFlowDocument.Blocks.Add(block);
                }
            }
            
            foreach(var dictionary in Ac4yClassDictionary)
            {
                if (dictionary.Key.Equals(sectionName))
                {
                    Ac4yClassDictionary.Remove(sectionName);
                }
            }
        }

        public class Person
        {
            public string name { get; set; }
            public string age { get; set; }
        }
    }
}
