using System.ComponentModel.DataAnnotations;

namespace HospitalApi.models
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;


        public ICollection<Patient>? Patients { get; set; }
    }
}
