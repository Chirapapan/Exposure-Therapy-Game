using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SavePlayerInput : MonoBehaviour {

	string playerNewInput;

	public void OnChange(string newInput)
	{
		playerNewInput = newInput;
		Debug.Log (playerNewInput);
	}
}
