namespace MKT.Core.Responses;

public class AppResponse<T>(bool sucesso, string mensagem, List<Notification>? erros = null)
{
    public List<Notification> Errors { get; set; } = erros ?? [];
    public bool Success { get; set; } = sucesso;
    public string Message { get; set; } = mensagem;
    public T? Data { get; set; }
    public int StatusCode { get; set; }
}