using System;
using System.Collections.Generic;

namespace CngImageDataModels
{
    public class CngMagazineIssue
    {
        public DateTime IssueDate { get; set; }
        public string ImagePrefix { get; set; }
        public List<CngPageImage> Pages { get; set; }
    }
}