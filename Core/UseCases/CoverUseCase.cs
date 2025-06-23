using REST_API.Objects;

namespace Core.UseCases
{
    public class CoverUseCase : CrudUseCase<Covers>
    {
        public CoverUseCase(IGenericRepo genericRepo) : base(genericRepo)
        {
        }

        public async Task CreateCover(string title, bool digitalOnly, int bookId)
        {
            var cover = new Covers(title, digitalOnly, bookId);
            await AddAsync(cover);
        }
        public async Task EditCover(int id, string? title, bool digitalOnly)
        {
            var cover = await GetByIdAsync(id);

            if (!string.IsNullOrWhiteSpace(title) && cover.Title != title)
                cover.Title = title;

            if (cover.DigitalOnly != digitalOnly)
                cover.DigitalOnly = digitalOnly;

            await UpdateAsync(cover!);
        }
        public async Task DeleteCover(int id)
        {
            var cover = await GetByIdAsync(id);
            await DeleteAsync(cover);
        }
    }
}
