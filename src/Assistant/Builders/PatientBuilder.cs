using Assistant.Enums;
using Assistant.Models;

namespace Assistant.Builders;

public class PatientBuilder
{
    private DateTime _birthDate;
    private string? _countryCode;
    private string? _firstName;
    private GenderType _gender;
    private string? _gsm;
    private string? _gsmCountryCode;
    private string? _id;
    private string? _lastName;
    private string? _nationalId;
    private string? _passportNumber;
    private Policy _policy;

    public static PatientBuilder Create()
    {
        return new PatientBuilder();
    }

    public PatientBuilder WithId(string? id)
    {
        _id = id;
        return this;
    }

    public PatientBuilder WithGsmCountryCode(string gsmCountryCode)
    {
        _gsmCountryCode = gsmCountryCode;
        return this;
    }

    public PatientBuilder WithGsm(string gsm)
    {
        _gsm = gsm;
        return this;
    }

    public PatientBuilder WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }

    public PatientBuilder WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }

    public PatientBuilder WithCountryCode(string countryCode)
    {
        _countryCode = countryCode;
        return this;
    }

    public PatientBuilder WithNationalId(string? nationalId)
    {
        _nationalId = nationalId;
        return this;
    }

    public PatientBuilder WithPassportNumber(string? passportNumber)
    {
        _passportNumber = passportNumber;
        return this;
    }

    public PatientBuilder WithPolicy(Policy policy)
    {
        _policy = policy;
        return this;
    }

    public PatientBuilder WithBirthDate(DateTime birthDate)
    {
        _birthDate = birthDate;
        return this;
    }

    public PatientBuilder WithGender(GenderType gender)
    {
        _gender = gender;
        return this;
    }

    public Patient Build()
    {
        return new Patient(
            _id,
            _gsmCountryCode,
            _gsm,
            _firstName,
            _lastName,
            _countryCode,
            _nationalId,
            _passportNumber,
            _policy,
            _birthDate,
            _gender
        );
    }
}