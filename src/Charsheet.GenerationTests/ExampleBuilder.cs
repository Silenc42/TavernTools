using Charsheet.Charbuilder;
using Charsheet.Charbuilder.CharModel;
using Charsheet.CommonModel.Options;
using Charsheet.PdfGeneration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Charsheet.GenerationTests;

public class ExampleBuilder
{
    private static readonly CharSheetOptions DefaultOptions = new()
    {
        SkillListing = ListingSkillOption.All,
        DiceRenderStyle = new()
        {
            MarkVertices = false,
            FillInFaces = true,
            HideCoveredVertices = true
        }
    };

    private static readonly CharSheetOptions ProfSkillOnlyOptions = new()
    {
        SkillListing = ListingSkillOption.ProficientOnly,
        DiceRenderStyle = new()
        {
            MarkVertices = false,
            FillInFaces = true,
            HideCoveredVertices = true
        }
    };

    private static readonly List<(CharacterData, CharSheetOptions)> CharsToBuild =
    [
        // (ExampleChars.ExampleDataEnkai, ProfSkillOnlyOptions),
        (ExampleChars.ExampleDataZylana, DefaultOptions)
    ];

    private readonly string[] _outputDirByPriority =
    [
        @"D:\Dropbox\DnD\CharGeneration\",
        @"C:\Zeug\DnD\GeneratorOutput\",
        Directory.GetCurrentDirectory() + "\\"
    ];

    private readonly ITestOutputHelper _testOutputHelper;

    public ExampleBuilder(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void BuildExampleChars()
    {
        string outputDirectory = DetermineOutputDir();

        CharBuilderMain charBuilder = BuildProgram();

        foreach ((CharacterData charData, CharSheetOptions opt) in CharsToBuild)
        {
            _testOutputHelper.WriteLine($"Generating pdf for: {charData.Name}");
            int totalLevel = charData.ClassLevels.Sum(x => x.Level);
            string filepath = $"{outputDirectory}{charData.Name}-{totalLevel}.pdf";
            charBuilder.SaveCharToFile(charData, filepath, opt);
            _testOutputHelper.WriteLine($"Created {filepath}");
            
        }

        _testOutputHelper.WriteLine("Done. Closing application");
    }

    private CharBuilderMain BuildProgram()
    {
        _testOutputHelper.WriteLine("Initializing DI");

        IServiceCollection services = new ServiceCollection()
                .AddCharbuilderDependencies()
                .AddPdfGeneratorDependencies()
            ;

        ServiceProvider serviceProvider = services.BuildServiceProvider();

        CharBuilderMain charBuilder = serviceProvider.GetRequiredService<CharBuilderMain>();
        return charBuilder;
    }

    private string DetermineOutputDir()
    {
        _testOutputHelper.WriteLine("Determining output directory");

        string outputDirectory = _outputDirByPriority.First(Directory.Exists);
        _testOutputHelper.WriteLine($"Result: {outputDirectory}");
        return outputDirectory;
    }
}