using Assistant;
using Assistant.Builders;
using Assistant.Enums;
using Assistant.Models;

namespace AssistantTest;

public class ApiCheckTest
{
    private const string ClientId = "client_id";
    private const string ClientSecret = "client_secret";
    private const ServerType Env = ServerType.Development;
    private AssistantClientProvider Client { get; set; }

    private Policy PolicyInstance { get; set; }
    private Patient PatientInstance { get; set; }

    [SetUp]
    public void Setup()
    {
        PolicyInstance = PolicyBuilder.Create()
            .WithId(Guid.NewGuid().ToString())
            .WithPolicyNumber("12345678901")
            .WithStartDate(DateTime.Now)
            .WithEndDate(DateTime.Now.AddYears(1))
            .WithGroup("Custom Field")
            .WithDescription("Test Policy")
            .Build();

        PatientInstance = PatientBuilder.Create()
            .WithId(Guid.NewGuid().ToString())
            .WithGsmCountryCode("+90")
            .WithGsm("5551231234")
            .WithFirstName("Richard")
            .WithLastName("Stallman")
            .WithCountryCode("TUR")
            .WithNationalId("12345678901")
            .WithPassportNumber("12345678901")
            .WithPolicy(PolicyInstance)
            .WithBirthDate(new DateTime(1988, 6, 25))
            .WithGender(GenderType.Male)
            .Build();

        Client = new AssistantClientProvider(ClientId, ClientSecret);
    }

    [Test]
    public async Task AuthenticatePatient()
    {
        var auth = await Client.AuthenticatePatient(PatientInstance);

        Assert.That(auth, Is.Not.Null, "Auth object should not be null");
        Assert.That(auth.Data, Is.Not.Null, "Data object should not be null");
        Assert.That(auth.Data.AccessToken, Is.Not.Null.And.Not.Empty, "Token should not be null or empty");
        Assert.That(auth.Data.AccessTokenExpiredTime, Is.Not.Null.And.GreaterThan(DateTime.UtcNow),
            "AccessTokenExpiredTime should be a valid future date");
        Assert.That(auth.Data.RedirectUrl, Is.Not.Null.And.Not.Empty, "RedirectUrl should not be null or empty");
        Assert.That(auth.Actions, Is.Not.Null, "Actions should not be null");
        Assert.That(auth.Message, Is.EqualTo("success"), "Message should be 'success'");
        Assert.Pass();
    }

    [Test]
    public async Task ValidateToken()
    {
        var auth = await Client.AuthenticatePatient(PatientInstance);
        if (auth.Data.AccessToken != null)
        {
            var validate = await Client.ValidateToken(new ValidateToken
            {
                Token = auth.Data.AccessToken
            });

            Assert.That(validate, Is.Not.Null, "Result object should not be null");
            Assert.That(validate.Data, Is.Not.Null, "Data object should not be null");
            Assert.That(validate.Data.Result, Is.True, "Result should be true");
            Assert.That(validate.Actions, Is.Not.Null, "Actions should not be null");
            Assert.That(validate.Message, Is.EqualTo("success"), "Message should be 'success'");
            Assert.Pass();
        }
        else
        {
            Assert.Fail("Token is null");
        }
    }
}