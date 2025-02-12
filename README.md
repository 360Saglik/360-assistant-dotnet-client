# 360 Assistant Dot Net Client Library

This library provides a simple way to authenticate and interact with an assistant API using `HttpClient`. The `AssistantClientProvider` class helps in setting up authentication and sending requests to the server.

## Features

- **Authentication**: Authenticate users with the provided patient information.
- **Server Communication**: Send requests to different server environments (Development, Production, etc.).

## 📋 Requirements

- .NET 6.0+
- API Key 

## 🛠️ Setup

Add the package to your project via NuGet:

```bash
dotnet add package 360Saglik.Assistant.ClientLibrary
```

## Nuget Package Manager

https://www.nuget.org/packages/360Saglik.Assistant.ClientLibrary

## 💻 Usage

```csharp
using System.Text.Json;
using Assistant;
using Assistant.Builders;
using Assistant.Enums;

var client = new AssistantClientProvider(clientId: "client_id", clientSecret: "client_secret", ServerType.Development);
var policyInstance = PolicyBuilder.Create()
    .WithId(Guid.NewGuid().ToString())
    .WithPolicyNumber("12345678901")
    .WithStartDate(DateTime.Now)
    .WithEndDate(DateTime.Now.AddYears(1))
    .WithGroup("Custom Field")
    .WithDescription("Test Policy")
    .Build();

var patient = PatientBuilder.Create()
    .WithId(Guid.NewGuid().ToString())
    .WithGsmCountryCode("+90")
    .WithGsm("5551231234")
    .WithFirstName("Richard")
    .WithLastName("Stallman")
    .WithCountryCode("TUR")
    .WithNationalId("12345678901")
    .WithPassportNumber("12345678901")
    .WithPolicy(policyInstance)
    .WithBirthDate(new DateTime(1988, 6, 25))
    .WithGender(GenderType.Male)
    .Build();

var auth = await client.AuthenticatePatientAsync(patient);

Console.WriteLine(JsonSerializer.Serialize(auth));
```

## Response

```json
{
    "Data": {
        "AccessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwdWJsaWNLZXkiOiIxZjcyNWRiNi01MjRjLTQwM2Qt.....",
        "AccessTokenExpiredTime": "2025-02-19T12:26:56.019Z",
        "RedirectUrl": "https://uri.360saglik.dev/OwXTRSuCJmPF1zt"
    },
    "Actions": [],
    "Message": "success",
    "IsSuccess": true,
    "StatusCode": 200,
    "Error": null
}
```

## 📝 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için [LICENSE](LICENSE) dosyasına bakın.

