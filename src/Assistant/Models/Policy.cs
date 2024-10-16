using System.ComponentModel.DataAnnotations;

namespace Assistant.Models;

public class Policy
{
    [Required] public string Id { get; set; }

    [Required] public string PolicyNumber { get; set; }

    [Required] public DateTime StartDate { get; set; }

    [Required] public DateTime EndDate { get; set; }
}