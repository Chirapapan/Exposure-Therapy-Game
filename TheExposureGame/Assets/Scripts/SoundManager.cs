using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioSource bgSound;

    // Use this for initialization
    void Awake ()
    {
        DontDestroyOnLoad(transform.gameObject);
        bgSound.Play();
	}
}
