using System;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace ConsoleAppquestpdf
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestPDF.Settings.License = LicenseType.Enterprise;
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    // page content
                });
            });

            // instead of the standard way of generating a PDF file
            document.GeneratePdf("hello.pdf");

            // use the following invocation
            document.ShowInPreviewer();

            // optionally, you can specify an HTTP port to communicate with the previewer host (default is 12500)
            document.ShowInPreviewer(12345);
        }
        
    }
}
