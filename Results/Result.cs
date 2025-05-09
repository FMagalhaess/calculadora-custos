namespace calculadora_custos.Results;

public abstract class Result
{
    protected Result(bool isSuccess, string error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }
    public bool IsSuccess { get; private set; }
    public string Error  { get; }

}