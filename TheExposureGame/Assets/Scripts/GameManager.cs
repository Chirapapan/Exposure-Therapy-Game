using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public SavePlayerInput saveInput;

    public PanelManager panelManagerScript;
    public Image mapSprite;
    public Image rewardSprite;
    public Text continentText;
    public int exerciseCount = 4;
    public GameObject fearStates;
    public Transform fearField;
    public GameObject inputNumber;
    public GameObject inputText; 
    public GameObject weeks;
    public Transform content;

    private List<GameObject> inputFields = new List<GameObject>();

    private Text numberOfExcercise;
    private int exerciseSaveBool = 0;
    private int numberOfSave = 0;
    private GameObject fearState;
    int x = 135;
    int y = 135;
    private GameObject week;
    int weekX = 60;
    int WeekY = -50;


    private List<int> ListOfWeek = new List<int>();

    void Start()
    {
        numberOfSave = PlayerPrefs.GetInt("NumberOfSave");
    }

    public void IncreaseNumber()
    {
        numberOfExcercise = GameObject.Find("NumberOfExercises").GetComponent<Text>();
        if (exerciseCount < 10)
        {
            exerciseCount++;
            numberOfExcercise.text = "" + exerciseCount;
        }
    }

    public void DecreaseNumber()
    {
        numberOfExcercise = GameObject.Find("NumberOfExercises").GetComponent<Text>();
        if (exerciseCount > 4)
        {
            exerciseCount--;
            numberOfExcercise.text = "" + exerciseCount;
        }
    }

    public void InitExercises()
    {
        inputText.SetActive(true);
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
        inputNumber.SetActive(false);

        int playerPrefNum = PlayerPrefs.GetInt("ExerciseNum");
        if(playerPrefNum == 0)
        {
            playerPrefNum = exerciseCount;
        }
        else
        {
            playerPrefNum = playerPrefNum + exerciseCount;
            PlayerPrefs.SetInt("ExerciseNum", playerPrefNum);
        }
  
    }

    public void InitWeek()
    {
        int weekCount = 0;
        GetPlayerPrefsIntoList();
        for (int i = 0; i < ListOfWeek.Count; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                week = (GameObject)Instantiate(weeks);
                week.transform.SetParent(content, false);
                RectTransform rect = week.GetComponent<RectTransform>();
                rect.localPosition = new Vector3(weekX, WeekY, 0);
                weekCount++;
                week.GetComponentInChildren<Text>().text = "Week" + "" +  weekCount;
                weekX = weekX + 100;
                if(j == 3)
                {
                    weekX = 60;
                    WeekY = WeekY - 100;
                }
            }
        }
    }

    public void InputTextToTrue()
    {
        for (int i = 0; i < ListOfWeek.Count; i++)
        {
            if(numberOfSave == ListOfWeek[i] && exerciseSaveBool == 0)
            {
                //Debug yes 
                inputNumber.SetActive(true);
                inputText.SetActive(false);
            }
            else if(numberOfSave == ListOfWeek[i] && exerciseSaveBool == 1)
            {
                //Debug no 
                inputNumber.SetActive(false);
                inputText.SetActive(true);
            }
        }
    }


    public void SaveInput()
    {
        for(int i = 0; i < inputFields.Count; i++)
        {
            PlayerPrefs.SetString("Exercise" + i,  inputFields[i].GetComponent<Text>().text);
            Debug.Log(PlayerPrefs.GetString("Exercise" + i));
        }
        numberOfSave++;
        PlayerPrefs.SetInt("ExerciseSaveWeek" + numberOfSave++, exerciseSaveBool = 1);
        PlayerPrefs.SetInt("NumberOfSave", numberOfSave);
    }

	public void OpenGlobeScene()
	{
		SceneManager.LoadScene("Globe");
	}

    public void OpenStart()
    {
        SceneManager.LoadScene("TheExposure");
    }

    private void GetPlayerPrefsIntoList()
    {
        ListOfWeek.Clear();
        for (int i = 0; i < numberOfSave; i++)
        {
            ListOfWeek.Add(PlayerPrefs.GetInt("ExerciseSaveWeek" + i));
        }
    }
}
