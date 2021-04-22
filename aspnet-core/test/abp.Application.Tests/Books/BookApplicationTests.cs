using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace abp.Books
{
    public class BookAppServiceTests : abpApplicationTestBase
    {
        private readonly IBookAppService _bookAppService;
        private readonly IRepository<Book, Guid> _bookRepository;

        public BookAppServiceTests()
        {
            _bookAppService = GetRequiredService<IBookAppService>();
            _bookRepository = GetRequiredService<IRepository<Book, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _bookAppService.GetListAsync(new GetBooksInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Book.Id == Guid.Parse("ec221c4c-98a0-4411-b24d-82e2be04c911")).ShouldBe(true);
            result.Items.Any(x => x.Book.Id == Guid.Parse("df4ea640-40ed-4b98-b14b-3dcb4c1fd857")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _bookAppService.GetAsync(Guid.Parse("ec221c4c-98a0-4411-b24d-82e2be04c911"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("ec221c4c-98a0-4411-b24d-82e2be04c911"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new BookCreateDto
            {
                Title = "b0a0a1bdc3ba4bf8b6cc4e52e",
                Year = 1135706819
            };

            // Act
            var serviceResult = await _bookAppService.CreateAsync(input);

            // Assert
            var result = await _bookRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Title.ShouldBe("b0a0a1bdc3ba4bf8b6cc4e52e");
            result.Year.ShouldBe(1135706819);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new BookUpdateDto()
            {
                Title = "c0ff9dcbe7cc44e39f7916e7af801431358be0bc96334d37b3",
                Year = 102927255
            };

            // Act
            var serviceResult = await _bookAppService.UpdateAsync(Guid.Parse("ec221c4c-98a0-4411-b24d-82e2be04c911"), input);

            // Assert
            var result = await _bookRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Title.ShouldBe("c0ff9dcbe7cc44e39f7916e7af801431358be0bc96334d37b3");
            result.Year.ShouldBe(102927255);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _bookAppService.DeleteAsync(Guid.Parse("ec221c4c-98a0-4411-b24d-82e2be04c911"));

            // Assert
            var result = await _bookRepository.FindAsync(c => c.Id == Guid.Parse("ec221c4c-98a0-4411-b24d-82e2be04c911"));

            result.ShouldBeNull();
        }
    }
}