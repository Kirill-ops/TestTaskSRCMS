using HShop.Storage.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using TestTaskSRCMS.Core.Models;

namespace TestTaskSRCMS.Storage.Entities;

[Table("Specializations")]
public class EntitySpecialization: IEntity<Specialization>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public EntitySpecialization(Guid id, string name) 
    {
        Id = id;
        Name = name;
    }

    public EntitySpecialization(Specialization specialization)
    {
        Id =  specialization.Id;
        Name = specialization.Name;
    }

    public Specialization GetModel()
    {
        return new Specialization(Id, Name);
    }
}
