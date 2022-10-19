using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource start;
    // Start is called before the first frame update
    IEnumerator PlayMove()
    {
        yield return new WaitForSeconds(4);
        PlayerPrefs.SetFloat("allowedmove", 1f);
    }
    void Start()
    {
        PlayerPrefs.SetFloat("allowedmove", 0f);
        StartCoroutine(PlayMove());
        start.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
