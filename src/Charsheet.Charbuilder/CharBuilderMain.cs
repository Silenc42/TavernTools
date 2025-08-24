using Charsheet.Charbuilder.CharModel;
using Charsheet.CommonModel.Options;
using Charsheet.PdfGeneration;
using Charsheet.PdfGeneration.PrintModel;

namespace Charsheet.Charbuilder;

public class CharBuilderMain(PdfPrinter filePrinter, ToPrintConverter toPrintConverter)
{
    public void SaveCharToFile(CharacterData charData, string filepath, CharSheetOptions opt)
    {
        CharacterPrintData printData = toPrintConverter.Convert(charData);
        filePrinter.GeneratePdfToFile(printData, filepath, opt);
    }
}
