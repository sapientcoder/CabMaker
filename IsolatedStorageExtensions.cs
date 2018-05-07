using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;

namespace CabMaker
{
    /// <summary>
    /// Extension methods for working with isolated storage.
    /// </summary>
    public static class IsolatedStorageExtensions
    {
        /// <summary>
        /// Saves an object to isolated storage.
        /// </summary>
        /// <param name="isoStorage">Isolated storage</param>
        /// <param name="obj">Object to save</param>
        /// <param name="fileName">File name to which object will be saved</param>
        public static void SaveObject(this IsolatedStorage isoStorage, object obj, string fileName)
        {
            using (IsolatedStorageFileStream writeStream = new IsolatedStorageFileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(writeStream, obj);
            }
        }

        /// <summary>
        /// Reads an object from isolated storage.
        /// </summary>
        /// <typeparam name="T">Type of object to read</typeparam>
        /// <param name="isoStorage">Isolated storage</param>
        /// <param name="fileName">File name from which object will be loaded</param>
        /// <returns>Object read from isolated storage (as type <typeparamref name="T"/>)</returns>
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
