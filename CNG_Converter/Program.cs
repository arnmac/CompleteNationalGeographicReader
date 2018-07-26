using System.IO;

namespace CNG_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = @"E:\NGM_1996_05_001_4.cng";
            var outputFile = @"E:\outputfile.jpg";
            
            var fileInfo = new FileInfo(inputFile);
            var fileLength = fileInfo.Length;

            using (var fs = fileInfo.OpenRead())
            {
                using(var os = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                {
                    var br = new CngImageReader(fs);//new BinaryReader(fs);

                    var buffer = br.ReadBytes((int) fileLength);
                    var bw = new BinaryWriter(os);

                    for (var i = 0; i < fileLength; i++)
                    {
                        bw.Write(buffer[i]);
                    }
                }
            }
        }
    }
}