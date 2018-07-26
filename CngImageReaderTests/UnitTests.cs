using System;
using System.IO;
using CNG_CngImageReader;
using Xunit;
using Xunit.Sdk;

namespace CngImageReaderTests
{
    public class UnitTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData('A')]
        [InlineData(0x01)]
        public void CngImageReader_ReadByte_Modifies_Stream_Data_Test(byte data)
        {
            // Arrange
            var testStream = new MemoryStream(data);
            var cngReader = new CngImageReader(testStream);
            
            // Act
            var result = (byte)cngReader.Read();

            // Assert
            Assert.NotEqual(data, result);
        }

        [Theory]
        [InlineData(new byte[] {1, 2, 3, 4, 5, 6, 7, 8})]
        [InlineData(new byte[] {0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08})]
        public void CngImageReader_ReadBytes_Returns_Number_Bytes_Requested_If_Stream_Contains_Length_Test(byte[] data)
        {
            // Arrange
            
            // Act
            
            // Assert
            Assert.True(false);
        }

        [Theory]
        [InlineData(new byte[] {1, 2, 3, 4, 5, 6, 7, 8})]
        [InlineData(new byte[] {0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08})]
        public void CngImageReader_ReadBytes_Modifies_Stream_Data_Test(byte[] data)
        {
            // Arrange
            var testStream = new MemoryStream(data);
            var cngReader = new CngImageReader(testStream);

            // Act
            var result = cngReader.ReadBytes(8);

            // Assert
            for(int i = 0; i < data.Length; i++)
            {
                Assert.NotEqual(data[i], result[i]);
            }
        }
    }
}