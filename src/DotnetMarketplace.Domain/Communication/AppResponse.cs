namespace MKT.Core.Communication
{
    public class AppResponse
    {
        public AppResponse(bool success, string msg, List<string>? errors = null)
        {
            Errors = new ResponseErrorMessages();
            Success = success;
            Message = msg;

            if (errors != null)
            {
                foreach (var error in errors)
                    Errors.Mensagens.Add(error);
            }
        }

        public ResponseErrorMessages Errors { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public List<string> GetErrors()
        {
            return Errors.Mensagens.ToList();
        }

        public AppResponse GetResponse()
        {
            return new AppResponse(Success, Message, GetErrors());
        }
    }

    public class ResponseResult
    {
        public ResponseResult()
        {
            Errors = new ResponseErrorMessages();
        }

        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessages Errors { get; set; }
    }

    public class ResponseErrorMessages
    {
        public ResponseErrorMessages()
        {
            Mensagens = new List<string>();
        }

        public List<string> Mensagens { get; set; }
    }

}
