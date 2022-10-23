using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Interfaces;

namespace OuvICEx.API.Domain.Services
{
    public class SearchPostService : ISearchPostService
    {
        private readonly IRepository _repository;

        public SearchPostService(IRepository repository)
        {
            this._repository = repository;
        }

        public List<PostInfo> GetPostsBasedOnSelectionFilter(PostSelectionFilter filter)
        {
            List<PostInfo> posts = _repository.GetPostsBasedOnSelectionFilter(filter);

            posts.RemoveAll(post => post.IsVisible == false);
            return posts;
        }
    }
}
