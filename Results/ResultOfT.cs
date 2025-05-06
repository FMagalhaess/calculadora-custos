namespace calculadora_custos.Results;

public class Result<T> : Result
{
    public Result(T? data, bool isSuccess = true, string error = "") : base(isSuccess, error)
    {
        Data = data;
    }
    public T? Data { get; set; }
    
    public static Result<T> Ok(T data) => new Result<T>(data);
    public static Result<T> Fail(string error) => new Result<T>(default, false, error);
}