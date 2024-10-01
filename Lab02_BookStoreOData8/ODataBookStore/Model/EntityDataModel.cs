namespace ODataBookStore.Model
{
    public class EntityDataModel
    {
        public class Address
        {
            public string City { get; set; }
            public string Country { get; set; }
        }

        public enum Category
        {
            Book,
            Magazine,
            EBook
        }

        public class Press
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Category Category { get; set; }
        }

        // Book class
        public class Book
        {
            public int Id { get; set; }
            public string ISBN { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public decimal Price { get; set; }
            public Address Location { get; set; }
            public Press Press { get; set; }
        }
    }
}
