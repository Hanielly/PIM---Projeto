namespace techFarm.Interfaces
{
    public interface IServicesArquivoPDF
    {
        public Task<byte[]> CriarPdf(string htmlContent);
    }
}
