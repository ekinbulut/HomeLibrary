using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Library.UI.Services.Model;

namespace Library.Wpf
{
    internal static class SearchApplication
    {
        public static void FilteredResults(this DataGrid grid,IEnumerable<BookView> collection, string searchText)
        {
            int result = 0;

            if (int.TryParse(searchText, out result))
            {
                grid.ItemsSource = collection
                    .Where(x => x.No != null && x.No.Value.Equals(result));
            }
            else
            {
                grid.ItemsSource = collection
                    .Where(x => x.Author.Contains(searchText)
                                || x.Genre.Contains(searchText)
                                || x.Publisher.Contains(searchText)
                                || x.Serie.Contains(searchText)
                                || x.Name.Contains(searchText));
            }

        } 
    }
}
