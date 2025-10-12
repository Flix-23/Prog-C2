using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadAppPoo
{
    public class Alumni : CommunityMember
    {
        public int GraduationYear { get; set; }
        public string Degree { get; set; }

        public override string GetInformation()
        {
            return $"{base.GetInformation()} - Degree: {Degree}, Graduation Year: {GraduationYear}";
        }
    }
}
