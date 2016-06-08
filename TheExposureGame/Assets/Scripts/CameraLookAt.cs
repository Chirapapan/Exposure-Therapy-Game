using UnityEngine;
using System.Collections;

public class CameraLookAt : MonoBehaviour
{

    Transform camera;
    public Transform target;
    public float speed;
    private float zoomSpeed = 10;
    public float x;
    public float y;
    public float z;
    public bool zoomingIn;

    //Private Vars
    private Vector3 mousePosition;
    private float delay = 0.25f;
    private bool oneClick;
    private bool rotating;
    private float timer;
    private Quaternion currentRotation;
    private Quaternion newRotation;

    private float privateTimer;
    private bool privateTimerCheck;
   public ParticleSystem cloud;

    void Start()
    {
        camera = Camera.main.GetComponent<Transform>();
        //cloud = ParticleSystem.FindObjectOfType<ParticleSystem>();
    }
    void Update()
    {
        if (rotating == true)
        {
            if (privateTimerCheck == false)
            {
                 privateTimer = Time.time;
                privateTimerCheck = true;
            }
            target.rotation = Quaternion.Lerp(target.rotation, Quaternion.Euler(x, y, z), Time.deltaTime * speed);
            if ((Time.time - privateTimer) > 2 || target.rotation == Quaternion.Euler(x, y, z))
            {
                zoomingIn = true;
                rotating = false;
                privateTimerCheck = false;
                cloud.Play();

            }

        }

        if(zoomingIn == true)
        {
            camera.transform.Translate(Vector3.forward* 2.5f * Time.deltaTime);
            if (camera.transform.position.z > -5)
            {
                zoomingIn = false;
               
            }
        }
        
        if (oneClick == true)
        {
            if ((Time.time - timer) > delay)
            {
                oneClick = false;
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (oneClick == false)
            {
                oneClick = true;
                timer = Time.time;
                currentRotation = target.rotation;
            }
            else
            {
               
                rotating = true;
            }

        }
    }
}
    
