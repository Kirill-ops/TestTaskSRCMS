namespace TestTaskSRCMS.Core.Models;

/// <summary>
/// Специализация.
/// </summary>
public class Specialization : BaseModel
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Создание новой специализации.
    /// </summary>
    /// <param name="name">Название.</param>
    public Specialization(string name) : base(Guid.NewGuid()) { 
        Name = name;
    }

    /// <summary>
    /// Полный конструктор.
    /// </summary>
    /// <param name="name">Название.</param>
    public Specialization(Guid id, string name) : base(id)
    {
        Name = name;
    }

    /// <summary>
    /// Конструктор копирования.
    /// </summary>
    /// <param name="specialization">Исходная специализация.</param>
    public Specialization(Specialization specialization) : base(specialization.Id)
    {
        Name = specialization.Name;
    }

}
