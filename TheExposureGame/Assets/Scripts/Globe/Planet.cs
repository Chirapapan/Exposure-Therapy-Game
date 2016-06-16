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

    public Continent[] continents;

    public GameObject backgroundSea;

    public Sprite lockedSprite;
    public Sprite unLockedSprite;
    public Sprite finishedSprite;
    public GameObject continentCanvas;

    void Start()
    {
        continentCanvas.SetActive(false);
    }
   
    public void CheckLockContinents()
    {
        for(int i = 0; i < continents.Length; i++)
        {
            continents[i].CheckLock();
        }
    }

    public void RemoveListenersOnButton()
    {
        doneButton.onClick.RemoveAllListeners();
    }

    public void TurnOnSea()
    {
        backgroundSea.SetActive(true);
    }

}
