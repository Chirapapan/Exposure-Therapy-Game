using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public SavePlayerInput saveInput;

    public PanelManager panelManagerScript;
    public Panel continentPanelObj;
    public Image mapSprite;
    public Image rewardSprite;
    public Text continentText;
    public GameObject taskPopUp;
    public int ExerciseCount = 4;
    public GameObject fearStates;
    public Transform FearField;
    public GameObject inputNumber;
    public GameObject inputText;
    public GameObject exercise;
    public GameObject exerciseField;

    private List<GameObject> inputFields = new List<GameObject>();

    private Text numberOfExcercise;
    private GameObject fearState;
    int x = 135;
    int y = 135;

    void Start()
    {
       
    }

    public void IncreaseNumber()
    {
        numberOfExcercise = GameObject.Find("NumberOfExercises").GetComponent<Text>();
        if (ExerciseCount < 10)
        {
            ExerciseCount++;
            numberOfExcercise.text = "" + ExerciseCount;
        }
    }

    public void DecreaseNumber()
    {
        numberOfExcercise = GameObject.Find("NumberOfExercises").GetComponent<Text>();
        if (ExerciseCount > 4)
        {
            ExerciseCount--;
            numberOfExcercise.text = "" + ExerciseCount;
        }
    }

    public void InitExercises()
    {
        inputText.SetActive(true);
        for (int i = 0; i < ExerciseCount; i++)
        {
            fearState = (GameObject)Instantiate(fearStates);
            fearState.transform.SetParent(FearField, false);
            RectTransform rect = fearState.GetComponent<RectTransform>();
            rect.localPosition = new Vector3(x, y, 0);
            y = y - 60;
            int counter = i + 1;
            InputField number = fearState.GetComponent<InputField>();
            number.text = "What is your fear number " + counter + " ?";

            inputFields.Add(fearState);
        }

        inputNumber.SetActive(false);
  
    }

    public void InputNumberToTrue()
    {
        inputNumber.SetActive(true);
        inputText.SetActive(false);
    }

    public void GetContinentMap(string name, Sprite continent, Sprite reward)
    {
        mapSprite.sprite = continent;
        rewardSprite.sprite = reward;
        continentText.text = name;
    }

    public void InitText()
    {
        int y = -60;
        for (int i = 0; i < ExerciseCount; i++)
        {
            GameObject fear = (GameObject)Instantiate(exercise);
            fear.transform.SetParent(exerciseField.transform, false);
            fear.GetComponent<RectTransform>().localPosition = new Vector3(-10, y, 0);
            y = y - 50;
            fear.GetComponent<Text>().text = PlayerPrefs.GetString("Exercise" + i);
            
        }
    }

    public void ActivateMap()
    {
        panelManagerScript.Option(continentPanelObj);
    }

    public void SaveInput()
    {
        for(int i = 0; i < inputFields.Count; i++)
        {
            PlayerPrefs.SetString("Exercise" + i,  inputFields[i].GetComponent<Text>().text);
            Debug.Log(PlayerPrefs.GetString("Exercise" + i));
        }

    }

    public void Close()
    {
        taskPopUp.SetActive(false);

    }

	public void OpenGlobeScene()
	{
		SceneManager.LoadScene("Globe");
	}

    public void OpenStart()
    {
        SceneManager.LoadScene("TheExposure");
    }
}
