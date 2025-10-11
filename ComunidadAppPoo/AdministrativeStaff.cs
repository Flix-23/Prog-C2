using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadAppPoo
{
    public class AdministrativeStaff : Employee
    {
        public string Department { get; set; }
        public override string GetInformation()
        {
            return $"{base.GetInformation()} - Department: {Department}";
        }
    }
}
