using abp.Authors;

namespace abp.Books
{
    public class BookWithNavigationProperties
    {
        public Book Book { get; set; }

        public Author Author { get; set; }
        
    }
}