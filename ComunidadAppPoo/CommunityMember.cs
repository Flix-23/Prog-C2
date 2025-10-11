using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadAppPoo
{
    public abstract class CommunityMember
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Identification { get; set; }

        public virtual string GetInformation()
        {
            return $"{Name}, {Age} years old, ID: {Identification}";
        }
    }
}
