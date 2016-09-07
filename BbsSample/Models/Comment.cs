using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BbsSample.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public DateTime Created { get; set; }
    }
}