using TestTaskSRCMS.Core.Models;

namespace TestTaskSRCMS.Core.Extensions;

public static class BaseModelExtensions
{
    public static Guid GetIdOrEmpty(this BaseModel? model)
    {
        if (model is not null) 
            return model.Id;

        return Guid.Empty;
    }
}
