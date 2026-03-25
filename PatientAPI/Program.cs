using PatientAPI.Models;
using PatientAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure port for Docker
builder.WebHost.UseUrls("http://0.0.0.0:8080");

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPatientService, PatientService>();

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

// API Endpoints
app.MapGet("/", () => "Patient API is running! - Day 6 Testing Next 🧪");

app.MapGet("/api/patients", (IPatientService service) =>
    Results.Ok(service.GetAllPatients()));

app.MapGet("/api/patients/{id}", (int id, IPatientService service) =>
{
    var patient = service.GetPatientById(id);
    return patient is not null ? Results.Ok(patient) : Results.NotFound();
});

app.MapPost("/api/patients", (Patient patient, IPatientService service) =>
{
    var newPatient = service.AddPatient(patient);
    return Results.Created($"/api/patients/{newPatient.Id}", newPatient);
});

app.Run();

// Make Program accessible to tests
public partial class Program { }