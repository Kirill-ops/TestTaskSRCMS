using TestTaskSRCMS.Core.Models;

namespace TestTaskSRCMS.Web.Models;

public class ResponseDoctorBrief(Doctor doctor)
{
    public Guid Id { get; } = doctor.Id;
    public string Surname { get; } = doctor.Surname;
    public string Name { get; } = doctor.Name;
    public string? Patronymic { get; } = doctor.Patronymic;
    public Guid OfficeId { get;  } = doctor.OfficeId;
    public Guid SpecializationId { get; } = doctor.SpecializationId;
    public Guid DistrictId { get; } = doctor.DistrictId;
}
