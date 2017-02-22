using System;
using System.Collections.Generic;
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

            datagrid.FilteredResults(_books,result.Text);

        }
    }
}
