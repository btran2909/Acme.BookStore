using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using abp.Books;
using abp.EntityFrameworkCore;
using Xunit;

namespace abp.Books
{
    public class BookRepositoryTests : abpEntityFrameworkCoreTestBase
    {
        private readonly IBookRepository _bookRepository;

        public BookRepositoryTests()
        {
            _bookRepository = GetRequiredService<IBookRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _bookRepository.GetListAsync(
                    title: "63aa134742734443b71afb5caa8a4198"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("ec221c4c-98a0-4411-b24d-82e2be04c911"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _bookRepository.GetCountAsync(
                    title: "ec4b699884784dbf8f623be0b27c469e4a429281074e427c936c52ec00718a7e6fef19d0d21c4321b0c0af32d85e925b"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}