using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
    public static string path = Path.Combine(Application.dataPath, "bestrecord.json");
    public static RecordData mydata=new RecordData();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SaveRecord()
    {
        mydata.record = (int)roadmanager.stw6.ElapsedMilliseconds;
        string jsonData = JsonUtility.ToJson(mydata);
        File.WriteAllText(path, jsonData);
    }

    public static int LoadRecord()
    {
        string jsonData = File.ReadAllText(path);
        mydata = JsonUtility.FromJson<RecordData>(jsonData);


        return mydata.record;
    }

    [System.Serializable]
    public class RecordData
    {
        public int record;
    }
}
