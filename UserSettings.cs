using System;
using System.IO.IsolatedStorage;
using System.Windows.Forms;

namespace CabMaker
{
    [Serializable]
    public class UserSettings
    {
        static readonly string _settingsFileName = $"{Application.ProductName}.dat";

        public string SourcePath { get; set; }
        public bool IncludeSubfolders { get; set; }
        public string TargetPath { get; set; }
        public string FileName { get; set; }
        public CompressionType CompressionType { get; set; }
        public int CompressionWindowSize { get; set; }

        public UserSettings()
        {
            SourcePath = "";
            IncludeSubfolders = true;
            TargetPath = "";
            FileName = "";
            CompressionType = Constants.DefaultCompressionType;
            CompressionWindowSize = Constants.DefaultCompressionWindowSize.Exponent;
        }

        public static void Clear()
        {
            // HACK:
            // For whatever reason, deleting files from isolated storage never seems to work (throws an exception every time).
            // So... as a workaround, we'll simply save the default settings to "clear out" user-saved settings. If anyone
            // out there has more time than me to investigate/fix this, please feel free. I'd love to find a better solution.

            var defaultSettings = new UserSettings();

            Save(defaultSettings);
        }

        public static UserSettings FetchWithDefaults()
        {
            using (var storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
            {
                return storage.LoadObject<UserSettings>(_settingsFileName) ?? new UserSettings();
            }
        }

        public static void Save(
            string sourceFolder,
            bool isRecursive,
            string targetFolder,
            string targetFileName,
            CompressionType compressionType,
            CompressionWindowSize compressionWindowSize)
        {
            UserSettings settings = new UserSettings()
            {
                SourcePath = sourceFolder,
                IncludeSubfolders = isRecursive,
                TargetPath = targetFolder,
                FileName = targetFileName,
                CompressionType = compressionType,
                CompressionWindowSize = compressionWindowSize.Exponent
            };

            Save(settings);
        }

        public static void Save(UserSettings settings)
        {
            using (var storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
            {
                storage.SaveObject(settings, _settingsFileName);
            }
        }
    }
}
