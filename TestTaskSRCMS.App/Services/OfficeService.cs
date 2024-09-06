using TestTaskSRCMS.Core.Models;
using TestTaskSRCMS.Storage.Storages;

namespace TestTaskSRCMS.App.Services;

public class OfficeService(StorageOffice storage)
{
    private readonly StorageOffice _storage = storage;

    public async Task<Office?> GetById(Guid id)
    {
        return await _storage.GetById(id);
    }

    public async Task<IReadOnlyList<Office>> GetAll()
    {
        return await _storage.GetAll();
    }

    public async Task Create(int number)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number);

        if (await _storage.GetByNumber(number) is not null)
            throw new Exception("Conflict");

        var newOffice = new Office(number);
        await _storage.Insert(newOffice);
    }

    public async Task Update(Office office, int number)
    {
        ArgumentNullException.ThrowIfNull(office);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number);

        if (await _storage.GetByNumber(number) is not null)
            throw new Exception("Conflict");

        var updateOffice = new Office(office)
        {
            Number = number
        };

        await _storage.Update(updateOffice);
    }

    public async Task Delete(Office office)
    {
        ArgumentNullException.ThrowIfNull(office);
        await _storage.Delete(office);
    }
}
