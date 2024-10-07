namespace MKT.Core.Responses;

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