using Assistant;
using Assistant.Enums;
using Assistant.Models;

namespace AssistantTest;

public class ApiCheckTest
{
    private const string ClientId = "client_id";
    private const string ClientSecret = "client_secret";
    private const ServerType Env = ServerType.Development;
    private AssistantClientProvider Client { get; set; }

    [SetUp]
    public void Setup()
    {
        Client = new AssistantClientProvider(ClientId, ClientSecret, Env);
    }
    
    [Test]
    public async Task Authentication()
    {
        var patient = new Patient()
        {
            Id = Guid.NewGuid().ToString(),
            GsmCountryCode = "+90",
            Gsm = "5551231234",
            FirstName = "Richard",
            LastName = "Stallman",
            CountryCode = "TUR",
            NationalId = "12345678901",
            PassportNumber = "12345678901",
            Policy = new Policy
            {
                Id = Guid.NewGuid().ToString(),
                PolicyNumber = "12345678901",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            },
            BirthDate = new DateTime(1988, 6, 25)
        };
        var auth = await Client.Authenticate(patient);
        
        Assert.That(auth, Is.Not.Null, "Auth object should not be null");
        Assert.That(auth.Data, Is.Not.Null, "Data object should not be null");
        Assert.That(auth.Data.AccessToken, Is.Not.Null, "Token should not be null or empty");
        Assert.Pass();
    }
}