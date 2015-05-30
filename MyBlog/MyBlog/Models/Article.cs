using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class Article
    {

        public int ID { get; set; }
        public string Author { set; get; }
        [Editable(false)]
        public DateTime Date { set; get; }
        public string Title { set; get; }
        public string Content { set; get; }
        public Article()
        {
            Date = DateTime.Now;
        }
        public string image { set; get; }
    }


}