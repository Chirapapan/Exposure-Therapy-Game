using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This Script is for every city
public class City : MonoBehaviour
{
    public int planetNum;
    public int continentNum;
    public int cityNum;

    private int lastPlanet;
    private int lastContinent;
    private int lastExercise;

    private int amountOfExercises;

    public bool isLocked = true;

    public Planet planetScript;
    private PanelManager panelMangerScript;
    private TaskPanel taskPanelScript;
    private Continent continentScript;

    public Image statusImage;

    void Start()
    {
        panelMangerScript = planetScript.Canvas.GetComponent<PanelManager>();
        taskPanelScript = planetScript.taskPanel.GetComponent<TaskPanel>();

        statusImage = transform.GetChild(0).GetComponent<Image>();

        lastPlanet = PlayerPrefs.GetInt("LastPlanet");
        lastContinent = PlayerPrefs.GetInt("LastContinent");

        amountOfExercises = PlayerPrefs.GetInt("Amount" + planetNum + "-" + continentNum);
    }

    /// <summary>
    /// checks if the cities should be closed or not
    /// </summary>
    public void CheckLock()
    {
        lastExercise = PlayerPrefs.GetInt("lastExercise");
        if (cityNum == 0 && isLocked == true)
        {
            isLocked = false;
            Debug.Log(cityNum + "City is 0");
        }
        if (lastPlanet == planetNum && isLocked == true && lastPlanet != 0)
        {
            isLocked = false;
            Debug.Log(cityNum + "Last planet is this planet");
        }

        if (lastContinent >  continentNum && isLocked == true && lastContinent != 0)
        {
            isLocked = false;
            Debug.Log(cityNum + "last continent is this continent");
        }

        if (lastExercise >= cityNum && isLocked == true)
        {
            isLocked = false;
            Debug.Log(cityNum + "last exerecise is this city" + this.name);
        }

        if(isLocked == true)
        {
            statusImage.sprite = planetScript.lockedSprite;
        }
        else if(isLocked == false)
        {
            if (lastExercise == cityNum && lastContinent == continentNum)
            {
                Debug.Log("HEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEELP");
                statusImage.sprite = planetScript.unLockedSprite;
            }
            else if(lastExercise == 0 && lastContinent > continentNum)
            {
                statusImage.sprite = planetScript.finishedSprite;
            }
            else
            {
                statusImage.sprite = planetScript.finishedSprite;
            }
            
        }
    }
    
    public void OnPress()
    {
        if (isLocked == false)
        {
            panelMangerScript.OverlayOption(planetScript.taskPanel);
            taskPanelScript.SetDescription(planetNum, continentNum, cityNum);
            planetScript.doneButton.onClick.AddListener(() => FinishExercise());
        }
    }

    void FinishExercise()
    {
        PlayerPrefs.SetInt("LastPlanet", planetNum);
        PlayerPrefs.SetInt("LastContinent", continentNum);
        PlayerPrefs.SetInt("lastExercise", cityNum + 1);
        continentScript.CheckLockAllCities();
        if(cityNum == (amountOfExercises -1))
        {
            PlayerPrefs.SetInt("lastExercise", 0);
            PlayerPrefs.SetInt("LastContinent", continentNum + 1);
            Debug.Log("DONE WITH WEEK " + continentNum);
        }
    }

    public void SetContinentReference(Continent continent)
    {
        continentScript = continent;
    }
}
