using Volo.Abp.Application.Dtos;
using System;

namespace abp.Authors
{
    public class GetAuthorsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string NameSurname { get; set; }
        public int? AgeMin { get; set; }
        public int? AgeMax { get; set; }

        public GetAuthorsInput()
        {

        }
    }
}