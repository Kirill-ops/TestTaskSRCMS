
namespace TestTaskSRCMS.Core.Models;

public class Doctor: BaseModel
{
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string? Patronymic { get; init; }

    /// <summary>
    /// ID кабинета
    /// </summary>
    public Guid OfficeId { get; init; }

    /// <summary>
    /// ID специализации.
    /// </summary>
    public Guid SpecializationId { get; init; }

    /// <summary>
    /// ID участка, если у врача нет участка, то Guid.Empty
    /// </summary>
    public Guid DistrictId { get; init; } = Guid.Empty;

    /// <summary>
    /// Создание нового врача.
    /// </summary>
    /// <param name="surname">Фамилия</param>
    /// <param name="name">Имя.</param>
    /// <param name="patronymic">Отчество.</param>
    public Doctor(
        string surname,
        string name,
        string? patronymic = null) : base(Guid.NewGuid()) 
    { 
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
    }

    /// <summary>
    /// Полный конструктор.
    /// </summary>
    /// <param name="id">ID врача</param>
    /// <param name="surname">Фамилия</param>
    /// <param name="name">Имя.</param>
    /// <param name="patronymic">Отчество.</param>
    /// <param name="officeId">Id кабинета.</param>
    /// <param name="specializationId">Id специализации.</param>
    /// <param name="districtId">Id участка.</param>
    public Doctor(
        Guid id,
        string surname,
        string name,
        Guid officeId,
        Guid specializationId,
        Guid districtId,
        string? patronymic = null) : base(id)
    {
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
    public Doctor(Doctor doctor) : base(doctor.Id)
    {
        Surname = doctor.Surname;
        Name = doctor.Name;
        Patronymic = doctor.Patronymic;
        OfficeId = doctor.OfficeId;
        SpecializationId = doctor.SpecializationId;
        DistrictId= doctor.DistrictId;
    }


}
