using REST_API.Objects;

namespace Core.UseCases
{
    public class CoverUseCase
    {
    private readonly IRepository _repo;

        public CoverUseCase(IRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateCover(string title, bool digitalOnly, int bookId)
        {
            var cover = new Covers(title, digitalOnly, bookId);
            await _repo.AddAsync(cover);
        }
        public async Task EditCover(int id, string? title, bool digitalOnly)
        {
            var cover = await _repo.GetByIdAsync<Covers>(id);

            if (!string.IsNullOrWhiteSpace(title) && cover.Title != title)
                cover.Title = title;

            if (cover.DigitalOnly != digitalOnly)
                cover.DigitalOnly = digitalOnly;

            await _repo.UpdateAsync(cover!);
        }
        public async Task DeleteCover(int id)
        {
            var cover = _repo.GetByIdAsync<Covers>(id);
            await _repo.DeleteAsync(cover);
        }
    }
}
