using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfanityCheckerAPI.Models
{
    public class ProfanityDocument : BaseEntity
    {
        
        public Document Document { get; set; }
        public int DocumentId { get; set; }
        public BadWord BadWord { get; set; }
        public int BadWordId { get; set; }
    }
}
