using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using PatientAPI.Models;
using FluentAssertions;

namespace PatientAPI.Tests.Integration;

public class PatientApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PatientApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task HealthCheck_ShouldReturnOk()
    {
        // Act
        var response = await _client.GetAsync("/");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("Patient API is running");
    }

    [Fact]
    public async Task GetAllPatients_ShouldReturnListOfPatients()
    {
        // Act
        var response = await _client.GetAsync("/api/patients");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var patients = await response.Content.ReadFromJsonAsync<List<Patient>>();
        patients.Should().NotBeNull();
        patients.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetPatientById_WithValidId_ShouldReturnPatient()
    {
        // Act
        var response = await _client.GetAsync("/api/patients/1");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var patient = await response.Content.ReadFromJsonAsync<Patient>();
        patient.Should().NotBeNull();
        patient!.Id.Should().Be(1);
        patient.Name.Should().Be("John Doe");
    }

    [Fact]
    public async Task GetPatientById_WithInvalidId_ShouldReturnNotFound()
    {
        // Act
        var response = await _client.GetAsync("/api/patients/999");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task CreatePatient_WithValidData_ShouldReturnCreated()
    {
        // Arrange
        var newPatient = new Patient
        {
            Name = "Integration Test Patient",
            Age = 40,
            Condition = "Test Condition"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/patients", newPatient);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdPatient = await response.Content.ReadFromJsonAsync<Patient>();
        createdPatient.Should().NotBeNull();
        createdPatient!.Name.Should().Be("Integration Test Patient");
        createdPatient.Id.Should().BeGreaterThan(0);

        response.Headers.Location.Should().NotBeNull();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async Task GetPatientById_WithMultipleValidIds_ShouldReturnCorrectPatients(int id)
    {
        // Act
        var response = await _client.GetAsync($"/api/patients/{id}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var patient = await response.Content.ReadFromJsonAsync<Patient>();
        patient.Should().NotBeNull();
        patient!.Id.Should().Be(id);
    }
}