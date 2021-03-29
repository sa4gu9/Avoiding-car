using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag=="speeddown")
            transform.Translate(new Vector3(0,  (float)roadmanager.speed/600,0));
        else
            transform.Translate(new Vector3(0, -((float)roadmanager.speed / 700), 0));

        if (transform.position.y <= -50)
        {
            Destroy(gameObject);
        }
    }
}
