namespace LorenzConsole
{
    using nl.gn.BaudotPortable;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BitConverter
    {
        public static bool[] ToBoolsT<T>(T input)
        {
            int size = -1;
            byte val = 0;

            if (input is VBit vBit)
            {
                size = 5;
                val = vBit.Value;
            }
            else if (input is byte bte)
            {
                size = 8;
                val = bte;
            }

            bool[] result = new bool[size];

            for (int i = 0; i < result.Length; ++i)
            {
                result[i] = (val & (1 << i)) != 0;
            }

            Array.Reverse(result);

            return result;
        }

        public static bool[] ToBools(IEnumerable<VBit> vBits)
        {
            var bools = new List<bool>();

            foreach (VBit vBit in vBits)
            {
                bool[] vBitBools = ToBoolsT(vBit);

                bools.AddRange(vBitBools);
            }

            bool[] result = bools.ToArray();

            return result;
        }

        public static bool[] ToBools(byte[] bytes)
        {
            var result = new List<bool>();

            foreach (byte b in bytes)
            {
                var bools = ToBoolsT(b);

                result.AddRange(bools);
            }

            return result.ToArray();
        }

        public static byte[] ToBytes(IEnumerable<VBit> vBits)
        {
            var bools = new List<bool>();

            foreach (VBit vBit in vBits)
            {
                bool[] vBitBools = ToBoolsT(vBit);

                bools.AddRange(vBitBools);
            }

            var result = new List<byte>();

            byte bte = 0;
            int index = 0;

            foreach (bool b in bools)
            {
                if (b)
                {
                    bte |= (byte)(1 << (7 - index));
                }

                ++index;

                if (index == 8)
                {
                    index = 0;
                    result.Add(bte);
                    bte = 0;
                }
            }

            if (index != 0)
            {
                result.Add(bte);
            }

            return result.ToArray();
        }

        public static byte ToByte(bool[] bools)
        {
            byte bte = 0;
            int index = 0;

            foreach (bool b in bools)
            {
                if (b)
                {
                    bte |= (byte)(1 << ((bools.Length - 1) - index));
                }

                ++index;

                if (index == 8)
                {
                    break;
                }
            }

            return bte;
        }

        public static VBit[] FromBytes(IEnumerable<byte> bytes)
        {
            bool[] bools = ToBools(bytes.ToArray());

            var result = new List<VBit>();

            int index = 0;
            var vBitBools = new bool[5];

            foreach (bool b in bools)
            {
                vBitBools[index] = b;

                ++index;

                if (index == 5)
                {
                    byte val = ToByte(vBitBools);
                    var vBit = new VBit(val);
                    result.Add(vBit);
                    index = 0;
                    vBitBools = new bool[5];
                }
            }

            return result.ToArray();
        }

        public static string ToBase64(IEnumerable<VBit> vBits)
        {
            var bytes = new List<byte>();

            // The first byte is the length...
            bytes.Add((byte)vBits.Count());

            bytes.AddRange( ToBytes(vBits));

            string base64 = Convert.ToBase64String(bytes.ToArray());

            return base64;
        }

        public static IEnumerable<VBit> FromBase64(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);

            byte length = bytes[0];

            var key = new byte[bytes.Length -1];

            Array.Copy(bytes, 1, key, 0, key.Length);

            VBit[] vBits = FromBytes(key);

            var result = new VBit[length];

            Array.Copy(vBits, result, length);

            return result;
        }
    }
}
