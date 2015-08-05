using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.DragTabtest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TabItem> ap_SubBrowserTabs
        {
            get { return (ObservableCollection<TabItem>)GetValue(ap_SubBrowserTabsProperty); }
            set { SetValue(ap_SubBrowserTabsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ap_SubBrowserTabs.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ap_SubBrowserTabsProperty =
            DependencyProperty.Register("ap_SubBrowserTabs", typeof(ObservableCollection<TabItem>), typeof(MainWindow), new PropertyMetadata(null));



        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ap_SubBrowserTabs = new ObservableCollection<TabItem>()
            {
                new TabItem()
                {
                    Header = "Yellow Tab",
                    Content = new Border() { Background = Brushes.Yellow }
                },
                new TabItem()
                {
                    Header = "Red Tab",
                    Content = new Border() { Background = Brushes.Red }
                },
                new TabItem()
                {
                    Header = "Blue Tab",
                    Content = new Border() { Background = Brushes.Blue }
                },
            };
        }
    }
}
