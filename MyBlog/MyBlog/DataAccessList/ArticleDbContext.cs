using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyBlog.DAL
{
    public class ArticleDbContext : DbContext
    {
        public DbSet<Article> Articles { set; get; }

    }
}