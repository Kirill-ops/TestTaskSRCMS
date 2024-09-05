using Microsoft.EntityFrameworkCore;
using TestTaskSRCMS.Core.Models;

namespace TestTaskSRCMS.Storage.Storages;

public class StorageDoctor(ContextDatabase context)
{
    private readonly ContextDatabase _context = context;

    public async Task<Doctor?> GetById(Guid id)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);

        if (doctor is not null)
            return doctor.GetModel();
        else
            return null;
    }

    public async Task<IReadOnlyList<Doctor>> GetAll()
    {
        var doctors = await _context.Doctors.ToListAsync();
        if (doctors is null)
            return [];
        return doctors.Select(x => x.GetModel()).ToList();
    }

    public async Task Insert(Doctor doctor)
    {
        await _context.Doctors.AddAsync(new(doctor));
        _context.SaveChanges();
    }

    public async Task Update(Doctor doctor)
    {
        var updateDoctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == doctor.Id) ?? throw new Exception("");

        updateDoctor = new(doctor);
        _context.SaveChanges();
    }

    public async Task Delete(Doctor doctor)
    {
        var removeDoctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == doctor.Id) ?? throw new Exception("");

        _context.Doctors.Remove(removeDoctor);
        _context.SaveChanges();
    }

}
