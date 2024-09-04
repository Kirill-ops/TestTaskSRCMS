
using System.Reflection;

namespace TestTaskSRCMS.Core.Models;

/// <summary>
/// Пациент
/// </summary>
public class Patient : BaseModel
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
    /// Адрес
    /// </summary>
    public string Address { get; init; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public string DateBirth { get; init; }

    /// <summary>
    /// Пол
    /// </summary>
    public string Gender { get; init; }

    /// <summary>
    /// ID участка, к которому приклеплен пациент
    /// </summary>
    public Guid DistrictId { get; init; }

    /// <summary>
    /// Создание нового пациента.
    /// </summary>
    /// <param name="surname">Фамилия</param>
    /// <param name="name">Имя.</param>
    /// <param name="patronymic">Отчество.</param>
    /// <param name="address">Адрес.</param>
    /// <param name="dateBirth">Дата рождения</param>
    /// <param name="gender">Пол.</param>
    public Patient(
        string surname, 
        string name, 
        string address,
        string dateBirth,
        string gender,
        string? patronymic = null) : base(Guid.NewGuid())
    {
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
        Address = address;
        DateBirth = dateBirth;
        Gender = gender;
    }

    /// <summary>
    /// Полный конструктор.
    /// </summary>
    /// <param name="id">ID пациента</param>
    /// <param name="surname">Фамилия</param>
    /// <param name="name">Имя.</param>
    /// <param name="patronymic">Отчество.</param>
    /// <param name="address">Адрес.</param>
    /// <param name="dateBirth">Дата рождения</param>
    /// <param name="gender">Пол.</param>
    /// <param name="districtId">ID участка.</param>
    public Patient(
        Guid id,
        string surname,
        string name,
        string address,
        string dateBirth,
        string gender,
        Guid districtId,
        string? patronymic = null) : base(id)
    {
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
        Address = address;
        DateBirth = dateBirth;
        Gender = gender;
        DistrictId = districtId;
    }

    /// <summary>
    /// Полный конструктор.
    /// </summary>
    /// <param name="patient">Пациент.</param>
    public Patient(Patient patient) : base(patient.Id)
    {
        Surname = patient.Surname;
        Name = patient.Name;
        Patronymic = patient.Patronymic;
        Address = patient.Address;
        DateBirth = patient.DateBirth;
        Gender = patient.Gender;
        DistrictId = patient.DistrictId;
    }

}
