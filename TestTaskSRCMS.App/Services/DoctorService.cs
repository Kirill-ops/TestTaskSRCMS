
using TestTaskSRCMS.Core.Extensions;
using TestTaskSRCMS.Core.Models;
using TestTaskSRCMS.Storage.Storages;
using static System.Net.Mime.MediaTypeNames;

namespace TestTaskSRCMS.App.Services;

public class DoctorService(StorageDoctor storage)
{
    private readonly StorageDoctor _storage = storage;

    public async Task<Doctor?> GetById(Guid id)
    {
        return await _storage.GetById(id);
    }

    public async Task<IReadOnlyList<Doctor>> GetAll()
    {
        return await _storage.GetAll();
    }

    public async Task Create(string surname,
        string name,
        Office office,
        Specialization specialization,
        District district,
        string? patronymic = null)
    {
        ArgumentNullException.ThrowIfNull(office);
        ArgumentNullException.ThrowIfNull(specialization);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(surname);

        var newDoctor = new Doctor(surname, name, patronymic)
        {
            DistrictId = district.GetIdOrEmpty(),
            OfficeId = office.Id,
            SpecializationId = specialization.Id,
        };

        await _storage.Insert(newDoctor);
    }

    public async Task Update(Doctor doctor, string surname,
        string name,
        Office office,
        Specialization specialization,
        District district,
        string? patronymic = null)
    {
        ArgumentNullException.ThrowIfNull(doctor);
        ArgumentNullException.ThrowIfNull(office);
        ArgumentNullException.ThrowIfNull(specialization);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(surname);

        var updateDoctor = new Doctor(doctor)
        {
            Name = name,
            Surname = surname,
            Patronymic = patronymic,
            DistrictId = district.GetIdOrEmpty(),
            OfficeId = office.Id,
            SpecializationId = specialization.Id,
        };

        await _storage.Update(updateDoctor);
    }

    public async Task Delete(Doctor doctor)
    {
        ArgumentNullException.ThrowIfNull(doctor);
        await _storage.Delete(doctor);
    }

}
