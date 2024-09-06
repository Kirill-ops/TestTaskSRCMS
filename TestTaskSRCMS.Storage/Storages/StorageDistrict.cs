using Microsoft.EntityFrameworkCore;
using TestTaskSRCMS.Core.Models;

namespace TestTaskSRCMS.Storage.Storages;

public class StorageDistrict(ContextDatabase context)
{
    private readonly ContextDatabase _context = context;

    public async Task<District?> GetById(Guid id)
    {
        var entity = await _context.Districts.FirstOrDefaultAsync(x => x.Id == id);

        if (entity is not null)
            return entity.GetModel();
        else
            return null;
    }

    public async Task<District?> GetByNumber(int number)
    {
        var entity = await _context.Districts.FirstOrDefaultAsync(x => x.Number == number);

        if (entity is not null)
            return entity.GetModel();
        else
            return null;
    }

    public async Task<IReadOnlyList<District>> GetAll()
    {
        var entities = await _context.Districts.ToListAsync();
        if (entities is null)
            return [];
        return entities.Select(x => x.GetModel()).ToList();
    }

    public async Task Insert(District district)
    {
        await _context.Districts.AddAsync(new(district));
        _context.SaveChanges();
    }

    public async Task Update(District district)
    {
        var updateDistrict = await _context.Districts.FirstOrDefaultAsync(x => x.Id == district.Id) ?? throw new Exception("");

        updateDistrict.Number = district.Number;

        _context.SaveChanges();
    }

    public async Task Delete(District district)
    {
        var removeDoctor = await _context.Districts.FirstOrDefaultAsync(x => x.Id == district.Id) ?? throw new Exception("");

        _context.Districts.Remove(removeDoctor);
        _context.SaveChanges();
    }

}
