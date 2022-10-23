﻿using OuvICEx.API.Domain.Entities;

namespace OuvICEx.API.Domain.Interfaces
{
    public interface ISearchPostService
    {
        public List<PostInfo> GetPostsBasedOnSelectionFilter(PostSelectionFilter filter);
    }
}
