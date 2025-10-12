
namespace HospitalApi.dtos.Responses
{
    public class PatientResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int HospitalId { get; set; }
        public string HospitalName { get; set; } = string.Empty;

    }
}
