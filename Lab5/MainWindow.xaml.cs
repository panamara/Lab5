using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows;

namespace Lab5
{
    public partial class MainWindow : Window
    {
        public SerializableLibrary Books { get; set; } 

        public MainWindow()
        {
            InitializeComponent();
            LoadBooks();
            this.DataContext = this;
        }

        private void LoadBooks()
        {
            Books = new SerializableLibrary();
            BookBuilder bookone = new BookMaker();
            Book book = bookone
                .SetTitle("The Lord of the Rings")
                .SetAuthor("J. R. R. Tolkien")
                .SetGenres(new[] { "Fantasy", "Adventure" })
                .SetISBN("978-0-618-57498-4")
                .SetPublicationDate(new DateTime(1954, 7, 29))
                .SetAnnotation("The Lord of the Rings is an epic high-fantasy novel written by English author and scholar J. R. R. Tolkien.")
                .SetTags(new[] { "fantasy", "adventure", "classic" })
                .Build();
            Books.AddBook(book);


            BookCatalog.ItemsSource = Books.GetCatalog();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
        }
        private void FilterBooks_Click(object sender, RoutedEventArgs e)
        {  
        }
    }
}