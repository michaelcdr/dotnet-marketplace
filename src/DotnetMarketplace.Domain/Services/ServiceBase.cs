namespace MKT.Core.Services
{
    public abstract class ServiceBase
    {
        private readonly ISerializerService _serializerService;

        protected ServiceBase(ISerializerService serializerService)
        {
            _serializerService = serializerService;
        }

        protected virtual bool HandleResponseErrors(HttpResponseMessage response)
        {
            return _serializerService.HandleResponseErrors(response);
        }

        protected virtual async Task<T> Deserialize<T>(HttpResponseMessage responseMessage)
        {
            return await _serializerService.Deserialize<T>(responseMessage);
        }

        protected virtual StringContent FormatContent(object data)
        {
            return _serializerService.FormatContent(data);
        }
    }
}
