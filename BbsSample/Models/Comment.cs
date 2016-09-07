using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BbsSample.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
    }
}