using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This Script is for every continents on the globe
public class Continent : MonoBehaviour
{
    //values and references set in the inspector
    public int planetNum;
    public int continentNum;
    public Panel levelPanel;
    public float scaleValue = 1.5f;

    public City[] baseCities;
    public City[] otherCities;
    
    private int lastPlanet;
    private int lastContinent;
    private int lastExercise;

    private int amountOfExercises;

    public bool isLocked = true;
    private Light lightSource;
    private ParticleSystem ps;

    private Planet planetScript;
    private PanelManager panelMangerScript;
    public ObjectScript objectScript;
    public Sprite objective;
    public string objectiveName;

    private Vector2 startSize;
    private Vector2 newStartSize;
    private Vector2 size;
   private Animator zoomInPanelAnimator;
    public string animatorName;
    public bool cityClick;

    // Use this for initialization
    void Start()
    {
        startSize = size = levelPanel.GetComponent<RectTransform>().sizeDelta;

        zoomInPanelAnimator = levelPanel.GetComponent<Animator>();

        planetScript = transform.root.GetComponent<Planet>();
        panelMangerScript = planetScript.Canvas.GetComponent<PanelManager>();

        lightSource = transform.GetChild(0).GetComponent<Light>();
        ps = transform.GetChild(1).GetComponent<ParticleSystem>();
     
        lastPlanet = PlayerPrefs.GetInt("LastPlanet");

        amountOfExercises = PlayerPrefs.GetInt("Amount" + planetNum + "-" + continentNum);

        CheckLock();
    }

    /// <summary>
    /// Checks if the Continent should be locked or not
    /// </summary>
    public void CheckLock()
    {
        lastContinent = PlayerPrefs.GetInt("LastContinent");
        lastExercise = PlayerPrefs.GetInt("lastExercise");
        if (continentNum == 0)
        {
            isLocked = false;
        }

        if (lastContinent >= continentNum && amountOfExercises == lastExercise && lastContinent != 0)
        {
            ps.Play();
        }

        if (lastPlanet >= planetNum && isLocked == true && lastPlanet != 0)
        {
            isLocked = false;
        }

        if (lastContinent >= continentNum && isLocked == true)
        {
            isLocked = false;
        }



        if (isLocked == true)
        {
            lightSource.enabled = false;
            ps.Stop();
        }
        else if (isLocked == false)
        {
            lightSource.enabled = true;
            ps.Stop();
        }
        if(lastContinent > continentNum)
        {
            ps.Play();
        }
    }

    /// <summary>
    /// Initializes the base cities
    /// </summary>
    void InitBaseCities()
    {
        for (int i = 0; i < baseCities.Length; i++)
        {
            baseCities[i].planetNum = planetNum;
            baseCities[i].continentNum = continentNum;
            baseCities[i].cityNum = i - 1;
            baseCities[0].cityNum = amountOfExercises - 1;
        }
    }

    /// <summary>
    /// Shows the othercities of the game currently in an order
    /// </summary>
    void ShowOtherCities()
    {
        for(int j = 0; j < otherCities.Length; j++)
        {
            otherCities[j].gameObject.SetActive(false);
        }
        int amount = amountOfExercises -4;
        if(amount > 0)
        {
            for(int i = 0; i < amount; i ++)
            {
                otherCities[i].gameObject.SetActive(true);
                otherCities[i].continentNum = continentNum;
                otherCities[i].planetNum = planetNum;
                otherCities[i].cityNum = i + 3;
            }
        }
    }

    /// <summary>
    /// Call to to show the continent level
    /// </summary>
    public void GoToLevel()
    {
        //ScaleDownPanel();
        planetScript.continentCanvas.SetActive(true);
        planetScript.TurnOnSea();
        InitBaseCities();
        ShowOtherCities();
        CheckLockAllCities();
        panelMangerScript.Option(levelPanel);
        //StartCoroutine(ScaleUpPanel());
        zoomInPanelAnimator.Play("ContinentPanel5_ZoomIn");
       
        objectScript.ChangeImage(objective, objectiveName);
    }

    public void CheckLockAllCities()
    {
        for(int i = 0; i < baseCities.Length; i ++)
        {
            baseCities[i].CheckLock();
            baseCities[i].SetContinentReference(this);
        }
        for(int j = 0; j < otherCities.Length; j ++)
        {
            otherCities[j].CheckLock();
            otherCities[j].SetContinentReference(this);
        }
    }

    public void ScaleDownPanel()
    {
        newStartSize.x = startSize.x / scaleValue;
        newStartSize.y = startSize.y / scaleValue;
        levelPanel.GetComponent<RectTransform>().sizeDelta = newStartSize;
    }
    
}
