namespace Quotes.Application.Wrappers
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }

        public static ApiResponse<T> Success(T data) => new ApiResponse<T> { IsSuccess = true, Data = data };
        public static ApiResponse<T> Failure(string error) => new ApiResponse<T> { IsSuccess = false, Error = error };
    }
}
