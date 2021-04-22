using abp.Authors;

using System;
using Volo.Abp.Application.Dtos;

namespace abp.Books
{
    public class BookWithNavigationPropertiesDto
    {
        public BookDto Book { get; set; }

        public AuthorDto Author { get; set; }

    }
}