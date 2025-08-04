using Charsheet.Charbuilder;
using Charsheet.Charbuilder.CharModel;
using Charsheet.CommonModel.Options;
using Charsheet.PdfGeneration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Charsheet.GenerationTests;

public class ExampleBuilder
{
    private readonly ITestOutputHelper TestOutputHelper;

    public ExampleBuilder(ITestOutputHelper testOutputHelper)
    {
        TestOutputHelper = testOutputHelper;
    }

    [Fact]
    public void BuildExampleChars()
    {
        TestOutputHelper.WriteLine("Determining output directory");
        string[] outputDirByPriority =
        [
            @"D:\Dropbox\DnD\CharGeneration\",
            @"C:\Zeug\DnD\GeneratorOutput\",
            Directory.GetCurrentDirectory() + "\\"
        ];
        string outputDirectory = outputDirByPriority.First(Directory.Exists);
        TestOutputHelper.WriteLine($"Result: {outputDirectory}");

        TestOutputHelper.WriteLine("Initializing DI");

        IServiceCollection services = new ServiceCollection()
                .AddCharbuilderDependencies()
                .AddPdfGeneratorDependencies()
            ;

        ServiceProvider serviceProvider = services.BuildServiceProvider();

        CharBuilderMain charBuilder = serviceProvider.GetRequiredService<CharBuilderMain>();

// Console.WriteLine("Generating example: Vaelthir");
//
// CharacterData vaelthirData = ExampleChars.ExampleDataCatsPaw;
// string vaelthirFilepath = $"{outputDirectory}Vaelthir.pdf";
// CharSheetOptions vaelthirOptions = new()
// {
//     SkillListing = ListingSkillOption.ProficientOnly,
//     DiceRenderStyle = new()
//     {
//         MarkVertices = false,
//         FillInFaces = true,
//         HideCoveredVertices = true
//     }
// };
// charBuilder.SaveCharToFile(vaelthirData, vaelthirFilepath, vaelthirOptions);


        TestOutputHelper.WriteLine("Generating example: Enkai");

        CharacterData enkaiData = ExampleChars.ExampleDataEnkai;
        string enkaiFilepath = $"{outputDirectory}Enkai.pdf";
        CharSheetOptions enkaiOptions = new()
        {
            SkillListing = ListingSkillOption.ProficientOnly,
            DiceRenderStyle = new()
            {
                MarkVertices = false,
                FillInFaces = true,
                HideCoveredVertices = true
            }
        };
        charBuilder.SaveCharToFile(enkaiData, enkaiFilepath, enkaiOptions);

        TestOutputHelper.WriteLine("Done. Closing application");
    }
}