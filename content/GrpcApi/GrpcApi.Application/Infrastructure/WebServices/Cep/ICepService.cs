using System.Threading.Tasks;

using Refit;

namespace GrpcApi.Application.Infrastructure.WebServices
{
    public interface ICepService
    {
        [Get("/cep/v1/{request.Cep}")]
        Task<CepResponse> GetAddressByCep(CepRequest request);
    }
}