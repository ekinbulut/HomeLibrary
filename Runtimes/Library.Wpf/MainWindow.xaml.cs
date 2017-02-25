using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Library.UI.Services.Applications;
using Library.UI.Services.Controller;
using Library.UI.Services.Model;

namespace Library.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserModelView _user;
        private readonly IAuthenticatonController _authenticaton;
        private readonly ILibraryController _libraryController;
        private IEnumerable<BookView> _books;

        public MainWindow()
        {
            InitializeComponent();
            UIApplication.StartApplication();

            _authenticaton = UIApplication.AuthenticationController;
            _libraryController = UIApplication.LibraryController;
        }

        public UserModelView User
        {
            get { return _user; }
            set { _user = value; }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Login mechanism
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            var response = _authenticaton.Login(userNametextBox.Text, passwordBox.Password);

            if (response != null)
            {
                User = response;

                story.Begin(this);

                FillBooks();
                BuildAddBooksTab();
            }
        }

        /// <summary>
        /// Connectes to service and retrieve books
        /// </summary>
        private void FillBooks()
        {
            var books = _libraryController.GetBooks(User);
            _books = _libraryController.ConvertBooks(books);

            datagrid.ItemsSource = _books;
        }

        //TODO: update entity
        private void datagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        /// <summary>
        /// Searches Itemsources and updates the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Chenged Text</param>
        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var result = e.Source as TextBox;

            datagrid.FilteredResults(_books, result.Text);

        }

        private void BuildAddBooksTab()
        {
            author_comboBox.FillComboBox(_libraryController.BindAuthors().OrderBy(x => x.Name));
            publisher_comboBox.FillComboBox(_libraryController.BindPublishers().OrderBy(x => x.Name));
            series_comboBox.FillComboBox(_libraryController.BindSeries().OrderBy(x => x.Name));
            genre_comboBox.FillComboBox(_libraryController.BindGenres().OrderBy(x => x.Name));
            skin_comboBox.FillComboBox(_libraryController.BindSkins().OrderBy(x => x.Name));
            shelf_comboBox.FillComboBox(_libraryController.BindShelfs().OrderBy(x => x.Name));
            rack_comboBox.FillComboBox(_libraryController.BindRacks().OrderBy(x => x.Name));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int bookno = 0;

            var input = new BookView
            {
                Author = author_comboBox.SelectedValue.ToString(),
                Genre = genre_comboBox.SelectedValue.ToString(),
                Name = bookName_textbox.Text,
                PublishDate = int.Parse(date_textBox.Text),
                Publisher = publisher_comboBox.SelectedValue.ToString(),
                Rack = (int)rack_comboBox.SelectedValue,
                Serie = series_comboBox.SelectedValue != null ? series_comboBox.SelectedValue.ToString() : String.Empty,
                Shelf = shelf_comboBox.SelectedValue.ToString(),
                SkinType = skin_comboBox.SelectedValue.ToString(),
                No = int.TryParse(no_textBox.Text, out bookno) ? bookno : (int?)null, //what if its an roman integer.
                UserId = _user.UserId

            };

            if (_libraryController.AddBook(input))
            {
                var info = $"New book created : {input.Name}";

                MessageBox.Show(info, "Insert Successfull", 
                    MessageBoxButton.OK,
                    MessageBoxImage.Information, 
                    MessageBoxResult.OK, 
                    MessageBoxOptions.DefaultDesktopOnly);

                FillBooks();
            }
            else
            {
                MessageBox.Show("Error has occured.", 
                    "Insert Error", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error,
                    MessageBoxResult.OK, 
                    MessageBoxOptions.DefaultDesktopOnly);
            }

        }
    }
}
