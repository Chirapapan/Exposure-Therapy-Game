using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class GameManager : MonoBehaviour {

	string exercise1;

	void Start()
	{
//		var fearState1 = GameObject.Find("FearState1").GetComponent<InputField>();
//		var getInput= new InputField.SubmitEvent();
//		getInput.AddListener(SubmitState);
//		fearState1.onEndEdit = getInput;
	}

	private void SubmitState(string arg0)
	{
		exercise1 = arg0;
	}

	public void SaveInput()
	{
		Debug.Log (exercise1);

	}

	public void OpenGlobeScene()
	{
		Application.LoadLevel ("Globe");
	}
}
