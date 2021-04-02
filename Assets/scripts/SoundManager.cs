using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static float bgmVolume;
    public static float effectVolume;
    public Slider music;
    public Slider effect;

    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        music.value = bgmVolume;
        effect.value = effectVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BGMSound()
    {
        bgmVolume = music.value;
        musicSource.volume = music.value;
    }

    public void effectSound()
    {
        effectVolume = effect.value;
    }
}
