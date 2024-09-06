using Microsoft.EntityFrameworkCore;
using TestTaskSRCMS.Core.Models;

namespace TestTaskSRCMS.Storage.Storages;

public class StoragePatient(ContextDatabase context)
{
    private readonly ContextDatabase _context = context;

    public async Task<Patient?> GetById(Guid id)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);

        if (patient is not null)
            return patient.GetModel();
        else
            return null;
    }

    public async Task<IReadOnlyList<Patient>> GetAll()
    {
        var atients = await _context.Patients.ToListAsync();
        if (atients is null)
            return [];
        return atients.Select(x => x.GetModel()).ToList();
    }

    public async Task Insert(Patient patient)
    {
        await _context.Patients.AddAsync(new(patient));
        _context.SaveChanges();
    }

    public async Task Update(Patient patient)
    {
        var updateDoctor = await _context.Patients.FirstOrDefaultAsync(x => x.Id == patient.Id) ?? throw new Exception("");

        updateDoctor.Name = patient.Name;
        updateDoctor.Surname = patient.Surname;
        updateDoctor.Patronymic = patient.Patronymic;
        updateDoctor.Address = patient.Address;
        updateDoctor.DateBirth = patient.DateBirth;
        updateDoctor.DistrictId = patient.DistrictId;
        updateDoctor.Gender = patient.Gender;

        _context.SaveChanges();
    }

    public async Task Delete(Patient patients)
    {
        var removeDoctor = await _context.Patients.FirstOrDefaultAsync(x => x.Id == patients.Id) ?? throw new Exception("");

        _context.Patients.Remove(removeDoctor);
        _context.SaveChanges();
    }


}
