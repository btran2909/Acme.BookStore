using System;
using Volo.Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;

namespace Volo.Test.Pro.AuthorPros
{
    public class Author : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string NameSurname { get; set; }

        public virtual int Age { get; set; }

        public Author()
        {

        }

        public Author(Guid id, string nameSurname, int age)
        {
            Id = id;
            NameSurname = nameSurname;
            Age = age;
        }
    }
}