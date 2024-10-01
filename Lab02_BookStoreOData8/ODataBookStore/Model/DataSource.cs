using static ODataBookStore.Model.EntityDataModel;

namespace ODataBookStore.Model
{
    public static class DataSource
    {
        private static IList<Book> listBooks { get; set; }
        public static IList<Book> GetBooks()
        {
            if (listBooks != null)
            {
                return listBooks;
            }

            listBooks = new List<Book>()
            {
                 new Book
        {
            Id = 1,
            ISBN = "978-3-16-148410-0",
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            Price = 25.99M,
            Location = new Address
            {
                City = "New York",
                Country = "USA"
            },
            Press = new Press
            {
                Id = 1,
                Name = "Penguin Press",
                Category = Category.Book
            }
        },
        new Book
        {
            Id = 2,
            ISBN = "978-1-86197-876-9",
            Title = "1984",
            Author = "George Orwell",
            Price = 15.99M,
            Location = new Address
            {
                City = "London",
                Country = "UK"
            },
            Press = new Press
            {
                Id = 2,
                Name = "HarperCollins",
                Category = Category.Book
            }
        },
        new Book
        {
            Id = 3,
            ISBN = "978-0-14-103613-7",
            Title = "Brave New World",
            Author = "Aldous Huxley",
            Price = 19.99M,
            Location = new Address
            {
                City = "London",
                Country = "UK"
            },
            Press = new Press
            {
                Id = 3,
                Name = "Random House",
                Category = Category.EBook
            }
        },
        new Book
        {
            Id = 4,
            ISBN = "978-0-7432-7356-5",
            Title = "To Kill a Mockingbird",
            Author = "John Doe",
            Price = 24.99M,
            Location = new Address
            {
                City = "Los Angeles",
                Country = "USA"
            },
            Press = new Press
            {
                Id = 4,
                Name = "Vintage Books",
                Category = Category.Magazine
            }
        },
        new Book
        {
            Id = 5,
            ISBN = "978-1-56619-909-4",
            Title = "The Catcher in the Rye",
            Author = "J.D. Salinger",
            Price = 17.99M,
            Location = new Address
            {
                City = "New York",
                Country = "USA"
            },
            Press = new Press
            {
                Id = 5,
                Name = "Little, Brown and Company",
                Category = Category.Book
            }
        },
        new Book
        {
            Id = 6,
            ISBN = "978-0-545-01022-1",
            Title = "Moby Dick",
            Author = "John Smith",
            Price = 22.50M,
            Location = new Address
            {
                City = "Boston",
                Country = "USA"
            },
            Press = new Press
            {
                Id = 6,
                Name = "Houghton Mifflin",
                Category = Category.EBook
            }
        },
        new Book
        {
            Id = 7,
            ISBN = "978-0-345-39180-3",
            Title = "The Hobbit",
            Author = "John Tolkien",
            Price = 30.00M,
            Location = new Address
            {
                City = "Edinburgh",
                Country = "UK"
            },
            Press = new Press
            {
                Id = 7,
                Name = "George Allen & Unwin",
                Category = Category.Book
            }
        },
        new Book
        {
            Id = 8,
            ISBN = "978-0-393-04002-9",
            Title = "War and Peace",
            Author = "Leo Tolstoy",
            Price = 40.00M,
            Location = new Address
            {
                City = "Moscow",
                Country = "Russia"
            },
            Press = new Press
            {
                Id = 8,
                Name = "Oxford University Press",
                Category = Category.Magazine
            }
        },
        new Book
        {
            Id = 9,
            ISBN = "978-0-141-03495-1",
            Title = "John's Adventure",
            Author = "John Smith",
            Price = 35.00M,
            Location = new Address
            {
                City = "New York",
                Country = "USA"
            },
            Press = new Press
            {
                Id = 9,
                Name = "EBook Press",
                Category = Category.EBook
            }
        }
            };
            //var book = new Book()
            //{
            //    Id = 1,
            //    ISBN = "978-0-321-87758-1",
            //    Title = "Essential C#5.0",
            //    Author = "Mark Michaelis",
            //    Price = 59.99m,
            //    Location = new Address()
            //    {
            //        City = "HCM City",
            //        Country = "Viet Nam",
            //    },
            //    Press = new Press()
            //    {
            //        Id = 1,
            //        Name = "Addison-Wesley",
            //        Category = Category.Book,
            //    }
            //};
            //listBooks.Add(book);

            return listBooks;
        }
    }
}
