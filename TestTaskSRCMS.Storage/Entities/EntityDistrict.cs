using HShop.Storage.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using TestTaskSRCMS.Core.Models;

namespace TestTaskSRCMS.Storage.Entities;

[Table("Districts")]
public class EntityDistrict : IEntity<District>
{
    public Guid Id { get; set; }
    public int Number { get; set; }

    public EntityDistrict(Guid id, int number)
    {
        Id = id;
        Number = number;
    }

    public EntityDistrict(District district)
    {
        Id = district.Id;
        Number = district.Number;
    }

    public District GetModel()
    {
        return new District(Id, Number);
    }
}
