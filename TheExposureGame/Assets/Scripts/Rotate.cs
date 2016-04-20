using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    Vector3 clickedPosition;
    Vector3 movedPosition;
    public float speed = 1.0f;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButton(0))
        {
            movedPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            Vector3 difference = movedPosition - clickedPosition ;
            transform.Rotate(new Vector3(difference.y * speed,-(difference.x*speed),0),Space.World);
            
                
        }
    }
}
