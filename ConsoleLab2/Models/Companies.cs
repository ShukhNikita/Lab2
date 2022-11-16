using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab2.Models
{
    public class Companies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FIO { get; set; }
        public int OwnershipFormId { get; set; }
        public int ActivityTypeId { get; set; }
        public Companies(string Name, string FIO)
        {
            this.Name = Name;
            this.FIO = FIO;
        }
    }
}
