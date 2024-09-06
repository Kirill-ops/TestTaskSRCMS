
using TestTaskSRCMS.App.Services;
namespace TestTaskSRCMS.App.Startup;

public class TaskStorageInitalization(SpecializationService specializationService, OfficeService officeService, DistrictService districtService) 
    : IStartupTask
{

    private readonly SpecializationService _specializationService = specializationService;
    private readonly OfficeService _officeService = officeService;
    private readonly DistrictService _districtService = districtService;

    public async Task Execute(CancellationToken cancellationToken = default)
    {
        var offices = await _officeService.GetAll();
        if (offices.Count == 0)
        {
            await _officeService.Create(1);
            await _officeService.Create(2);
            await _officeService.Create(3);
        }

        var specializations = await _specializationService.GetAll();
        if (specializations.Count == 0)
        {
            await _specializationService.Create("Хирург");
            await _specializationService.Create("Терапевт");
            await _specializationService.Create("Окулист");
        }

        var districts = await _districtService.GetAll();
        if (districts.Count == 0)
        {
            await _districtService.Create(1);
            await _districtService.Create(2);
            await _districtService.Create(3);
        }
    }
}
