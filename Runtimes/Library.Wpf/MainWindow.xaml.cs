using System;
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
        private UserModel _user;
        private readonly IAuthenticatonController _authenticaton;
        private readonly ILibraryController _libraryController;

        public MainWindow()
        {
            InitializeComponent();
            UIApplication.StartApplication();

            _authenticaton = UIApplication.AuthenticationController;
            _libraryController = UIApplication.LibraryController;
        }

        public UserModel User
        {
            get { return _user; }
            set { _user = value; }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            dataGrid.Visibility = Visibility.Hidden;
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            var response = _authenticaton.Login(userNametextBox.Text, passwordBox.Password);
            
            if (response != null)
            {
                User = response;

                story.Begin(this);

                //TODO : get the books
                FillBooks();
            }
        }

        private void FillBooks()
        {
            var books = _libraryController.GetBooks(User);
            dataGrid.Visibility = Visibility.Visible;
            dataGrid.ItemsSource = books;
        } 
    }
}
