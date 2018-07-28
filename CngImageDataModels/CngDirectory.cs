using System;
using System.Collections.Generic;

namespace CngImageDataModels
{
    public class CngDirectory
    {
        private static string _directoryFileLocation;
        
        public CngDirectory(string fileLocation)
        {
            _directoryFileLocation = fileLocation;
        }

        public List<CngMagazineIssue> GetIssues()
        {
            throw new NotImplementedException();
        }
    }
}