﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
            _newsDal.Add(news);
            return new SuccessResult(Messages.NewsAdded);
        }

        public IResult Delete(News news)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<News>> GetAll()
        {
            return new SuccessDataResult<List<News>>(_newsDal.GetAll());
        }

        public IDataResult<News> GetById(int newsId)
        {
            return new SuccessDataResult<News>(_newsDal.Get(x => x.Id == newsId));
        }

        public IResult Update(News news)
        {
            throw new NotImplementedException();
        }
    }
}