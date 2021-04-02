using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
public class carmanager : MonoBehaviour
{
    Stopwatch stw1 = new Stopwatch();

    public AudioClip audioClip;
    public AudioClip speedUpaudio;
    public AudioClip speedDownaudio;

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
            roadmanager.reverse = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        print("collision");
        if (collision.gameObject.tag == "avoid") {
            roadmanager.speed /= 2;
            Destroy(collision.gameObject);

            AudioSource audio = gameObject.AddComponent<AudioSource>();
            audio.volume = SoundManager.effectVolume;
            audio.clip = audioClip;
            audio.Play();
            StartCoroutine(DeleteAudio(audio));
        }

          
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.volume = 0.5f;

        if (collision.gameObject.tag == "speedup")
        {
            roadmanager.reverse = false;
            roadmanager.speedchange = 0.1f;
            stw1.Restart();

            
            audio.clip = speedUpaudio;
            

        }

        if (collision.gameObject.tag == "speeddown")
        {
            roadmanager.reverse = true;
            roadmanager.speedchange = 0.2f;
            stw1.Restart();

            audio.clip = speedDownaudio;
        }
        audio.volume = SoundManager.effectVolume;
        audio.Play();
        StartCoroutine(DeleteAudio(audio));
        Destroy(collision.gameObject);
    }



    IEnumerator DeleteAudio(AudioSource audio)
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(audio);
    } 
}
