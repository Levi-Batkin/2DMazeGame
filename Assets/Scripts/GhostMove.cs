using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class GhostMove : MonoBehaviour
{
    IAstarAI ai;
    // Start is called before the first frame update
    public AudioSource death;
    public GameObject pacman, aiselect;
    IEnumerator DestroyPacman()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(pacman);
    }
    IEnumerator StopPacman()
    {
        yield return new WaitForSeconds(0.25f);
        PlayerPrefs.SetFloat("allowedmove", 0f);
    }
    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate ()
    {
        if (PlayerPrefs.GetFloat("allowedmove") == 1f)
        {
            GetComponent<AIDestinationSetter>().enabled = true;
        } 
        else if (PlayerPrefs.GetFloat("allowedmove") == 0f) 
        {
            GetComponent<AIDestinationSetter>().enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == pacman)
        {
            PlayerPrefs.SetFloat("allowedmove", 0f);
            StartCoroutine(StopPacman());
            death.Play();
            StartCoroutine(DestroyPacman());
        }
    }
}
