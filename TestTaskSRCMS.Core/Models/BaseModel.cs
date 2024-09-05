
using System.ComponentModel.DataAnnotations;

namespace TestTaskSRCMS.Core.Models;

public abstract class BaseModel(Guid id)
{
    /// <summary>
    /// ID объекта в системе.
    /// </summary>
    public Guid Id { get; } = id;
}
