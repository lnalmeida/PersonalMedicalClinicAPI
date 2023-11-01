using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMC.Core.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; } = string.Empty.PadLeft(10, '0');
        public string Document { get; set; } = string.Empty;
    }
}
