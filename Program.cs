using Aspose.Words;
using Docnet.Core;
using Docnet.Core.Models;
using Docnet.Core.Readers;
using iTextSharp.text.pdf.parser;
using System.Drawing;

namespace FileConverter2
{
    class FileConvert
    {
        //object data
        private String fileName;

        //constructor
        public FileConvert(string fileName)
        {
            this.fileName = fileName;
        }

        //performs the task of the program
        public void execeute()
        {
            //data needed to complete the task
            string fileString = fileName + ".pdf";
            IDocReader docReader = DocLib.Instance.GetDocReader(fileString, new PageDimensions());
            var doc = new Document();
            var builder = new DocumentBuilder(doc);
            var font = builder.Font;
            font.Name = "Courier New";
            font.Color = Color.Black;
            font.Size = 14;

            //iterates through each page of the pdf
            for (int i = 0; i < docReader.GetPageCount(); i++)
            {
                //gets the content of each page of the pdf
                var pageReader = docReader.GetPageReader(i);
                string text = pageReader.GetText();

                //writes the content of each page of the pdf onto a new doc file
                builder.Write(text);
                
            }

            //saves the doc file
            doc.Save(fileName + ".docx");
        }

        static void Main(string[] args)
        {
            //collects the data necessry to exectute the program
            Console.WriteLine("Enter the name of a PDF that you want converted into a DOCX file: ");
            string name = Console.ReadLine();

            //creates new FileConvert object, and executes the program on it
            FileConvert fc = new FileConvert(name);
            fc.execeute();
        }
    }
}