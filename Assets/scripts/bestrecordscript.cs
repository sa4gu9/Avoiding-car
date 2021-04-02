using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bestrecordscript : MonoBehaviour
{

    public Text bestrecord;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (File.Exists(RecordManager.path))
        {
            bestrecord.text = "BEST : " + (float)RecordManager.LoadRecord()/1000;
        }
        else
        {
            bestrecord.text = "no record";
        }
    }

    

     
}
