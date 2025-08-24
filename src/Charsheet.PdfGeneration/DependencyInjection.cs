using Charsheet.PdfGeneration.Renderers;
using Charsheet.PdfGeneration.Renderers.Dice;
using Charsheet.PdfGeneration.Typesetters;
using Charsheet.PdfGeneration.Typesetters.BlockTypesetters;
using Microsoft.Extensions.DependencyInjection;

namespace Charsheet.PdfGeneration;

public static class DependencyInjection
{
    public static IServiceCollection AddPdfGeneratorDependencies(this IServiceCollection services)
    {
        return services
                .AddTransient<PdfPrinter>()
                .AddTransient<DocumentRootTypesetter>()
                .AddTransient<BannerTypesetter>()
                .AddTransient<Column1Typesetter>()
                .AddTransient<Column2Typesetter>()
                .AddTransient<Column3Typesetter>()
                .AddTransient<BlockTypesetter>()
                .AddTransient<CellRendererFactory>()
                .AddTransient<DieDrawer>()
                .AddTransient<DieRenderingCalculator>()
                .AddTransient<VertexVisibilityCalculator>()
            ;
    }
}
