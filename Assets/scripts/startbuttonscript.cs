using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startbuttonscript : MonoBehaviour
{
    public GameObject deletePanel;
    // Start is called before the first frame update
    void Start()
    {
        deletePanel.SetActive(false);

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
        deletePanel.SetActive(true);
    }

    public void YesDelete()
    {
        PlayerPrefs.DeleteKey("best");
        deletePanel.SetActive(false);

    }

    public void NoDelete()
    {
        deletePanel.SetActive(false);
    }
}
