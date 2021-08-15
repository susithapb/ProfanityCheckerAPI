using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfanityCheckerAPI.Models
{
    public class Document : BaseEntity
    {
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
