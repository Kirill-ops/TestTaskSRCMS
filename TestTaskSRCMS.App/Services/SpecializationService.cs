using TestTaskSRCMS.Core.Models;
using TestTaskSRCMS.Storage.Storages;

namespace TestTaskSRCMS.App.Services;

public class SpecializationService(StorageSpecialization storage)
{
    private readonly StorageSpecialization _storage = storage;

    public async Task<Specialization?> GetById(Guid id)
    {
        return await _storage.GetById(id);
    }

    public async Task<IReadOnlyList<Specialization>> GetAll()
    {
        return await _storage.GetAll();
    }

    public async Task Create(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        if (await _storage.GetByName(name) is not null)
            throw new Exception("Conflict");

        var newSpecialization = new Specialization(name);
        await _storage.Insert(newSpecialization);
    }

    public async Task Update(Specialization specialization, string name)
    {
        ArgumentNullException.ThrowIfNull(specialization);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        if (await _storage.GetByName(name) is not null)
            throw new Exception("Conflict");

        var updateSpecialization = new Specialization(specialization)
        {
            Name = name
        };

        await _storage.Update(updateSpecialization);
    }

    public async Task Delete(Specialization office)
    {
        ArgumentNullException.ThrowIfNull(office);
        await _storage.Delete(office);
    }
}
