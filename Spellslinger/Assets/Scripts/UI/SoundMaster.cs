using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour
{

    public AudioClip startClip;
    public List<AudioClip> song;

    private AudioSource audio;
    IEnumerator Start()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.clip = startClip;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = song[Random.Range(0, 2)];
        audio.Play();
        audio.loop = true;

    }


    void Update()
    {
        
    }
}
