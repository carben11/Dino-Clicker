using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{

    public AudioSource audio;

    public AudioSource audioButton2;

    public AudioSource audioEgg;
    
    public void playButton()
    {
        audio.Play();
    }

    public void playButton2()
    {
        audioButton2.Play();
    }

    public void playEgg()
    {
        audioEgg.Play();
    }
}