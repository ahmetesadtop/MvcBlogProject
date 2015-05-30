using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyBlog.DataAccessList
{
    public class ArticleDbContext:DbContext
    {
       public ArticleDbContext() : base("ArticleDb") { }
       public DbSet<Article> Articles { set; get; }

    }
}