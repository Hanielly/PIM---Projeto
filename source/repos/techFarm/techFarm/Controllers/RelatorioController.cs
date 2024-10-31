using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using techFarm.Interfaces;
using techFarm.Services;
using techFarm.Models;

namespace techFarm.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly IRelatorioDeVendasService _relatorioService;
        private readonly IServicesArquivoPDF _gerarPdfService;
        private readonly IRazorViewRendererService _rendererService;
        private readonly IConverter _converter;

        public RelatorioController( IRelatorioDeVendasService relatorioService, 
                                    IServicesArquivoPDF gerarPdfService, 
                                    IRazorViewRendererService renderService,
                                    IConverter converter)
        {
            _relatorioService = relatorioService;
            _gerarPdfService = gerarPdfService;
            _rendererService = renderService;
            _converter = converter;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> GerarPdf()
        //{
        //    var actionContext = new ActionContext(HttpContext, RouteData, ControllerContext.ActionDescriptor);

        //    string htmlContent = await _rendererService.RenderViewToStringAsync(actionContext, "Index", model: null);

        //    var pdfBytes = await _gerarPdfService.CriarPdf(htmlContent);

        //    return File(pdfBytes, "application/pdf", "Relatorio.pdf");
        //}
        [HttpPost]
        public async Task<IActionResult> ExportarPdf(DateTime dataInicio, DateTime dataFim)
        {
            // Obtenha as vendas com base no período
            var vendas = await _relatorioService.GerarRelatorioDeVendasAsync(dataInicio, dataFim);

            // Preencha o ViewModel com as informações necessárias
            var model = new RelatorioVendasViewModel
            {
                DataInicio = dataInicio,
                DataFim = dataFim,
                Vendas = vendas
            };

            var actionContext = new ActionContext(HttpContext, RouteData, ControllerContext.ActionDescriptor);
            var htmlContent = await _rendererService.RenderViewToStringAsync(actionContext, "RelatorioVendasViewModel", model);

            // Configurações do PDF
            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = new GlobalSettings { PaperSize = PaperKind.A4, Orientation = Orientation.Portrait },
                Objects = { new ObjectSettings { HtmlContent = htmlContent, WebSettings = { DefaultEncoding = "utf-8" } } }
            };

            var file = _converter.Convert(pdf);
            return File(file, "application/pdf", "Relatorio.pdf");
        }
    }
}
