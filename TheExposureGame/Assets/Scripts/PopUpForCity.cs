using UnityEngine;
using System.Collections;

public class PopUpForCity : MonoBehaviour
{
    public PanelManager panelManagerScript;

    private Panel mapPanel;

    public void SetCityMap(Panel theCityMap)
    {
        mapPanel = theCityMap;
    }

    public void ActivateCityMap()
    {
        panelManagerScript.Option(mapPanel);
    }

}
