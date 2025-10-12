using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadAppPoo
{
    public class Student : CommunityMember
    {
        public string Major { get; set; }
        public int Semester { get; set; }

        public override string GetInformation()
        {
            return $"{base.GetInformation()} - Major: {Major}, Semester: {Semester}";
        }
    }
}
