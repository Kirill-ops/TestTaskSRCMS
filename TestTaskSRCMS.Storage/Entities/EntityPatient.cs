using HShop.Storage.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection;
using TestTaskSRCMS.Core.Models;

namespace TestTaskSRCMS.Storage.Entities;

[Table("Patients")]
public class EntityPatient : IEntity<Patient>
{
    public Guid Id { get; set; }

    public string Surname { get; set; }

    public string Name { get; set; }

    public string? Patronymic { get; set; }

    public string Address { get; set; }

    public string DateBirth { get; set; }

    public string Gender { get; set; }

    public Guid DistrictId { get; set; }

    public EntityPatient(
        Guid id,
        string surname,
        string name,
        string address,
        string dateBirth,
        string gender,
        Guid districtId,
        string? patronymic = null) 
    {
        Id = id;
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
        Address = address;
        DateBirth = dateBirth;
        Gender = gender;
        DistrictId = districtId;
    }

    public EntityPatient(Patient patient)
    {
        Id = patient.Id;
        Surname = patient.Surname;
        Name = patient.Name;
        Patronymic = patient.Patronymic;
        Address = patient.Address;
        DateBirth = patient.DateBirth;
        Gender = patient.Gender;
        DistrictId = patient.DistrictId;
    }


    public Patient GetModel()
    {
        return new(
            id: Id,
            surname: Surname,
            name: Name,
            address: Address,
            dateBirth: DateBirth,
            gender: Gender,
            districtId: DistrictId,
            patronymic: Patronymic);
    }
}
