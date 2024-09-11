namespace MKT.Core.Services
{
    public interface ISerializerService
    {
        bool HandleResponseErrors(HttpResponseMessage response);
        Task<T> Deserialize<T>(HttpResponseMessage responseMessage);
        StringContent FormatContent(object data);
    }
}
