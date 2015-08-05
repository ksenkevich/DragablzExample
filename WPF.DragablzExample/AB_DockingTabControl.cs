using Dragablz;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPF.DragTabtest
{
    public class AB_DockingTabControl : TabablzControl
    {
        public AB_DockingTabControl() : base()
        {
            InterTabController = new InterTabController()
            {
                InterTabClient = new AB_DockableTabInterTabClient()
            };

            //var b = new Binding("ap_ItemsSource");
            //b.Source = this;
            //b.Mode = BindingMode.TwoWay;
            //b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //SetBinding(ItemsSourceProperty, b);
        }

        static AB_DockingTabControl()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(AB_DockingTabControl), new FrameworkPropertyMetadata(typeof(AB_DockingTabControl)));
        }

        public void am_AddTab(TabItem tabToAdd)
        {
            var tab = tabToAdd as TabItem;
            if (tab == null) return;

            Items.Add(tab);
        }

        public void am_InsertTab(int index, TabItem tabToInsert)
        {
            var tab = tabToInsert as TabItem;
            if (tab == null) return;

            Items.Insert(index, tab);
        }

        public void am_RefreshDataContext()
        {
            object temp = DataContext;
            DataContext = null;
            DataContext = temp;
        }

        public void am_RemoveTab(TabItem tabToRemove)
        {
            var tab = tabToRemove as TabItem;
            if (tab == null) return;

            Items.Remove(tab);
        }

        public ObservableCollection<TabItem> ap_Tabs
        {
            get { return new ObservableCollection<TabItem>(Items.Cast<TabItem>()); }
        }

        public IEnumerable ap_ItemsSource
        {
            get { return (IEnumerable)GetValue(ap_ItemsSourceProperty); }
            set { SetValue(ap_ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ap_ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ap_ItemsSourceProperty =
            DependencyProperty.Register("ap_ItemsSource", typeof(IEnumerable), typeof(AB_DockingTabControl), new PropertyMetadata(null));

        public void am_Focus()
        {
            this.Focus();
        }

        public int ap_SelectedIndex
        {
            get { return SelectedIndex; }
            set { SelectedIndex = value; }
        }

        public TabItem ap_SelectedItem
        {
            get { return SelectedItem as TabItem; }
            set { SelectedItem = value; }
        }

        public event SelectionChangedEventHandler ae_SelectionChanged;

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            FireSelectionChanged(e);
        }

        protected void FireSelectionChanged(SelectionChangedEventArgs e)
        {
            if (ae_SelectionChanged != null)
            {
                ae_SelectionChanged(this, e);
            }
        }
    }
}
