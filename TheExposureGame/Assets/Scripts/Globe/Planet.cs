using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    public Panel taskPanel;
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

    public void OnBack()
    {
        doneButton.onClick.RemoveAllListeners();
    }
}
