using System;
using System.ComponentModel.DataAnnotations;

namespace abp.Authors
{
    public class AuthorCreateDto
    {
        public string NameSurname { get; set; }
        public int Age { get; set; }
    }
}