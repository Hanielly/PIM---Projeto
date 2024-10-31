using DinkToPdf.Contracts;
using techFarm.Interfaces;

namespace techFarm.Services
{
    public class ServicesArquivoPDF : IServicesArquivoPDF
    {
        public readonly IConverter _conversor;

        public ServicesArquivoPDF(IConverter conversor)
        {
            _conversor = conversor;
        }


        public Task<byte[]> CriarPdf(string htmlContent)
        {
            throw new NotImplementedException();
        }
    }
}
