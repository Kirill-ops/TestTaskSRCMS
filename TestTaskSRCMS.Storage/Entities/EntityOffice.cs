using HShop.Storage.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using TestTaskSRCMS.Core.Models;

namespace TestTaskSRCMS.Storage.Entities;

[Table("Offices")]
public class EntityOffice : IEntity<Office>
{
    public Guid Id { get; set; }
    public int Number { get; set; }

    public EntityOffice(Guid id, int number)
    {
        Id = id;
        Number = number;
    }

    public EntityOffice(Office district)
    {
        Id = district.Id;
        Number = district.Number;
    }

    public Office GetModel()
    {
        return new Office(Id, Number);
    }
}
