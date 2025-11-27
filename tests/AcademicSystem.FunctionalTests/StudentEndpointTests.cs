using System.Net;
using System.Net.Http.Json;
using AcademicSystem.Web.DTOs;
using Xunit;

namespace AcademicSystem.FunctionalTests;

public class StudentEndpointTests : IClassFixture<AcademicSystemFactory<Program>>
{
    private readonly HttpClient _client;

    public StudentEndpointTests(AcademicSystemFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task RegisterStudent_WithValidData_ReturnsCreadted()
    {
        var request = new RegisterStudentRequest(
            Email: "test@functional.com",
            Password: "Password123!",
            FullName: "Student Functional Test",
            RegistrationNumber: "99999",
            Street: "Street Test",
            City: "City Test",
            State: "SP",
            ZipCode: "12345-678"
        );

        var response = await _client.PostAsJsonAsync("/api/students", request);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var result = await response.Content.ReadFromJsonAsync<dynamic>();
        Assert.NotNull(result);
    }
}