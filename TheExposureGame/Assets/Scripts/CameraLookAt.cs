using UnityEngine;
using UnityEngine.UI;
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
    public ParticleSystem cloud;
    public Panel continent;
    public Sprite continentImage;

    //Private Vars
    private Vector3 mousePosition;
    private float delay = 0.25f;
    private bool oneClick;
    private bool rotating;
    private float timer;
    private Quaternion currentRotation;
    private Quaternion newRotation;
    private bool zoomingIn;
    private float privateTimer;
    private bool privateTimerCheck;
    private Rotate rotate;
    private AudioSource zoomInAudio;
    private Continent continentScript;

    private Vector3 cameraStartPos;

    void Start()
    {
        camera = Camera.main.GetComponent<Transform>();
        cameraStartPos = camera.position;
        rotate = GetComponent<Rotate>();
        zoomInAudio = gameObject.GetComponent<AudioSource>();
        //cloud = ParticleSystem.FindObjectOfType<ParticleSystem>();

        continentScript = transform.GetComponent<Continent>();
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
            zoomInAudio.Play();
            camera.transform.Translate(Vector3.forward* 2.5f * Time.deltaTime);
           
            if (camera.transform.position.z > -5)
            {
                zoomingIn = false;
                //zoomInAudio.Stop();
                //rotate.spinning = true;
                continentScript.GoToLevel();
                cloud.Clear(); //has to be replaced to be slowly fade out, preferbly from the center
                cloud.Stop();
                camera.transform.position = cameraStartPos;
                transform.root.gameObject.SetActive(false);
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
            else if(oneClick == true && continentScript.isLocked == false)
            {
                rotating = true;
                //rotate.spinning = false;
            }

        }
    }
}
    
