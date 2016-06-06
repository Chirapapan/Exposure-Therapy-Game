using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeekInfo : MonoBehaviour {

    public int planet;                                        //holds the information for the planetnumber
    public int week;                                          //holds the information for the weeknumber
    
    public void OnWeekPress()
    {
        SaveSystem saveSystem = transform.root.GetComponent<SaveSystem>();

        string pref = PlayerPrefs.GetString("Exercise" + planet + "-" + week + "-" + 0);
        if (pref == "")
        {
            saveSystem.SetWeekInfo(planet, week, false);
        }
        else
        {
            saveSystem.SetWeekInfo(planet, week, true);
        }
        
    }
}
