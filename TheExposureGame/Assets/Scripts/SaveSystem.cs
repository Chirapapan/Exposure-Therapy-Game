using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SaveSystem : MonoBehaviour
{
    public GameObject weeks;                                        //weeks prefab - not used
    public Transform content;                                       //scrollrectcontent - not used

    public GameObject fearStatesInputField;                         //GameObject prefab to spawn new inputfields
    public Transform fearFieldHolder;                               //GameObject holds all the fear input fields
    public Transform holder;

    public GameObject inputNumberPanel;                             //GameObject input number panel
    public GameObject inputTextPanel;                               //GameObject input text panel

    public Text numberOfExcercise;                                  //text for number of exercises
    public int exerciseCount = 4;                                   //keeps track of how many exercises

    private List<GameObject> inputFields = new List<GameObject>();  //List of all the imputfields

    private int weekX = 60;
    private int WeekY = -50;
    
    private List<int> ListOfWeek = new List<int>();
    
    private int planetNum;                                          //info for a week set by pressing a week in WeekInfo class                     
    private int weekNum;                                            //info for a week set by pressing a week in WeekInfo class
    private bool filled;                                            //info for a week set by pressing a week in WeekInfo class

    void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    /// <summary>
    /// Increase the number of the amount of exercises
    /// </summary>
    public void IncreaseNumber()
    {
        if (exerciseCount < 10)
        {
            exerciseCount++;
            numberOfExcercise.text = exerciseCount.ToString();
        }
    }

    /// <summary>
    /// Decrease the number for the amount of exercises
    /// </summary>
    public void DecreaseNumber()
    {
        if (exerciseCount > 4)
        {
            exerciseCount--;
            numberOfExcercise.text = exerciseCount.ToString();
        }
    }

    /// <summary>
    /// Creates the exercise input fields
    /// </summary>
    public void InitExercises()
    {
        RectTransform holderRect = fearFieldHolder.GetComponent<RectTransform>();
        float x = holderRect.position.x;
        float y = holderRect.position.y;
        float height = holderRect.sizeDelta.y;
        inputTextPanel.SetActive(true);
        inputNumberPanel.SetActive(false);

        int repeat = 0;

        if(filled == false)
        {
            repeat = exerciseCount;
        }
        else if(filled == true)
        {
            repeat = PlayerPrefs.GetInt("Amount" + planetNum + "-" + weekNum);
        }
        for (int i = 0; i < repeat; i++)
        {
            GameObject fearState = (GameObject)Instantiate(fearStatesInputField);
            RectTransform rect = fearState.GetComponent<RectTransform>();
            rect.position = new Vector3(x, y, 0);
            y -= height;
            int counter = i + 1;
            fearState.transform.SetParent(holder, false);
            InputField number = fearState.GetComponent<InputField>();

            if (filled == false)
            {
                number.text = "What is your exercise " + counter + "?";
            }
            else if(filled == true)
            {
                number.text = PlayerPrefs.GetString("Exercise" + planetNum + "-" + weekNum + "-" + i);
            }

            inputFields.Add(fearState);
        }

    }

    /// <summary>
    /// Half completed, creates new weeks
    /// </summary>
    public void InitWeek()
    {
        int weekCount = 0;
        for (int i = 0; i < ListOfWeek.Count; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject week = (GameObject)Instantiate(weeks);
                //week.transform.SetParent(content, false);
                RectTransform rect = week.GetComponent<RectTransform>();
                rect.localPosition = new Vector3(weekX, WeekY, 0);
                weekCount++;
                week.GetComponentInChildren<Text>().text = "Week" + "" + weekCount;
                weekX = weekX + 100;
                if (j == 3)
                {
                    weekX = 60;
                    WeekY = WeekY - 100;
                }
            }
        }
    }

    public void CheckHasSave()
    {
        if(filled == false)
        {
            inputNumberPanel.SetActive(true);
            inputTextPanel.SetActive(false);
        }
        else
        {
            inputNumberPanel.SetActive(false);
            inputTextPanel.SetActive(true);
            InitExercises();

        }
    }

    /// <summary>
    /// Saves all the player field in text fields
    /// </summary>
    public void SaveInput()
    {
        for (int i = 0; i < inputFields.Count; i++)
        {
            PlayerPrefs.SetString("Exercise" + planetNum + "-" + weekNum + "-" + i , inputFields[i].GetComponent<Text>().text);
        }
        PlayerPrefs.SetInt("Amount" + planetNum + "-" + weekNum, inputFields.Count);
        OnBack();
    }

    public void OnBack()
    {
        for (int j = 0; j < inputFields.Count; j++)
        {
            Destroy(inputFields[j]);
        }
        inputFields.Clear();
    }

    /*
    private void GetPlayerPrefsIntoList()
    {
        ListOfWeek.Clear();
        for (int i = 0; i < numberOfSave; i++)
        {
            ListOfWeek.Add(PlayerPrefs.GetInt("ExerciseSaveWeek" + i));
        }
    }*/


    /// <summary>
    /// Set the information in SaveSystem class
    /// </summary>
    public void SetWeekInfo(int planetNumber, int weekNumber, bool filledIn)
    {
        planetNum = planetNumber;
        weekNum = weekNumber;
        filled = filledIn;
        CheckHasSave();
    }
}
