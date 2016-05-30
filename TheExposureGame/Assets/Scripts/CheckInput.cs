using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CheckInput : MonoBehaviour
{

    public Text numberOfExercise;
    public bool playerInput = false;
    public GameObject inputNumber;
    public GameObject inputText;
    public Button myButton;
    public int exerciseCount = 4;
    public GameObject fearStates;
    public Transform fearField;
    public string Week;
    public string NumberOfExercise;

    private List<GameObject> inputFields = new List<GameObject>();
    private GameObject fearState;
    int x = 135;
    int y = 135;

    void OnEnable()
    {
        //playerInput = true;
    }

    public void IncreaseNumber()
    {
        if (exerciseCount < 10)
        {
            exerciseCount++;
            numberOfExercise.text = "" + exerciseCount;
        }
    }

    public void DecreaseNumber()
    {
        if (exerciseCount > 4)
        {
            exerciseCount--;
            numberOfExercise.text = "" + exerciseCount;
        }
    }

    //public void InputTextToTrue()
    //{

    //        inputNumber.SetActive(false);
    //        inputText.SetActive(true);

    //}

    public void InitExercises()
    {
        inputText.SetActive(true);
        inputNumber.SetActive(false);
        for (int i = 0; i < exerciseCount; i++)
        {
            fearState = (GameObject)Instantiate(fearStates);
            fearState.transform.SetParent(fearField, false);
            RectTransform rect = fearState.GetComponent<RectTransform>();
            rect.localPosition = new Vector3(x, y, 0);
            y = y - 60;
            int counter = i + 1;
            InputField number = fearState.GetComponent<InputField>();
            number.text = "What is your fear number " + counter + " ?";

            inputFields.Add(fearState);
        }

    }

    public void SaveInput()
    {
        PlayerPrefs.SetInt(NumberOfExercise, exerciseCount);
        for (int i = 0; i < inputFields.Count; i++)
        {
            PlayerPrefs.SetString(Week, inputFields[i].GetComponent<Text>().text);
        }
        
    }
}
