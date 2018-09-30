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
    }
}
