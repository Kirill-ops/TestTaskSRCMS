namespace TestTaskSRCMS.Web.Models.Requests;

public class DoctorPost
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
}
