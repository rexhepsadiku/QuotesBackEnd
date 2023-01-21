namespace Quotes.Application.Wrappers
{
    public class ExceptionResponse
    {
        public ExceptionResponse(string clientMessage)
        {
            Error = clientMessage;
        }
        public ExceptionResponse(Exception ex)
        {
            Error = ex.Message;
        }
        public string Error { get; }
        public bool IsSuccess { get; } = false;
    }
}
