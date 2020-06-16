using System;
using System.IO;

namespace BulkEmail.CSV
{
    /*
     2) Refactor the CSVReaderWriter implementation into clean, elegant, well performing 
        and maintainable code, as you see fit.
        You should not update the BulkEmailProcessor as part of this task.
        Backwards compatibility of the CSVReaderWriter must be maintained, so that the 
        existing BulkEmailProcessor is not broken.
        Other that that, you can make any change you see fit, even to the code structure.

        [Prateek Dalbehera]
        1. Created interface.
    */

    public class CSVReaderWriter
    {
        private ICSVReader _reader;
        private ICSVWriter _writer;

        [Flags]
        public enum Mode { Read = 1, Write = 2 };

        public CSVReaderWriter() { }

        public CSVReaderWriter(ICSVReader reader, ICSVWriter writer)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
            _writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public void Open(string fileName, Mode mode)
        {
            switch (mode)
            {
                case Mode.Read:
                    _reader = new CSVReader(fileName);
                    break;
                case Mode.Write:
                    _writer = new CSVWriter(fileName);
                    break;

                default:
                    throw new Exception("Unknown file mode for " + fileName);

            }
        }

        public void Write(params string[] columns)
        {
            IsWriterInitialized();

            _writer.Write(columns);
        }

        public bool Read(string column1, string column2)
        {
            IsReaderInitialized();

            return _reader.Read(column1, column2);
        }

        public bool Read(out string column1, out string column2)
        {
            IsReaderInitialized();

            column1 = null; column2 = null;

            return _reader.Read(column1, column2);
        }

        public void Close()
        {
            IsWriterInitialized();
            IsReaderInitialized();

            _writer.Close();
            _reader.Close();
        }

        private void IsWriterInitialized()
        {
            if (_writer == null) throw new Exception("Writer is not initialized.");
        }

        private void IsReaderInitialized()
        {
            if (_reader == null) throw new Exception("Reader is not initialized.");
        }
    }
}
