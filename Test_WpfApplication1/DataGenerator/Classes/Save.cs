using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace DataGenerator {
    public class Save {

        public static void saveObject<T>(T obj, string dataFileName) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs;
            try {
                fs = new FileStream(dataFileName, FileMode.Create);
                bf.Serialize(fs, obj);
                fs.Close();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public static T readDataFile<T>(string dataName) {
            T data;
            FileStream fs;
            BinaryFormatter bf;
            try {
                fs =  new FileStream(dataName, FileMode.Open);
                bf = new BinaryFormatter();
                data = (T)bf.Deserialize(fs);
                return data;
            }
            catch(Exception) {
                return default(T);
                throw;
            }
        }

        public static void saveXML<T>(T data, string fileName) {
            XmlSerializer oXmlSerializer = new XmlSerializer(typeof(T));
            FileStream oStream;
            oStream = new FileStream(fileName, FileMode.Create);
            oXmlSerializer.Serialize(oStream, data);
            oStream.Close();
        }

        public static T readXML<T>(string fileName) {
            try {
                using (StreamReader oStreamreader = new StreamReader(fileName)) {
                    XmlSerializer oXmlSerializer = new XmlSerializer(typeof(T));
                    return (T)oXmlSerializer.Deserialize(oStreamreader);
                }
            } catch(Exception) {

                return default(T);
            }
        }
    }
}
