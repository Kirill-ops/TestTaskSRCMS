using HShop.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskSRCMS.Core.Models;

namespace TestTaskSRCMS.Storage.Entities;

public class EntityDoctor: IEntity<Doctor>
{

    public Guid Id { get; set; }

    public string Surname { get; init; }

    public string Name { get; init; }

    public string? Patronymic { get; init; }

    public Guid OfficeId { get; init; }

    public Guid SpecializationId { get; init; }

    public Guid DistrictId { get; init; } = Guid.Empty;

    public EntityDoctor(
        Guid id,
        string surname,
        string name,
        Guid officeId,
        Guid specializationId,
        Guid districtId,
        string? patronymic = null) 
    {
        Id = id;
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
        OfficeId = officeId;
        SpecializationId = specializationId;
        DistrictId = districtId;
    }


    /// <summary>
    /// Констрктор копирования.
    /// </summary>
    /// <param name="doctor">Врач.</param>
    public EntityDoctor(Doctor doctor) 
    {
        Id = doctor.Id;
        Surname = doctor.Surname;
        Name = doctor.Name;
        Patronymic = doctor.Patronymic;
        OfficeId = doctor.OfficeId;
        SpecializationId = doctor.SpecializationId;
        DistrictId = doctor.DistrictId;
    }

    public Doctor GetModel()
    {
        return new(
            id: Id,
            surname: Surname,
            name: Name,
            officeId: OfficeId,
            specializationId: SpecializationId,
            districtId: DistrictId,
            patronymic: Patronymic);
    }
}
