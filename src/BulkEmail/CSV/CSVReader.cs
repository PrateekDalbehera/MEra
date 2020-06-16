using BulkEmail.Constants;
using System.IO;

namespace BulkEmail.CSV
{
    public class CSVReader : ICSVReader
    {
        private readonly StreamReader _reader;
        public StreamReader Reader
        {
            get { return _reader; }
        }

        public CSVReader(string fileName)
        {
            _reader = File.OpenText(fileName);
        }

        public bool Read(string column1, string column2)
        {
            return ReadLine().Split(Delimiter.Tab).Length > 0;
        }
        
        public bool Read(out string column1, out string column2)
        {
            column1 = null;
            column2 = null;

            if (CheckIfFileIsNotEmpty(out string[] columns))
            {
                column1 = columns[0];
                column2 = columns[1];

                return true;
            }

            return false;
        }

        public void Close()
        {
            _reader.Close();
        }

        private string ReadLine()
        {
            return _reader.ReadLine();
        }

        private bool CheckIfFileIsNotEmpty(out string[] columns)
        {
            columns = null;
            string line = ReadLine();
            
            if (line != null && (line.Split(Delimiter.Tab).Length > 0))
            {
                columns = line.Split(Delimiter.Tab);
                return true;
            }            
            return false;
        }
    }
}
