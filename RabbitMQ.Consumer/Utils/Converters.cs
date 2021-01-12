using Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace RabbitMQ.Consumer.Utils
{
    static class Converters
    {
        public static Payment ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(arrBytes, 0, arrBytes.Length);
            memoryStream.Seek(0, SeekOrigin.Begin);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return binaryFormatter.Deserialize(memoryStream) as Payment;
        }
    }
}
