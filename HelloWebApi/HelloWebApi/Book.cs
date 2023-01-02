﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloWebApi
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public int GenreId { get; set; }

        public int PageCount { get; set; }

        public DateTime PublishDate { get; set; }

        public string SinirliDavut { get; set; }
        public string papatyacayiic { get; set; }


    }
}
