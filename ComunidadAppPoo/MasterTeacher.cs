using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadAppPoo
{
    public class MasterTeacher : Teacher
    {
        public int YearsOfExperience { get; set; }

        public override string GetInformation()
        {
            return $"{base.GetInformation()} - Years of Experience: {YearsOfExperience}";
        }
    }
}
