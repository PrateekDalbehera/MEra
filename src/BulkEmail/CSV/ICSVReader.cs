using System.IO;

namespace BulkEmail.CSV
{
    public interface ICSVReader
    {
        StreamReader Reader { get; }

        bool Read(string column1, string column2);

        bool Read(out string column1, out string column2);

        void Close();
    }
}
