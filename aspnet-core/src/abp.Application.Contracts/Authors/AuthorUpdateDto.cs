using System;
using System.ComponentModel.DataAnnotations;

namespace abp.Authors
{
    public class AuthorUpdateDto
    {
        public string NameSurname { get; set; }
        public int Age { get; set; }
    }
}