using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using abp.Authors;
using abp.EntityFrameworkCore;
using Xunit;

namespace abp.Authors
{
    public class AuthorRepositoryTests : abpEntityFrameworkCoreTestBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorRepositoryTests()
        {
            _authorRepository = GetRequiredService<IAuthorRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _authorRepository.GetListAsync(
                    nameSurname: "e8bd27b7dac648c48e438cc"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("dff432a6-0a34-4613-a95c-fa21ce98dde0"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _authorRepository.GetCountAsync(
                    nameSurname: "12a09b63946e4be4b49e481dbdde58d9a99907be36ca41a2990c403ddb8e7d89d64666c9197b40359"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}