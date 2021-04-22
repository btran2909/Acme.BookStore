using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using abp.Books;

namespace abp.Books
{
    public class BooksDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IBookRepository _bookRepository;

        public BooksDataSeedContributor(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _bookRepository.InsertAsync(new Book
            (
                id: Guid.Parse("ec221c4c-98a0-4411-b24d-82e2be04c911"),
                title: "63aa134742734443b71afb5caa8a4198",
                year: 167247840
            ));

            await _bookRepository.InsertAsync(new Book
            (
                id: Guid.Parse("df4ea640-40ed-4b98-b14b-3dcb4c1fd857"),
                title: "ec4b699884784dbf8f623be0b27c469e4a429281074e427c936c52ec00718a7e6fef19d0d21c4321b0c0af32d85e925b",
                year: 1368617974
            ));
        }
    }
}