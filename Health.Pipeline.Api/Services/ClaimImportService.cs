using CsvHelper;
using Health.Pipeline.Api.Data;
using Health.Pipeline.Api.Models;
using System.Globalization;

namespace Health.Pipeline.Api.Services
{
    public class ClaimImportService
    {
        private readonly ClaimsDbContext _db;

        public ClaimImportService(ClaimsDbContext db)
        {
            _db = db;
        }

        public async Task<List<Claim>> ImportCsvAsync(Stream csvStream)
        {
            var claims = new List<Claim>();
            using var reader = new StreamReader(csvStream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<dynamic>();
            foreach (var record in records)
            {
                var dict = (IDictionary<string, object>)record;
                claims.Add(new Claim
                {
                    Id = Guid.NewGuid(),
                    PatientId = dict["patient_id"].ToString(),
                    DateOfService = DateTime.Parse(dict["date_of_service"].ToString()),
                    Amount = decimal.Parse(dict["amount"].ToString()),
                    Provider = dict["provider"].ToString()
                });
            }

            _db.Claims.AddRange(claims);
            await _db.SaveChangesAsync();
            return claims;
        }
    }
}
