using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assistant.Models;

/// <summary>
///     Represents a patient in the assistants app.
/// </summary>
public class Patient
{
    /// <summary>
    ///     Unique identifier for the patient.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    ///     Patient's mobile phone number, required in a valid phone format.
    /// </summary>
    [Phone]
    [JsonPropertyName("gsm")]
    public string Gsm { get; set; }

    /// <summary>
    ///     Country code for the patient's mobile number, in the format +code.
    ///     Example: "+90" for Turkey.
    /// </summary>
    [RegularExpression(@"^\+[0-9]{1,3}$", ErrorMessage = "Invalid country code")]
    [JsonPropertyName("gsmCountryCode")]
    public string GsmCountryCode { get; set; }

    /// <summary>
    ///     Patient's first name.
    /// </summary>
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    /// <summary>
    ///     Patient's last name.
    /// </summary>
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    /// <summary>
    ///     ISO 3166-1 alpha-3 country code representing the patient's nationality.
    ///     Example: "TUR" for the Turkey.
    ///     Example: Check the others nationalities -> https://en.wikipedia.org/wiki/ISO_3166-1_alpha-3
    /// </summary>
    [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Invalid country code")]
    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; }

    /// <summary>
    ///     Patient's national identification number. Must be exactly 11 digits.
    /// </summary>
    [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Invalid National ID")]
    [JsonPropertyName("nationalId")]
    public string NationalId { get; set; }

    /// <summary>
    ///     Optional passport number for the patient.
    /// </summary>
    [JsonPropertyName("passportNumber")]
    public string? PassportNumber { get; set; }

    /// <summary>
    ///     Insurance policy details associated with the patient.
    /// </summary>
    [JsonPropertyName("policy")]
    public Policy Policy { get; set; }

    /// <summary>
    ///     Patient's date of birth.
    /// </summary>
    [JsonPropertyName("birthDate")]
    public DateTime BirthDate { get; set; }

    /// <summary>
    ///     Patient's gender, represented by an integer value.
    ///     Example: 1 for Male, 2 for Female, 3 for Unknown.
    /// </summary>
    [JsonPropertyName("gender")]
    public int Gender { get; set; }
}