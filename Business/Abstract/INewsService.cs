using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface INewsService
    {
        IResult Add(News news);
        IResult Delete(News news);
        IResult Update(News news);
        IDataResult<List<News>> GetAll();
        IDataResult<News> GetById(int newsId);
        IDataResult<List<NewsDetailDto>> GetNewsDetails();
        IDataResult<NewsDetailDto> GetNewsDetail(int newsId);
    }
}
