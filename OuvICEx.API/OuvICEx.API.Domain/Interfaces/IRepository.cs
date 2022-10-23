using OuvICEx.API.Domain.Entities;

namespace OuvICEx.API.Domain.Interfaces
{
    public interface IRepository
    {
        public List<PostInfo> GetPostsBasedOnSelectionFilter(PostSelectionFilter filter);
    }
}
