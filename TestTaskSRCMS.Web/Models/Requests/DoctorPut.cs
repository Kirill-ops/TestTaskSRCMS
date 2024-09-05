namespace TestTaskSRCMS.Web.Models.Requests;

public class DoctorPut
{
    public Guid Id { get; set; }
    public string? Surname { get; set; }
    public string? Name { get; set; }
    public string? Patronymic { get; set; }
    public Guid OfficeId { get; set; }
    public Guid SpecializationId { get; set; }
    public Guid DistrictId { get; set; } = Guid.Empty;
}
