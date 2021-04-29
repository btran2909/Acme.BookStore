using System;
using System.ComponentModel.DataAnnotations;

namespace Volo.Test.Pro.AuthorPros
{
    public class AuthorUpdateDto
    {
        public string NameSurname { get; set; }
        public int Age { get; set; }
    }
}