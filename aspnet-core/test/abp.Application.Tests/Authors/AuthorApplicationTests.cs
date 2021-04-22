using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace abp.Authors
{
    public class AuthorAppServiceTests : abpApplicationTestBase
    {
        private readonly IAuthorAppService _authorAppService;
        private readonly IRepository<Author, Guid> _authorRepository;

        public AuthorAppServiceTests()
        {
            _authorAppService = GetRequiredService<IAuthorAppService>();
            _authorRepository = GetRequiredService<IRepository<Author, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _authorAppService.GetListAsync(new GetAuthorsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("dff432a6-0a34-4613-a95c-fa21ce98dde0")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("301107d4-4194-4966-8521-f764e8c0a39e")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _authorAppService.GetAsync(Guid.Parse("dff432a6-0a34-4613-a95c-fa21ce98dde0"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("dff432a6-0a34-4613-a95c-fa21ce98dde0"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new AuthorCreateDto
            {
                NameSurname = "76daf56383d24fbca9a35aa7fe744b672f650c966bdc473cababa7b7647e6bfbc8e254f2",
                Age = 1835516873
            };

            // Act
            var serviceResult = await _authorAppService.CreateAsync(input);

            // Assert
            var result = await _authorRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.NameSurname.ShouldBe("76daf56383d24fbca9a35aa7fe744b672f650c966bdc473cababa7b7647e6bfbc8e254f2");
            result.Age.ShouldBe(1835516873);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new AuthorUpdateDto()
            {
                NameSurname = "c9e35fef00164a8a9de25999fb04bfb726c42600d489421a8fac350cc197947a37850deb7e124ffeb",
                Age = 1164480575
            };

            // Act
            var serviceResult = await _authorAppService.UpdateAsync(Guid.Parse("dff432a6-0a34-4613-a95c-fa21ce98dde0"), input);

            // Assert
            var result = await _authorRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.NameSurname.ShouldBe("c9e35fef00164a8a9de25999fb04bfb726c42600d489421a8fac350cc197947a37850deb7e124ffeb");
            result.Age.ShouldBe(1164480575);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _authorAppService.DeleteAsync(Guid.Parse("dff432a6-0a34-4613-a95c-fa21ce98dde0"));

            // Assert
            var result = await _authorRepository.FindAsync(c => c.Id == Guid.Parse("dff432a6-0a34-4613-a95c-fa21ce98dde0"));

            result.ShouldBeNull();
        }
    }
}