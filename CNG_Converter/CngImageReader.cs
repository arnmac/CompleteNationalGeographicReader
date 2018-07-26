using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace CNG_Converter
{
    internal class CngImageReader : BinaryReader
    {
        private const int XorValue = 239;

        public CngImageReader(Stream input) : base(input)
        {
        }

        public CngImageReader(Stream input, Encoding encoding) : base(input, encoding)
        {
        }

        public CngImageReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
        {
        }

        public override byte[] ReadBytes(int count)
        {
            var tmpBuffer = new byte[count];
            var buffer = new byte[count];
            var length = 0;

            do
            {
                var num = this.BaseStream.Read(tmpBuffer, length, count);
                if (num != 0)
                {
                    length += num;
                    count -= num;
                    for (var i = 0; i < num; i++)
                    {
                        buffer[i] = (byte) (tmpBuffer[i] ^ XorValue);
                    }
                }
                else
                {
                    break;
                }
            } while (count > 0);

            return buffer;
        }

        public override int Read()
        {
            return this.ReadBytes(1).First();
        }
    }
}