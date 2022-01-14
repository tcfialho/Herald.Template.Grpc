using System.Threading.Tasks;

using Refit;

namespace GrpcService.Application.Infrastructure.WebServices
{
    public interface ICepService
    {
        [Get("/cep/v1/{request.Cep}")]
        Task<CepResponse> GetAddressByCep(CepRequest request);
    }
}