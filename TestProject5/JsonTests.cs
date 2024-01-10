
namespace WpfApp5.TestProject5
{

    public class JsonTests
    {
        [Fact]
        public void JsonTest()
        {
            var library = new SerializableLibrary();
            var bookBuilder = new BookBuilder();
            var book = bookBuilder
                .SetTitle("The Lord of the Rings")
                .SetAuthor("J. R. R. Tolkien")
                .SetGenres(new[] { "Fantasy", "Adventure" })
                .SetISBN("978-0-618-57498-4")
                .SetPublicationDate(new DateTime(1954, 7, 29))
                .SetAnnotation("The Lord of the Rings is an epic high-fantasy novel written by English author and scholar J. R. R. Tolkien.")
                .SetTags(new[] { "fantasy", "adventure", "classic" })
                .Build();
            library.AddBook(book);
            var secondBookBuilder = new BookBuilder();
            var secondBook = secondBookBuilder
                .SetTitle("The Hobbit")
                .SetAuthor("J. R. R. Tolkien")
                .SetGenres(new[] { "Fantasy", "Adventure" })
                .SetISBN("978-0-618-57498-5")
                .SetPublicationDate(new DateTime(1937, 9, 21))
                .SetAnnotation("The Hobbit, or There and Back Again is a children's fantasy novel by English author J. R. R. Tolkien.")
                .SetTags(new[] { "fantasy", "adventure", "classic" })
                .Build();
            library.AddBook(secondBook);
            string json = library.JsonSerialize();
            var loadLibrary = new SerializableLibrary();
            loadLibrary.LoadFromJson(json);

            Assert.True(BookComparator.CompareBookLists(library.GetCatalog().ToList(), loadLibrary.GetCatalog().ToList()));
        }
    }
}
