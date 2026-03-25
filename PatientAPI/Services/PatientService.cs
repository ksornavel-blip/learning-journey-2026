namespace PatientAPI.Services;

using PatientAPI.Models;

public interface IPatientService
{
    List<Patient> GetAllPatients();
    Patient? GetPatientById(int id);
    Patient AddPatient(Patient patient);
}

public class PatientService : IPatientService
{
    private readonly List<Patient> _patients;

    public PatientService()
    {
        _patients = new List<Patient>
        {
            new Patient { Id = 1, Name = "John Doe", Age = 45, Condition = "Hypertension" },
            new Patient { Id = 2, Name = "Jane Smith", Age = 32, Condition = "Diabetes" }
        };
    }

    public List<Patient> GetAllPatients() => _patients;

    public Patient? GetPatientById(int id) => _patients.FirstOrDefault(p => p.Id == id);

    public Patient AddPatient(Patient patient)
    {
        patient.Id = _patients.Any() ? _patients.Max(p => p.Id) + 1 : 1;
        _patients.Add(patient);
        return patient;
    }
}