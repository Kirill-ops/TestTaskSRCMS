namespace TestTaskSRCMS.App.Startup;

public interface IStartupTask
{
    public Task Execute(CancellationToken cancellationToken = default);
}
