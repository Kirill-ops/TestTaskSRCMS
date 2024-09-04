
namespace TestTaskSRCMS.Core.Models;

/// <summary>
/// Кабинет.
/// </summary>
public class Office : BaseModel
{
    /// <summary>
    /// Номер кабинета
    /// </summary>
    public int Number { get; init; }

    /// <summary>
    /// Создание нового кабинета.
    /// </summary>
    /// <param name="number"> Номер кабинета.</param>
    public Office(int number) : base(Guid.NewGuid())
    {
        Number = number;
    }

    /// <summary>
    /// Полный конструктор.
    /// </summary>
    /// <param name="id"> ID кабинета.</param>
    /// <param name="number"> Номер кабинета.</param>
    public Office(Guid id, int number) : base(id)
    {
        Number = number;
    }

    /// <summary>
    /// Конструктор копирования.
    /// </summary>
    public Office(Office office) : base(office.Id)
    {
        Number = office.Number;
    }
}
