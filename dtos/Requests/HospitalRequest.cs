using System.ComponentModel.DataAnnotations;

namespace HospitalApi.dtos.Requests
{
    public class HospitalRequest
    {
        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;
    }
}
