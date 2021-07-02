using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class NewsManager : INewsService
    {
        private INewsDal _newsDal;
        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        public IResult Add(News news)
        {
            ValidationTool.Validate(new NewsValidator(), news);
            IResult result = BusinessRules.Run(CheckIfNewsExists(news));
            if (result != null)
            {
                return result;
            }
            _newsDal.Add(news);
            return new SuccessResult(Messages.NewsAdded);
        }

        public IResult Delete(News news)
        {
            _newsDal.Delete(news);
            return new SuccessResult(Messages.NewsDeleted);
        }

        public IDataResult<List<News>> GetAll()
        {
            return new SuccessDataResult<List<News>>(_newsDal.GetAll());
        }

        public IDataResult<News> GetById(int newsId)
        {
            return new SuccessDataResult<News>(_newsDal.Get(x => x.Id == newsId));
        }

        public IDataResult<NewsDetailDto> GetNewsDetail(int newsId)
        {
            return new SuccessDataResult<NewsDetailDto>(_newsDal.GetNewsDetail(x => x.Id == newsId));
        }

        public IDataResult<List<NewsDetailDto>> GetNewsDetails()
        {
            return new SuccessDataResult<List<NewsDetailDto>>(_newsDal.GetNewsDetails());
        }

        public IResult Update(News news)
        {
            _newsDal.Update(news);
            return new SuccessResult(Messages.NewsUpdated);
        }
        private IResult CheckIfNewsExists(News news)
        {
            if (_newsDal.Get(x => x.Title == news.Title && x.Date == news.Date) != null)
            {
                return new ErrorResult(Messages.ThereIsAlreadyExists);
            }
            return null;
        }
    }
}
