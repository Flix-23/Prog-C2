using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadAppPoo
{
    public abstract class Teacher : Employee
    {
        public string Subject { get; set; }
        public override string GetInformation()
        {
            return $"{base.GetInformation()} - Subject: {Subject}";
        }
    }
}
