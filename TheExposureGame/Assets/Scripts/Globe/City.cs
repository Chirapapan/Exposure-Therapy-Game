using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class City : MonoBehaviour
{
    public int planetNum;
    public int continentNum;
    public int cityNum;

    private int lastPlanet;
    private int lastContinent;
    private int lastExercise;

    private bool isLocked = true;
    private GameObject lockChildObj;

    private Planet planetScript;
    private PanelManager panelMangerScript;

    void Start()
    {
        planetScript = transform.root.GetComponent<Planet>();
        panelMangerScript = planetScript.taskPanel.transform.root.GetComponent<PanelManager>();

        lockChildObj = transform.GetChild(0).gameObject;

        lastPlanet = PlayerPrefs.GetInt("LastPlanet");
        lastContinent = PlayerPrefs.GetInt("LastContinent");
        lastExercise = PlayerPrefs.GetInt("lastExercise");

        CheckLock();
    }

    void CheckLock()
    {
        if(cityNum == 0)
        {
            isLocked = false;
            if ((lastPlanet - 1) == planetNum && isLocked == true)
            {
                isLocked = false;
                if((lastContinent - 1) == lastContinent && isLocked == true)
                {
                    isLocked = false;
                    if((lastExercise - 1) == lastExercise && isLocked == true)
                    {
                        isLocked = false;
                    }
                }
            }
        }

        if(isLocked == true)
        {
            lockChildObj.SetActive(true);
        }
        else if(isLocked == false)
        {
            lockChildObj.SetActive(false);
        }
    }
    
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            panelMangerScript.Option(planetScript.taskPanel);
            planetScript.doneButton.onClick.AddListener(() => FinishExercise());
        }
    }

    void FinishExercise()
    {
        PlayerPrefs.SetInt("LastPlanet", planetNum);
        PlayerPrefs.SetInt("LastContinent", continentNum);
        PlayerPrefs.SetInt("lastExercise", cityNum);
    }
}
