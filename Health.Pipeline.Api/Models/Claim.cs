using System;

namespace Health.Pipeline.Api.Models
{
    public class Claim
    {
        public Guid Id { get; set; }
        public string PatientId { get; set; }
        public DateTime DateOfService { get; set; }
        public decimal Amount { get; set; }
        public string Provider { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
