using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;

namespace CabMaker
{
    public static class IsolatedStorageExtensions
    {
        public static void SaveObject(this IsolatedStorage isoStorage, object obj, string fileName)
        {
            using (IsolatedStorageFileStream writeStream = new IsolatedStorageFileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(writeStream, obj);
            }
        }

        public static T LoadObject<T>(this IsolatedStorage isoStorage, string fileName)
        {
            try
            {
                using (IsolatedStorageFileStream readStream = new IsolatedStorageFileStream(fileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    try
                    {
                        T readData = (T)formatter.Deserialize(readStream);
                        return readData;
                    }
                    catch
                    {
                        return default(T);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                return default(T);
            }
        }
    }
}
