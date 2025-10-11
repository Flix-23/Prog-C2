using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadAppPoo
{
    public abstract class Employee : CommunityMember
    {
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public override string GetInformation()
        {
            return $"{base.GetInformation()} - Position: {Position}, Salary: {Salary:C}";
        }
    }
}
