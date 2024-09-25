using TestTaskSRCMS.Core.Models;

namespace TestTaskSRCMS.Web.Models;

public class ResponseDoctorFull(Doctor doctor, Office office, Specialization? specialization, District district)
{
    public Guid Id { get; } = doctor.Id;
    public string Surname { get; } = doctor.Surname;
    public string Name { get; } = doctor.Name;
    public string? Patronymic { get; } = doctor.Patronymic;
    public int Office { get; } = office.Number;
    public string Specialization { get; } = specialization is null ? string.Empty : specialization.Name;
    public int? District { get; } = district.Id == Guid.Empty ? null : district.Number;
}
