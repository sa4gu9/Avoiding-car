using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
public class carmanager : MonoBehaviour
{
    Stopwatch stw1 = new Stopwatch();

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (stw1.ElapsedMilliseconds >= 700)
        {
            stw1.Reset();
            roadmanager.speedchange = 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        print("collision");
        if (collision.gameObject.tag == "avoid") {
            roadmanager.speed /= 2;
            Destroy(collision.gameObject);
        }

          
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("Trigger");
        if (collision.gameObject.tag == "speedup")
        {
            roadmanager.speedchange = 0.001f;
            stw1.Restart();
        }

        if (collision.gameObject.tag == "speeddown")
        {
            roadmanager.speedchange = 4f;
            stw1.Restart();
        }
    }
}
