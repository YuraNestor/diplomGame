using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoundPlayer : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource ass;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PlayAudio(AudioClip audioClip, float volume)
    {
        GameObject go = Instantiate(gameObject);
        ass = go.GetComponent<AudioSource>();
        ass.volume = volume;
        ass.clip =audioClip;
        ass.Play();
        Destroy(go, ass.clip.length);

    }
    public void PlayAudio(int i, float volume)
    {
        GameObject go = Instantiate(gameObject);
        ass = go.GetComponent<AudioSource>();
        ass.volume = volume;
        ass.clip = audioClips[i];
        ass.Play();
        Destroy(go, ass.clip.length);

    }
    public void PlayAudio(int i)
    {
        GameObject go = Instantiate(gameObject);
        ass = go.GetComponent<AudioSource>();
        ass.volume = 0.7f;
        ass.clip = audioClips[i];
        ass.Play();
        Destroy(go, ass.clip.length);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
