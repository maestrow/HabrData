using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HabrData.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Excerpt { get; set; }
    }
}