using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Delegates
{
    

    public class FileReader
    {
        private bool _continueSearch { get; set; } = true;
        //public delegate void EventHandler(string data);
        public event EventHandler FileFound;

        public void RaiseEventFileFound(FileArgs fileArgs)
        {
            FileFound?.Invoke(this, fileArgs);
        }

        private string Path { get; set; }
        public FileReader(string path)
        {
            this.Path = path;
        }

        public void SetPath (string path) => this.Path = path;

        public void CheckFiles(Func<string,bool> cancellationDelegate = null,string? path = null)
        {
            if (_continueSearch == false)
            {
                _continueSearch = true;
                return;
            }
            _continueSearch = true;
            try
            {
                if (path == null) { path = Path; }
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    if (cancellationDelegate != null) { this._continueSearch = cancellationDelegate(file); }
                    RaiseEventFileFound(new FileArgs(Path, file));
                }
                var directories = Directory.GetDirectories(path);
                foreach (var directory in directories)
                {
                    CheckFiles(cancellationDelegate, directory);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }


    }

    public class FileArgs : EventArgs
    {
        public string Path { get; set; }
        public string FileName { get; set; }

        public FileArgs(string path, string fileName)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
        }
    } 

}
