using Microsoft.EntityFrameworkCore;
using TestTaskSRCMS.Core.Models;

namespace TestTaskSRCMS.Storage.Storages;

public class StorageOffice(ContextDatabase context)
{
    private readonly ContextDatabase _context = context;

    public async Task<Office?> GetById(Guid id)
    {
        var entity = await _context.Offices.FirstOrDefaultAsync(x => x.Id == id);

        if (entity is not null)
            return entity.GetModel();
        else
            return null;
    }

    public async Task<IReadOnlyList<Office>> GetAll()
    {
        var entities = await _context.Offices.ToListAsync();
        if (entities is null)
            return [];
        return entities.Select(x => x.GetModel()).ToList();
    }

    public async Task Insert(Office office)
    {
        await _context.Offices.AddAsync(new(office));
        _context.SaveChanges();
    }

    public async Task Update(Office office)
    {
        var updateOffice = await _context.Offices.FirstOrDefaultAsync(x => x.Id == office.Id) ?? throw new Exception("");

        updateOffice = new(office);
        _context.SaveChanges();
    }

    public async Task Delete(Office office)
    {
        var removeDoctor = await _context.Offices.FirstOrDefaultAsync(x => x.Id == office.Id) ?? throw new Exception("");

        _context.Offices.Remove(removeDoctor);
        _context.SaveChanges();
    }

}
