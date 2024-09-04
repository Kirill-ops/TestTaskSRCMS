namespace TestTaskSRCMS.Core.Models;

/// <summary>
/// Участок
/// </summary>
public class District : BaseModel
{
    /// <summary>
    /// Номер участка
    /// </summary>
    public int Number {  get; init; }

    /// <summary>
    /// Создание нового участка
    /// </summary>
    /// <param name="number"> Номер участка.</param>
    public District(int number) : base(Guid.NewGuid())
    {
        Number = number;
    }

    /// <summary>
    /// Полный конструктор.
    /// </summary>
    /// <param name="id"> ID участка.</param>
    /// <param name="number"> Номер участка.</param>
    public District(Guid id, int number) : base(id)
    {
        Number = number;
    }

    /// <summary>
    /// Конструктор копирования.
    /// </summary>
    public District(District district) : base(district.Id)
    {
        Number = district.Number;
    }

}
