namespace WindowsInstaller.Services.Contracts;

public interface ITaskCommand<T>
{

    public void SetData(T data);
}
