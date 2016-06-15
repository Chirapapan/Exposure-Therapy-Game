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
        
    }

    /// <summary>
    /// checks if the cities should be closed or not
    /// </summary>
    public void CheckLock()
    {
        lastExercise = PlayerPrefs.GetInt("lastExercise");
        if (cityNum == 0)
        {
            isLocked = false;
        }
        if (lastPlanet == planetNum && isLocked == true && lastPlanet != 0)
        {
            isLocked = false;
        }

        if (lastContinent == continentNum && isLocked == true && lastContinent != 0)
        {
            isLocked = false;
        }

        if (lastExercise >= cityNum && isLocked == true)
        {
            isLocked = false;
        }

        if(isLocked == true)
        {
            statusImage.sprite = planetScript.lockedSprite;
        }
        else if(isLocked == false)
        {
            if (lastExercise == cityNum)
            {
                statusImage.sprite = planetScript.unLockedSprite;
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
    }

    public void SetContinentReference(Continent continent)
    {
        continentScript = continent;
    }
}
