using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface INewsDal : IEntityRepository<News>
    {
        List<NewsDetailDto> GetNewsDetails();
        List<NewsDetailDto> GetNewsDetails(Expression<Func<NewsDetailDto, bool>> filter);
        NewsDetailDto GetNewsDetail(Expression<Func<NewsDetailDto, bool>> filter);
    }
}
