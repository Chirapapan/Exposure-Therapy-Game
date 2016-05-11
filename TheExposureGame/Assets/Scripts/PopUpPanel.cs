using UnityEngine;
using System.Collections;

public class PopUpPanel : MonoBehaviour {

    public PanelManager panelManagerScript;

    private Panel map;

    public static bool MAP_OPEN = false;

    public void SetCity(Panel theCity)
    {
        map = theCity;
    }

    public void ActivateMap()
    {
        if (MAP_OPEN == false)
        {
            MAP_OPEN = true;
            panelManagerScript.Option(map);
        }
    }

    public void SetMapOpenToFalse()
    {
        MAP_OPEN = false;
    }

}
