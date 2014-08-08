using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMiner.Domain
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// Список наименований (латинскими буквами) хабов, разделенных запятыми
        /// </summary>
        public string Hubs { get; set; }


        public DateTime? PublicationDate { get; set; }

        public string Excerpt { get; set; }

        public PostType PostType { get; set; }
    }
}