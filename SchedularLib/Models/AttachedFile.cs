using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedularLib.Models
{
    [Serializable]
    public class AttachedFile
    {
        public string Name { get; set; }
        public byte[] FileContent { get; set; }


        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ FileContent.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            AttachedFile other = obj as AttachedFile;
            return Name == other.Name &&
                FileContent == other.FileContent;
        }

    }
}
