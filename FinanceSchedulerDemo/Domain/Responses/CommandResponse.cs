namespace Domain.Responses
{
    public class CommandResponse<T>
    {
        public T ResponseModel { get; set; }
        public string ResponseMessage { get; set; }

        public CommandResponse(string message)
        {
            ResponseMessage = message;
        }

        public CommandResponse(T model, string message) : this(message)
        {
            ResponseModel = model;
        }
    }
}