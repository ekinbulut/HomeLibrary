using System;
using System.IO;

namespace Library.Mvc.Helpers
{
    public static class StreamOperator
    {
        public static byte[] GetBytes(string obj)
        {
            Byte[] mybytearray;

            using (FileStream objfilestream = new FileStream(obj, FileMode.Open, FileAccess.Read))
            {
                int len = (int) objfilestream.Length;
                mybytearray = new Byte[len];
                objfilestream.Read(mybytearray, 0, len);
            }

            return mybytearray;
        }
    }
}
