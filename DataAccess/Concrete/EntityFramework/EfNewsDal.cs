using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNewsDal : EfEntityRepositoryBase<News, NewsContext>, INewsDal
    {
        public NewsDetailDto GetNewsDetail(Expression<Func<NewsDetailDto, bool>> filter)
        {
            using (NewsContext context = new NewsContext())
            {
                var result = (from news in context.News.Cast<News>()
                              join category in context.Categories.Cast<Category>()
                              on news.CategoryId equals category.Id
                              select new NewsDetailDto
                              {
                                  Id = news.Id,
                                  Title = news.Title,
                                  CategoryId = category.Id,
                                  CategoryName = category.Name,
                                  Body = news.Body,
                                  Date = news.Date,
                                  ImagePath = news.ImagePath
                              }).FirstOrDefault(filter);
                return result;
            }
        }

        public List<NewsDetailDto> GetNewsDetails()
        {
            using (NewsContext context=new NewsContext())
            {
                var result = (from news in context.News.Cast<News>()
                              join category in context.Categories.Cast<Category>()
                              on news.CategoryId equals category.Id
                              select new NewsDetailDto
                              {
                                  Id = news.Id,
                                  Title = news.Title,
                                  CategoryId=category.Id,
                                  CategoryName = category.Name,
                                  Body = news.Body,
                                  Date = news.Date,
                                  ImagePath = news.ImagePath
                              }).ToList();
                return result;
            }
        }

        public List<NewsDetailDto> GetNewsDetails(Expression<Func<NewsDetailDto, bool>> filter)
        {
            using (NewsContext context = new NewsContext())
            {
                var result = (from news in context.News.Cast<News>()
                              join category in context.Categories.Cast<Category>()
                              on news.CategoryId equals category.Id
                              select new NewsDetailDto
                              {
                                  Id = news.Id,
                                  Title = news.Title,
                                  CategoryId = category.Id,
                                  CategoryName = category.Name,
                                  Body = news.Body,
                                  Date = news.Date,
                                  ImagePath = news.ImagePath
                              }).Where(filter).ToList();
                return result;
            }
        }
    }
}
