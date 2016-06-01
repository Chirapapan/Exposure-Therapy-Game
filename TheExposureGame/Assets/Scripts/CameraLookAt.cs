using UnityEngine;
using System.Collections;

public class CameraLookAt : MonoBehaviour
{

    //public Camera camera;
    public Transform target;
    public float speed;
    public float x;
    public float y;
    public float z;

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
            if ((Time.time - privateTimer) > 4 || target.rotation == Quaternion.Euler(x, y, z))
            {
                rotating = false;
                privateTimerCheck = false;
                //currentRotation = Quaternion.Euler(x, y, z);
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
                //Quaternion newRotation = Quaternion.Euler(x, y, z);
                //target.rotation = newRotation;
                //target.eulerAngles = new Vector3(x, y, z);
                rotating = true;
            }

        }
    }
}
    
