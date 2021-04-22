using System;
using System.ComponentModel.DataAnnotations;

namespace abp.Books
{
    public class BookUpdateDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public Guid? AuthorId { get; set; }
    }
}