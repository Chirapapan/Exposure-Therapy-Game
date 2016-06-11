using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This Script is for continents on the globe
public class Continent : MonoBehaviour
{
    public int planetNum;
    public int continentNum;
    public Panel levelPanel;
    public GameObject citiesHolder;

    private List<GameObject> otherCities = new List<GameObject>();

    private int lastPlanet;
    private int lastContinent;
    private int lastExercise;

    private int amountOfExercises;

    private bool isLocked = true;

    private Planet planetScript;

    // Use this for initialization
    void Start()
    {
        planetScript = transform.root.GetComponent<Planet>();
        planetNum = planetScript.planetNum;


        lastPlanet = PlayerPrefs.GetInt("LastPlanet");
        lastContinent = PlayerPrefs.GetInt("LastContinent");
        lastExercise = PlayerPrefs.GetInt("lastExercise");

        amountOfExercises = PlayerPrefs.GetInt("Amount" + planetNum + "-" + continentNum);

        CheckLock();
    }

    /// <summary>
    /// Checks if the planet should be locked or not
    /// </summary>
    void CheckLock()
    {
        if ((lastPlanet - 1) == planetNum && isLocked == true)
        {
            isLocked = false;
            if ((lastContinent - 1) == lastContinent && isLocked == true)
            {
                isLocked = false;
                if ((lastExercise - 1) == lastExercise && isLocked == true)
                {
                    isLocked = false;
                }
            }
        }

        if (isLocked == true)
        {
            //locked
        }
        else if (isLocked == false)
        {
            //unlocked
        }
    }

    void ShowOtherCities()
    {
        amountOfExercises -= 4;
        if(amountOfExercises > 4)
        {
            for(int i = 0; i < amountOfExercises; i ++)
            {
                //otherCities[i];
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //planetScript.levelPanel.GetComponent<sPr>

        }
    }
}
