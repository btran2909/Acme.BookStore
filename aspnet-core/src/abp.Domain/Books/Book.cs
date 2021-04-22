using abp.Authors;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace abp.Books
{
    public class Book : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string Title { get; set; }

        public virtual int Year { get; set; }
        public Guid? AuthorId { get; set; }

        public Book()
        {

        }

        public Book(Guid id, string title, int year)
        {
            Id = id;
            Title = title;
            Year = year;
        }
    }
}