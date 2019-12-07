using System;
using System.Collections.Generic;
using System.Text;

namespace Musication.Services.Interfaces
{
    public interface IContentPackage
    {
        void ExtractResourceFiles(string source, string destination, string zipFileName);
    }
    
}