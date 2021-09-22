using System.IO;
using UnityEngine;

namespace CodeGeek
{
    public class JsonData
    {
        public void Save(DataInfo data , string path = null)
        {
            var str = JsonUtility.ToJson(data); 
            File.WriteAllText(path, Crypto.MyCrypto(str));
            //File.WriteAllText(path, str);
        }

        public DataInfo Load(string path = null)
        {
            var str = File.ReadAllText(path);
            return JsonUtility.FromJson<DataInfo>(Crypto.MyCrypto(str));
            //return JsonUtility.FromJson<DataInfo>(str);
        }
    }
}