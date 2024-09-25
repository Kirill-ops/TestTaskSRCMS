using TestTaskSRCMS.Web.Models;

namespace TestTaskSRCMS.Web.Extensions;

public enum DoctorsSortingField { Surname, Name, Patronymic, Office, District, Specialization, NoField }

public static class ListExtensions
{
    public static IReadOnlyList<ResponseDoctorFull> SortDoctors(this IReadOnlyList<ResponseDoctorFull> list, DoctorsSortingField filed, int limit)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(limit);

        var result = new List<ResponseDoctorFull>();

        limit = list.Count < limit ? list.Count : limit;

        switch (filed)
        {
            case DoctorsSortingField.Surname:
                result = [.. list.OrderBy(x => x.Surname).Take(limit)];
                break;
            case DoctorsSortingField.Name:
                result = [.. list.OrderBy(x => x.Name).Take(limit)];
                break;
            case DoctorsSortingField.Patronymic:
                result = [.. list.OrderBy(x => x.Patronymic).Take(limit)];
                break;
            case DoctorsSortingField.Office:
                result = [.. list.OrderBy(x => x.Office).Take(limit)];
                break;
            case DoctorsSortingField.District:
                result = [.. list.OrderBy(x => x.District).Take(limit)];
                break;
            case DoctorsSortingField.Specialization:
                result = [.. list.OrderBy(x => x.Specialization).Take(limit)];
                break;
            default:
                result = [.. list.Take(limit)];
                break;
        }
        return result;
    }
}
