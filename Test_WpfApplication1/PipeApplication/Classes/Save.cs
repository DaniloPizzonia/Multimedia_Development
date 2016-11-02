using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PipeApplication {
    class Save {
        public static void saveObject<T>(T obj, string dataFileName) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs;
            try {
                fs = new FileStream(dataFileName, FileMode.Create);
                bf.Serialize(fs, obj);
                fs.Close();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public static T readDataFile<T>(string dataName) {
            T data;
            FileStream fs;
            BinaryFormatter bf;
            try {
                fs = new FileStream(dataName, FileMode.Open);
                bf = new BinaryFormatter();
                data = (T)bf.Deserialize(fs);
                return data;
            } catch(Exception) {
                return default(T);
                throw;
            }
        }
    }
}
