using SchedularLib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SchedularLib.Managers
{
    public static class IdManager
    {
        public static uint GetId()
        {
            ReadFile();
            uint id = idKeeper.currentId++;
            WriteFile();
            return id;
        }

        public static void DropIds()
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        private static BinaryFormatter binaryFormatter = new BinaryFormatter();
        private static IdKeeper idKeeper;
        private static string fileName = "idKeeper.dat";

        private static void WriteFile()
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                binaryFormatter.Serialize(fs, idKeeper);
            }
        }

        private static void ReadFile()
        {
            if (File.Exists(fileName))
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    idKeeper = (IdKeeper)binaryFormatter.Deserialize(fs);
                }
            }
            else
            {
                idKeeper = new IdKeeper() {
                    currentId = 1
                };
                WriteFile();
            }
        }
    }
}
