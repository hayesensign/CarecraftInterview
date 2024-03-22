using IronXL;
using Aspose.Words;
using System.Drawing;

namespace CareCraftInterview
{
    class TxtConvert
    {
        //object data
        private String fileName;
        private String fileType;

        //constructor
        public TxtConvert(string fileName, string fileType)
        {
            this.fileName = fileName;
            this.fileType = fileType;
        }

        //performs the task of the program
        public void execute()
        {
            //data needed to complete the task
            WorkBook workbook = new WorkBook(ExcelFileFormat.XLSX);
            var workSheet = workbook.CreateWorkSheet("Sheet1");
            string fileString = fileName + ".txt";
            StreamReader sr = new StreamReader(fileString);

            //checks if file type inputted by user for download is XLSX
            if (fileType == "XLSX")
            {
                //stores the content of the text file in a string array called lines
                string[] lines = File.ReadAllLines(fileString);

                //iterates through each line of the text file
                for (int i = 0; i < lines.Length; i++)
                {
                    //turns each line into an array of strings, separated by an empty space char
                    string[] words = lines[i].Split(' ');

                    //iterates through each line
                    for (int j = 0; j < words.Length; j++)
                    {
                        //code to create correct cell id string, and assign the correct element to that cell
                        int asciiValue = 65 + j; 
                        char rowValue = (char)asciiValue;
                        int columnValue = i + 1;
                        string cellString = rowValue + columnValue.ToString();
                        workSheet[cellString].Value = words[j];
                    }
                }

                //saves and closes xlsx file
                workbook.SaveAs(fileName + ".xlsx");
                workbook.Close();
            }

            //creates docx file if xlsx is not selected
            else
            {
                //stores the content of the text file in a string array called lines
                string[] lines = File.ReadAllLines(fileString);

                //creates and sets settings of new docx file
                var doc = new Document();
                var builder = new DocumentBuilder(doc);
                var font = builder.Font;
                font.Name = "Courier New";
                font.Color = Color.Black;
                font.Size = 14;

                //iterates through each line of the text file
                foreach (var line in lines)
                {
                    //writes the line to the docx file
                    builder.Write(line);
                }

                //names and saves the docx file
                doc.Save(fileName + ".docx");
            }
        }
        static void Main(string[] args)
        {
            //collects the data necessary to execute the program
            Console.WriteLine("Enter the name of a Txt file (with between 1 and 26 rows and the data separated in each row by only one space) you want converted into either a DOCX file or XLSX file: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the file type you want this file converted into: ");
            string type = Console.ReadLine();

            //creates new TxtConvert object, and execcutes the program on it
            TxtConvert txttoXLSX = new TxtConvert(name, type);
            txttoXLSX.execute();
        }
    }
}