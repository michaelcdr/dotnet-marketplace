namespace MKT.Core.Responses
{
    public class AppResponse<T>(bool sucesso, string mensagem, List<Notification>? erros = null)
    {
        public List<Notification> Errors { get; set; } = erros ?? [];
        public bool Success { get; set; } = sucesso;
        public string Message { get; set; } = mensagem;
        public T? Data { get; set; }
        public int StatusCode { get; set; }
    }

    public class Notification
    {
        public Notification(string mensagem, string propriedade)
        {
            Message = mensagem;
            Property = propriedade;
        }

        public string Message { get; set; }
        public string Property { get; set; }
    }
}
