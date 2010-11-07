using System;

namespace myDojo.Infrastructure
{
    public static class ANew
    {
        public static Guid Comb()
        {
            byte[] dateBytes = BitConverter.GetBytes(DateTime.Now.Ticks);
            byte[] guidBytes = Guid.NewGuid().ToByteArray();
            // copy the last six bytes from the date to the last six bytes of the GUID
            Array.Copy(dateBytes, dateBytes.Length - 7, guidBytes, guidBytes.Length - 7, 6);
            return new Guid(guidBytes);
        }
    }
}