using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startbuttonscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonclicked()
    {
        SceneManager.LoadScene("scene_stage");
        roadmanager.whatcar = 1;
    }

    public void deletebuttonClicked()
    {
        PlayerPrefs.DeleteKey("best");
    }
}
