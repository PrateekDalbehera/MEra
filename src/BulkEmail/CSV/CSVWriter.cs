using BulkEmail.Constants;
using System.IO;
using System.Text;

namespace BulkEmail.CSV
{
    public class CSVWriter : ICSVWriter
    {
        private readonly StreamWriter _writer;
        public StreamWriter Writer
        {
            get
            {
                return _writer;
            }
        }

        public CSVWriter(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            _writer = fileInfo.CreateText();
        }

        public void Write(params string[] columns)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < columns.Length; i++)
            {
                sb.Append(columns[i]);
                if ((columns.Length - 1) != i)
                {
                    sb.Append(Delimiter.Tab);
                }
            }

            WriteLine(sb.ToString());
        }

        private void WriteLine(string line)
        {
            _writer.WriteLine(line);
        }

        public void Close()
        {
            _writer.Close();
        }
    }
}
