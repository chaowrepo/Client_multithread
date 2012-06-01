using System;
using System.Collections.Generic;
using System.Text;

namespace Client_multithread {
    class exception {
        public string DateTime;
        public string UserName;
        public string OperatingSystem;
        public string Title;
        public string StackTrace;

        public byte[] GetData() {
            List<byte> result = new List<byte>();

            result.Add((byte)Convert.ToInt16(DateTime.Length));
            result.Add((byte)Convert.ToInt16(UserName.Length));
            result.Add((byte)Convert.ToInt16(OperatingSystem.Length));
            result.Add((byte)Convert.ToInt16(Title.Length));
            result.Add((byte)Convert.ToInt16(StackTrace.Length));

            string[] strings = new string[5] { DateTime, UserName, OperatingSystem, Title, StackTrace };
            foreach (string s in strings) {
                foreach (byte b in Encoding.UTF8.GetBytes(s))
                    result.Add(b);
            }

            return result.ToArray();
        }
    }
}
