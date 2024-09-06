using TestTaskSRCMS.Core.Models;
using TestTaskSRCMS.Storage.Storages;

namespace TestTaskSRCMS.App.Services;

public class DistrictService(StorageDistrict storage)
{
    private readonly StorageDistrict _storage = storage;

    public async Task<District?> GetById(Guid id)
    {
        return await _storage.GetById(id);
    }

    public async Task<IReadOnlyList<District>> GetAll()
    {
        return await _storage.GetAll();
    }

    public async Task Create(int number)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number);

        if (await _storage.GetByNumber(number) is not null)
            throw new Exception("Conflict");

        var newDistrict = new District(number);
        await _storage.Insert(newDistrict);
    }

    public async Task Update(District district, int number)
    {
        ArgumentNullException.ThrowIfNull(district);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number);

        if (await _storage.GetByNumber(number) is not null)
            throw new Exception("Conflict");

        var updateDistrict = new District(district) { 
            Number = number
        };

        await _storage.Update(updateDistrict);
    }

    public async Task Delete(District district)
    {
        ArgumentNullException.ThrowIfNull(district);
        await _storage.Delete(district);
    }

}
