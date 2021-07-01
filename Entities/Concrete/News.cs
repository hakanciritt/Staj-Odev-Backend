using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class News : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
    }
}
