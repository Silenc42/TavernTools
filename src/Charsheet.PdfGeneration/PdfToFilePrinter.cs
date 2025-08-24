using Charsheet.CommonModel.Options;
using Charsheet.PdfGeneration.PrintModel;
using Charsheet.PdfGeneration.Typesetters;
using iText.Kernel.Pdf;
using iText.Layout;

namespace Charsheet.PdfGeneration;

public class PdfPrinter(DocumentRootTypesetter documentRootTypesetter)
{
    public void GeneratePdfToFile(CharacterPrintData data, string filename, CharSheetOptions opt)
    {
        using Document doc = new(new PdfDocument(new PdfWriter(filename)));

        documentRootTypesetter.Typeset(doc, data, opt);

        doc.Close();
    }

    public string GeneratePdfAsBase64(CharacterPrintData data, CharSheetOptions opt)
    {
        using MemoryStream memoryStream = new();
        using Document doc = new(new PdfDocument(new PdfWriter(memoryStream)));
        documentRootTypesetter.Typeset(doc, data, opt);
        doc.Close();
        byte[] pdfBytes = memoryStream.ToArray();
        return Convert.ToBase64String(pdfBytes);
    }
}