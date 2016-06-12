using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    Vector3 clickedPosition;
    Vector3 movedPosition;
    public float speed = 0.7f;
    public bool spinning;

    private AudioSource spinAudio;
    private bool fadeOut;
    private bool fadeIn;
    private float vol = 0.0f;
    void Start()
    {
        spinning = true;
        spinAudio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        //if (spinning == true)
        //{
        if (Input.GetMouseButtonDown(0))
        {
            clickedPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            spinAudio.Play();
        }
        if (Input.GetMouseButton(0))
        {
            movedPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            Vector3 difference = movedPosition - clickedPosition;
            transform.Rotate(new Vector3(difference.y * speed, -(difference.x * speed), 0), Space.World);


        }

        if (Input.GetMouseButtonUp(0))
        {
            spinAudio.Stop();
        }
        //}
    }

    //void FixedUpdate()
    //{
    //    if (fadeIn)
    //    {
    //        if (vol < 1f)
    //        {
    //            fadeOut = false;
    //            vol += 0.2f;
    //        }
    //    }

    //    if(fadeOut)
    //    {
    //        if(vol > 0f)
    //        {
    //            fadeIn = false;
    //            vol -= 0.2f;
    //        }
    //    }
    //}
}
