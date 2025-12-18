using UnityEngine;

public class aud2 : MonoBehaviour
{
    AudioSource music;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music = GetComponent<AudioSource>();
        music.volume = 0.7f;
        music.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
