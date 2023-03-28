using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Fundamental
{
    public class JsonTest : MonoBehaviour
    {
        private static string _path = Application.persistentDataPath;

        public static void SaveData(string fileName, int value)
        {
            IntClass jsonClass = new IntClass();
            jsonClass.parameter = value;

            string json = JsonUtility.ToJson(jsonClass, true);
            File.WriteAllText(_path + "/" + fileName + ".json", json);
        }

        public static IntClass LoadData(string filename)
        {
            if (!File.Exists(_path + "/" + filename + ".json"))
                return null;
            string json = File.ReadAllText(_path + "/" + filename + ".json");
            IntClass data = JsonUtility.FromJson<IntClass>(json);
            return data;

        }


        
        }
    }

