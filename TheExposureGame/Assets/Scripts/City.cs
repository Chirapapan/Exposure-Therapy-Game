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

    void Start()
    {
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

    void OnPress()
    {

    }
}
