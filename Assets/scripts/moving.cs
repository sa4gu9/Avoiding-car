using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            roadmanager.inputup();
            roadmanager.startup();
            print(Input.mousePosition.x);
            if (Input.mousePosition.x >= 140 && Input.mousePosition.x <= 940)
                roadmanager.car.transform.position = new Vector3((Input.mousePosition.x - 140) / 39.17f - 10, roadmanager.car.transform.position.y, roadmanager.car.transform.position.z);
        }
        else
        {
            print("inputnotup");
            roadmanager.inputnotup();
        }

        if (Input.GetMouseButtonUp(0))
        {
            roadmanager.stw1.Stop();
            roadmanager.stw1.Reset();
            roadmanager.stw2.Start();
        }
    }
}
