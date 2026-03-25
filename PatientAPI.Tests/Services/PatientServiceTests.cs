using PatientAPI.Models;
using PatientAPI.Services;
using FluentAssertions;

namespace PatientAPI.Tests.Services;

public class PatientServiceTests
{
    private readonly PatientService _service;

    public PatientServiceTests()
    {
        _service = new PatientService();
    }

    [Fact]
    public void GetAllPatients_ShouldReturnAllPatients()
    {
        // Act
        var patients = _service.GetAllPatients();

        // Assert
        patients.Should().NotBeNull();
        patients.Should().HaveCount(2);
        patients.Should().Contain(p => p.Name == "John Doe");
    }

    [Fact]
    public void GetPatientById_WithValidId_ShouldReturnPatient()
    {
        // Arrange
        var expectedId = 1;

        // Act
        var patient = _service.GetPatientById(expectedId);

        // Assert
        patient.Should().NotBeNull();
        patient!.Id.Should().Be(expectedId);
        patient.Name.Should().Be("John Doee");
    }

    [Fact]
    public void GetPatientById_WithInvalidId_ShouldReturnNull()
    {
        // Arrange
        var invalidId = 999;

        // Act
        var patient = _service.GetPatientById(invalidId);

        // Assert
        patient.Should().BeNull();
    }

    [Fact]
    public void AddPatient_ShouldAddPatientWithNewId()
    {
        // Arrange
        var newPatient = new Patient
        {
            Name = "Test Patient",
            Age = 30,
            Condition = "Healthy"
        };

        // Act
        var result = _service.AddPatient(newPatient);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(3); // Should be next ID
        result.Name.Should().Be("Test Patient");

        var allPatients = _service.GetAllPatients();
        allPatients.Should().HaveCount(3);
    }

    [Theory]
    [InlineData(1, "John Doe")]
    [InlineData(2, "Jane Smith")]
    public void GetPatientById_WithMultipleIds_ShouldReturnCorrectPatient(int id, string expectedName)
    {
        // Act
        var patient = _service.GetPatientById(id);

        // Assert
        patient.Should().NotBeNull();
        patient!.Name.Should().Be(expectedName);
    }
}