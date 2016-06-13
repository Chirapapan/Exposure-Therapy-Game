using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This Script is for every planet
public class Planet : MonoBehaviour
{
    public Panel taskPanel;
    public PanelManager Canvas;
    public Button doneButton;

    public int planetNum;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RemoveListenersOnButton()
    {
        doneButton.onClick.RemoveAllListeners();
    }
}
