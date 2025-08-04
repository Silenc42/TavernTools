using DnD_Charbuilder;
using DnD_Charbuilder.CharModel;
using DnD_Charsheet_Pdf_Generation;
using DnD_Common_Model.Options;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Determining output directory");
string[] outputDirByPriority =
[
    @"D:\Dropbox\DnD\CharGeneration\",
    @"C:\Zeug\DnD\GeneratorOutput\",
    Directory.GetCurrentDirectory()+"\\"
];
string outputDirectory = outputDirByPriority.First(Directory.Exists);
Console.WriteLine($"Result: {outputDirectory}");

Console.WriteLine("Initializing DI");

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


Console.WriteLine("Generating example: Enkai");

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

Console.WriteLine("Done. Closing application");
