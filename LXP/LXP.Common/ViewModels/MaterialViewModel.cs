using LXP.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LXP.Common.ViewModels
{
    public class MaterialViewModel
    {

        public Guid TopicId { get; set; }

        public Guid MaterialTypeId { get; set; }

        public string Name { get; set; } 

        public string FilePath { get; set; } 

        public decimal Duration { get; set; }

        
        public string CreatedBy { get; set; } 

      
    }
}
