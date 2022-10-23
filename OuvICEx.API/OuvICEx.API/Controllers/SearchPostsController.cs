using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OuvICEx.API.Domain.Entities;
using OuvICEx.API.Domain.Interfaces;

namespace OuvICEx.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchPostsController : ControllerBase
    {
        private readonly ISearchPostService _searchPostService;

        public SearchPostsController(ISearchPostService searchPostService)
        {
            _searchPostService = searchPostService;
        }

        [HttpGet]
        [Route("get_posts_based_on_selection_filter")]
        public List<PostInfo> Get()
        {
            PostSelectionFilter filter = new PostSelectionFilter { AuthorDepartament = "DCC" }; // isso deveria vir da URL
            return _searchPostService.GetPostsBasedOnSelectionFilter(filter);
        }
    }
}