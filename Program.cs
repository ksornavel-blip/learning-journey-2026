var builder = WebApplication.CreateBuilder(args);

// Add this line ?
builder.WebHost.UseUrls("http://0.0.0.0:8080");

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger (API documentation)
app.UseSwagger();
app.UseSwaggerUI();

// In-memory patient list
var patients = new List<Patient>
{
    new Patient { Id = 1, Name = "John Doe", Age = 45, Condition = "Hypertension" },
    new Patient { Id = 2, Name = "Jane Smith", Age = 32, Condition = "Diabetes" },
    new Patient { Id = 3, Name = "Test Smith", Age = 32, Condition = "Cancer" }
};

// API Endpoints
app.MapGet("/", () => "Patient API is running! - Deployed via CI/CD!");

app.MapGet("/api/patients", () => patients);

app.MapGet("/api/patients/{id}", (int id) =>
{
    var patient = patients.FirstOrDefault(p => p.Id == id);
    return patient is not null ? Results.Ok(patient) : Results.NotFound();
});

app.MapPost("/api/patients", (Patient patient) =>
{
    patient.Id = patients.Max(p => p.Id) + 1;
    patients.Add(patient);
    return Results.Created($"/api/patients/{patient.Id}", patient);
});

app.Run();

// Patient model
record Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Condition { get; set; } = string.Empty;
}