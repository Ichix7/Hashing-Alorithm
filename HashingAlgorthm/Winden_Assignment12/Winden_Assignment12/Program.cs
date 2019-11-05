
using System;
class WindenAssignment12
{
    static int coll = 0;

    static void Main()
    {
        string[] ssnumbs = new string[1000];


        //Creating Random ssn
        Random rnd = new Random();
        for (int i = 0; i < 1000; i++)
        {
            string b ="";
            for (int j = 0; j < 10; j++)
            {
                b += rnd.Next(0, 9);
            }
            ssnumbs[i] = b;
        }
        
        Hash5(ssnumbs);

        //Bubble Sort!!
        ///
        for (int i = 1; i < ssnumbs.Length; i++)
        {
            for (int j = 0; j < ssnumbs.Length - 1; j++)
            {
                

                if (Convert.ToDouble(ssnumbs[j]) > Convert.ToDouble(ssnumbs[j + 1]))
                {
                    string temp = ssnumbs[j + 1];
                    ssnumbs[j + 1] = ssnumbs[j];
                    ssnumbs[j] = temp;
                }
            }
        }        

        ShowDistrib(ssnumbs);

        Console.WriteLine("Number of Collissions: {0}", coll);

    

    Console.ReadLine();
    }
    /// <summary>
    /// display the array and count if there are collissions
    /// </summary>
    /// <param name="arr"></param>
    static void ShowDistrib(string[] arr)
    {
        for (int i = 0; i <= arr.GetUpperBound(0)-1; i++)
        {
            if (arr[i] != null)
                Console.WriteLine(i + " " + arr[i]);
           if(arr[i] == (arr[i + 1])) { coll++; }
        }
    }

    /// <summary>
    /// Crc32 When i did this one it kept showing no collissions nad i cant figure out why
    /// </summary>
    /// <param name="nums"></param>
    public static  void Hash5(string[] nums)
    {
        uint hash = 0xedb88320;
        uint temp;
        for (uint i = 0; i < nums.Length; ++i)
        {
            temp = i;
            for (int j = 8; j > 0; --j)
            {
                if ((temp & 1) == 1)
                {
                    temp = (uint)((temp >> 1) ^ hash);
                }
                else
                {
                    temp >>= 1;
                    //temp = temp + 1000000000;
                }
            }
            nums[i] = temp.ToString();
        }
    }
        /// <summary>
        /// Knuth
        /// </summary>
        /// <param name="read"></param>
        /// <returns></returns>
        public static UInt64 Hash4(string read)
    {
        UInt64 hash = 3074457345618258791ul;
        for (int i = 0; i < read.Length; i++)
        {
            hash += read[i];
            hash *= 3074457345618258799ul;
        }
        return hash;
    }
    /// <summary>
    /// SDBM
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static ulong Hash3(string str)
    {
        ulong hash = 0;

        foreach (char c in str)
        {
            hash = c + (hash << 6) + (hash << 16) - hash;
        }

        return hash;
    }
    /// <summary>
    /// FNV
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static uint Hash2(string str)
    {
        const uint fnv_prime = 0x811C9DC5;
        uint hash = 0;
        uint i = 0;

        for (i = 0; i < str.Length; i++)
        {
            hash *= fnv_prime;
            hash ^= ((byte)str[(int)i]);
        }

        return hash;
    }
    /// <summary>
    /// DJB2
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static uint Hash(string str)
    {
        uint hash = 5381;
        uint i = 0;

        for (i = 0; i < str.Length; i++)
        {
            hash = ((hash << 5) + hash) + ((byte)str[(int)i]);
        }

        return hash;
    }

}

