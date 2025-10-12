using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadAppPoo
{
    public class Administrator : Teacher
    {
        public string AdministrativeArea { get; set; }
        public override string GetInformation()
        {
            return $"{base.GetInformation()} - Area: {AdministrativeArea}";
        }
    }
}
