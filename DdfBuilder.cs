using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CabMaker
{
    /// <summary>
    /// Utility class for building a DDF file.
    /// </summary>
    internal class DdfFileBuilder
    {
        string _sourceFolder;
        bool _isRecursive;
        string _targetFolder;
        string _targetFileName;
        CompressionType _compressionType = Constants.DefaultCompressionType;
        CompressionWindowSize _compressionWindowSize;

        public DdfFileBuilder(
            string sourceFolder,
            bool isRecursive,
            string targetFolder,
            string targetFileName,
            CompressionType compressionType,
            CompressionWindowSize compressionWindowSize)
        {
            _isRecursive = isRecursive;

            if (string.IsNullOrWhiteSpace(sourceFolder))
                throw new ArgumentException($"{nameof(sourceFolder)} cannot be empty.");

            if (string.IsNullOrWhiteSpace(targetFolder))
                throw new ArgumentException($"{nameof(targetFolder)} cannot be empty.");

            if (string.IsNullOrWhiteSpace(targetFileName))
                throw new ArgumentException($"{nameof(targetFileName)} cannot be empty.");

            _sourceFolder = sourceFolder;
            _targetFolder = targetFolder;
            _targetFileName = targetFileName;
            _compressionType = compressionType;
            _compressionWindowSize = compressionWindowSize ?? Constants.DefaultCompressionWindowSize;

            DdfFilePath = Path.Combine(_targetFolder, targetFileName + ".ddf");
        }

        /// <summary>
        /// Gets the full path of the DDF file.
        /// </summary>
        public string DdfFilePath { get; private set; }

        /// <summary>
        /// Builds the DDF file and saves it to disk.
        /// </summary>
        public void BuildAndSave()
        {
            bool compress = _compressionType != CompressionType.None;
            string compressValue = compress ? "on" : "off";

            StringBuilder ddf = new StringBuilder();
            ddf.AppendLine($@";*** MakeCAB Directive file;
.OPTION EXPLICIT
.Set CabinetNameTemplate={_targetFileName.EnsureQuoted()}
.Set DiskDirectory1={_targetFolder.EnsureQuoted()}
.Set MaxDiskSize=0
.Set Cabinet=on
.Set Compress={compressValue}");

            if (compress)
            {
                ddf.AppendLine($".Set CompressionType={_compressionType}");
            }

            ddf.AppendLine();

            if (IsCompressionWindowSizeIncluded(_compressionType))
            {
                ddf.AppendFormat($".Set CompressionMemory={(_compressionWindowSize).Exponent}");
                ddf.AppendLine();
            }

            int ddfHeaderLines = ddf.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Length;
            int maxFiles = Constants.MaxLinesInDdf - ddfHeaderLines; // only write enough files to hit the max # of lines allowed in a DDF (blank lines don't count)

            List<DdfFileRow> ddfFiles = GetFiles(_sourceFolder);

            foreach (var ddfFile in ddfFiles.Take(maxFiles))
            {
                ddf.AppendFormat("\"{0}\" \"{1}\"{2}", ddfFile.FullName, ddfFile.Path, Environment.NewLine);
            }

            File.WriteAllText(DdfFilePath, ddf.ToString(), Encoding.Default);
        }

        public static bool IsCompressionWindowSizeIncluded(CompressionType compressionType)
        {
            return compressionType != CompressionType.None && compressionType != Constants.DefaultCompressionType;
        }

        List<DdfFileRow> GetFiles(string sDir)
        {
            List<DdfFileRow> list = new List<DdfFileRow>();
            string srcPath = _sourceFolder;

            foreach (string f in Directory.GetFiles(sDir))
            {
                list.Add(new DdfFileRow()
                {
                    FullName = f,
                    Path = f.Replace(srcPath, "").TrimStart('\\')
                });
            }

            if (_isRecursive)
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    list.AddRange(GetFiles(d));
                }
            }

            return list;
        }
    }
}
