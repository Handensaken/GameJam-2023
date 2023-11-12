using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControllerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeAudioSource.StartFade(this.gameObject.GetComponent<AudioSource>(), 3.5f, 1f));
        gameObject.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
