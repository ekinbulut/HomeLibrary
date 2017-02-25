using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Library.Wpf
{
    internal static class RenderApplication
    {
        public static void FillComboBox<T>(this ComboBox comboBox, ICollection<T> itemCollection, string displayname,
            string value)
        {
            comboBox.ItemsSource = itemCollection;
            comboBox.DisplayMemberPath = displayname;
            comboBox.SelectedValuePath = value;
            comboBox.Text = "Select option";

        }

        public static void FillComboBox<T>(this ComboBox comboBox, IOrderedEnumerable<T> itemCollection)
        {
            comboBox.ItemsSource = itemCollection;
            comboBox.DisplayMemberPath = "Name";
            comboBox.SelectedValuePath = "Value";
            comboBox.Text = "Select option";


        }
    }
}
