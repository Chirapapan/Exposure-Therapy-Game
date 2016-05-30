using UnityEngine;
using System.Collections;

public class CameraLookAt : MonoBehaviour {

    public float speed;
    Vector3 mousePosition;
    Vector3 playerPosition;
    private float delay = 0.25f;
    private bool oneClick;
    private float timer;
    
    void Start()
    {
        playerPosition = transform.position;

    }

    void Update()
    {
        if(oneClick == true)
        {
            if((Time.time - timer) > delay)
            {
                oneClick = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (oneClick == false)
            {
                oneClick = true;
                timer = Time.time;
            }
            else
            {
                mousePosition = Input.mousePosition;
                Debug.Log(mousePosition);
                if (mousePosition.x < 110)
                {
                    transform.rotation = Quaternion.Euler(0, -90, 0);
                }
                else if (mousePosition.x > 100)
                {
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                }

            }
        }


    }
}
