﻿using System;
using System.Collections.Generic;
using System.IO;
using CNG_CngImageReader;

namespace CNG_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            const string inputFile = @"/media/aaron/CNG_DISC1/disc1/images/199x/19960501/NGM_1996_05_040_4.cng"; //@"E:\NGM_1996_05_001_4.cng";
            const string outputFile = @"outputfile.jpg";
            
            var fileInfo = new FileInfo(inputFile);
            var fileLength = fileInfo.Length;

            using (var fs = fileInfo.OpenRead())
            {
                using(var os = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                {
                    var br = new CngImageReader(fs);

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