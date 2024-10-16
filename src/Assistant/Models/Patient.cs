using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assistant.Models;

public class Patient
{
    [Required] [JsonPropertyName("id")] public string Id { get; set; }

    [Required]
    [Phone]
    [JsonPropertyName("gsm")]
    public string Gsm { get; set; }

    [Required]
    [RegularExpression(@"^\+[0-9]{1,3}$", ErrorMessage = "Invalid country code")]
    [JsonPropertyName("gsmCountryCode")]
    public string GsmCountryCode { get; set; }

    [Required]
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [Required]
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Invalid country code")]
    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; }

    [Required]
    [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Invalid National ID")]
    [JsonPropertyName("nationalId")]
    public string NationalId { get; set; }

    [JsonPropertyName("passportNumber")] public string? PassportNumber { get; set; }

    [Required] public Policy Policy { get; set; }

    [Required]
    [JsonPropertyName("birthDate")]
    public DateTime BirthDate { get; set; }
}