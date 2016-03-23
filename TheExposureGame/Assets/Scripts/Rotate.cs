using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			transform.Rotate(new Vector3(0,30,0));
		}
	}
}
