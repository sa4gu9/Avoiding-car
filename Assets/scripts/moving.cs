using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    int rheight;
    int rwidth;

    int wratio;
    int hratio;

    // Start is called before the first frame update
    void Start()
    {
        rheight = Screen.height;
        rwidth = Screen.width;

        int max;
        int min;

        if (rheight>rwidth)
        {
            max = rheight;
            min = rwidth;
        }
        else
        {
            min = rheight;
            max = rwidth;
        }

        int temp;

        while (max%min!=0)
        {
            temp = max % min;
            max = min;
            min = temp;
        }

        int gcd = min;

        wratio = rwidth / gcd;
        hratio = rheight / gcd;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            roadmanager.inputup();
            roadmanager.startup();

            Debug.Log(Input.mousePosition.x);

            float mouseRatio = Input.mousePosition.x / Screen.width;

            print(mouseRatio);
            print(wratio);
            print(hratio);



            if (Input.mousePosition.x >= 140 && Input.mousePosition.x <= 940)
                roadmanager.car.transform.position = new Vector3((Input.mousePosition.x - 140) / 39.17f - 10, roadmanager.car.transform.position.y, roadmanager.car.transform.position.z);
        }
        else
        {
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
