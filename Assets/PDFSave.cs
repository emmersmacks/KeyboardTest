using System.IO;
using MigraDocCore.DocumentObjectModel;
using MigraDocCore.Rendering;
using PdfSharpCore.Fonts;
using UnityEngine;

namespace DefaultNamespace
{
    public class PDFSave
    {
        public static void Save(string reportsFolderPath, string pdfName)
        {
            var font = Resources.Load<TextAsset>("Regular");
            GlobalFontSettings.FontResolver = new FailsafeFontResolver(font.bytes);
                
            var document = new Document();
            var section = document.AddSection();
            section.AddParagraph("AAAAAA");
            document.LastSection.AddParagraph("AOAOAOAOAOAOA");
            var renderer = new PdfDocumentRenderer(true);
            
            renderer.Document = document;
            renderer.RenderDocument();

            if (!Directory.Exists(reportsFolderPath))
            {
                Directory.CreateDirectory(reportsFolderPath);
            }

            var pdfFilename = string.Concat(pdfName, ".pdf");
            var path = reportsFolderPath + pdfFilename;

            renderer.PdfDocument.Save(path);
        }
    }

    public class FailsafeFontResolver : IFontResolver
    {
        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic) => new("Regular");
        private byte[] font;
        public FailsafeFontResolver(byte [] font)
        {
            this.font = font;
        }
        
        public byte[] GetFont(string faceName)
        {
            return font;
        }

        public string DefaultFontName { get; } = "Regular";
    }
}