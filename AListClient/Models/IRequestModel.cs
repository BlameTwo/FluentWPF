namespace AListClient.Models;

public interface IRequestModel
{
    public string RequestName { get; }
}

public interface IResponseModel
{
    public string ResponseName { get; }
}