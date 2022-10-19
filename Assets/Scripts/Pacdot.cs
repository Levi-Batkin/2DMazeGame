using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pacdot : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    float timer;
    private bool audio1 = true;
    void Start()
    {
    }
    AudioClip RandomClip(){
        return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }
    void Update() {
        timer += Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "pacman")
        {
            if (timer > 0.25)
            {
                if (audio1 == true)
                {
                    audio1 = false;
                    audioSource.PlayOneShot(audioClipArray[0], 0.5f);
                }
                else if (audio1 == false)
                {
                    audio1 = true;
                    audioSource.PlayOneShot(audioClipArray[1], 0.5f);
                }
                timer = 0;
            }
            Destroy(gameObject);
        }
    }
}
