// See https://aka.ms/new-console-template for more information

using System.Text.Json;

//Includes instance methods to Create, Delete, Copy, Move a file
//and to return a FileStream that we can loop through it with StreamReader or Writer
FileInfo fileInfo = new FileInfo(@"D:\Daniel\a.csv");
WriteToTheFile();
WriteToTheFile2();
GetDrivesAndLoop10Directories();
ReadFromTheFile();

/*********  Local methods below  - They are nested in the static Main method*******/

void WriteToTheFile()
{
    var sw = fileInfo.AppendText();//StreamWirter created from the File Info. We can also use FileStrem to create the Writer/Reader
    try
    {
        for (int i = 0; i < 1000; i++)
        {
            sw.WriteLine("Line " + i++.ToString());
        }
    }
    catch (Exception)
    {
        throw;
    }
    finally
    {
        //sw.Close();
        sw.Dispose();
    }
}

void GetDrivesAndLoop10Directories()
{
    //Directory.CreateDirectory(@"D:\Daniel");
    var arr = Directory.GetLogicalDrives();
    var arrr1 = Directory.GetDirectories(arr[0]);
    foreach (var item in arrr1.Take(10))
    {
        Console.WriteLine(item);
    }
}

void WriteToTheFile2()
{
    var streamWriter = new StreamWriter(@"D:\Daniel\a.csv", true);
    using (streamWriter)
    {
        for (int i = 0; i < 1000; i++)
        {
            streamWriter.WriteLine(i++.ToString());
        }
    }
}


void ReadFromTheFile()
{
    var stremReader = new StreamReader(@"D:\Daniel\a.csv");
    using (stremReader)
    {
        string line = string.Empty;
        while (line != null)
        {
            line = stremReader.ReadLine();
            Console.WriteLine(line);
        }
    }
}

//var obj=new object();
//using (obj)
//{ 

//}




//File.Create(@"..\a.csv");