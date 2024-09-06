using Microsoft.EntityFrameworkCore;
using TestTaskSRCMS.Core.Models;

namespace TestTaskSRCMS.Storage.Storages;

public class StorageSpecialization(ContextDatabase context)
{
    private readonly ContextDatabase _context = context;

    public async Task<Specialization?> GetById(Guid id)
    {
        var entity = await _context.Specializations.FirstOrDefaultAsync(x => x.Id == id);

        if (entity is not null)
            return entity.GetModel();
        else
            return null;
    }

    public async Task<Specialization?> GetByName(string name)
    {
        var entity = await _context.Specializations.FirstOrDefaultAsync(x => x.Name == name);

        if (entity is not null)
            return entity.GetModel();
        else
            return null;
    }

    public async Task<IReadOnlyList<Specialization>> GetAll()
    {
        var entities = await _context.Specializations.ToListAsync();
        if (entities is null)
            return [];
        return entities.Select(x => x.GetModel()).ToList();
    }

    public async Task Insert(Specialization office)
    {
        await _context.Specializations.AddAsync(new(office));
        _context.SaveChanges();
    }

    public async Task Update(Specialization specialization)
    {
        var updateSpecialization = await _context.Specializations.FirstOrDefaultAsync(x => x.Id == specialization.Id) ?? throw new Exception("");

        updateSpecialization.Name = specialization.Name;

        _context.SaveChanges();
    }

    public async Task Delete(Specialization office)
    {
        var removeDoctor = await _context.Specializations.FirstOrDefaultAsync(x => x.Id == office.Id) ?? throw new Exception("");

        _context.Specializations.Remove(removeDoctor);
        _context.SaveChanges();
    }

}
