//https://social.technet.microsoft.com/wiki/contents/articles/53467.c-insert-binary-files-into-sql-server-table.aspx

using System;
using System.Collections.Generic;
using static Utilities.InsertFileBytes;

namespace ReadBlobIntoDB
{
    class Program
    {
        static void Main()
        {
            List<FilePaths> filePathslist = new List<FilePaths>();

            var list = GetFilePathsAndBinaryIdx(filePathslist);

            //Uncomment to use!
            //InsertFiles(list);
        }  
    }   
}

