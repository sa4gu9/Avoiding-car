using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class AvoidGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;
    Stopwatch stw1 = new Stopwatch();
    Stopwatch stw2 = new Stopwatch();
    Stopwatch stw3 = new Stopwatch();
    float time1;
    float time2;
    float time3;
    void Start()
    {
        time1 = Random.Range(2.0f, 3.0f);//triangle
        time2 = Random.Range(1.0f, 4.0f);//speedup
        time3 = Random.Range(0.5f, 2.0f);//speeddown
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            stw1.Start();
            stw2.Start();
            stw3.Start();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            stw1.Stop();
            stw2.Stop();
            stw3.Stop();
        }

        if (Input.GetMouseButtonDown(0))
        {
            stw1.Start();
            stw2.Start();
            stw3.Start();
        }

        if (Input.GetMouseButtonUp(0))
        {
            stw1.Stop();
            stw2.Stop();
            stw3.Stop();
        }

        if (stw1.ElapsedMilliseconds >= time1 * 1000)
        {
            GameObject triangle = Instantiate(go1) as GameObject;
            time1 = Random.Range(3.0f, 5.0f);
            triangle.transform.position = new Vector3(Random.Range(-9.0f, 9.0f),58, 0);
            stw1.Restart();
        }

        if (stw2.ElapsedMilliseconds >= time2 * 1000)
        {
            GameObject speedup = Instantiate(go2) as GameObject;
            time2 = Random.Range(1.0f, 12.0f);
            speedup.transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 58, 0);
            stw2.Restart();
        }

        if (stw3.ElapsedMilliseconds >= time2 * 1000)
        {
            GameObject speeddown = Instantiate(go3) as GameObject;
            time3 = Random.Range(1.0f, 12.0f);
            speeddown.transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 58, 0);
            stw3.Restart();
        }

        if (roadmanager.clear == 2)
        {
            Destroy(this.gameObject);
        }

        
    }
}
