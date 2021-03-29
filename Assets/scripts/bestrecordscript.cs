using System.Collections;
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
        if (PlayerPrefs.HasKey("best"))
        {
            print(PlayerPrefs.GetInt("best"));
            bestrecord.text = "BEST : " + (float)PlayerPrefs.GetInt("best")/1000;
        }
        else
        {
            bestrecord.text = "no record";
        }
    }
}
