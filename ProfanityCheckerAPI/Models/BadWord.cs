using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfanityCheckerAPI.Models
{
    public class BadWord : BaseEntity
    {      
        
        public string Word { get; set; }
        public bool IsDeleted { get; set; }
    }
}
