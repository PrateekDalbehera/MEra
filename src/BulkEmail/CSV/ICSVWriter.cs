using System.IO;

namespace BulkEmail.CSV
{
    public interface ICSVWriter
    {
        StreamWriter Writer { get; }

        void Write(params string[] columns);

        void Close();
    }
}
