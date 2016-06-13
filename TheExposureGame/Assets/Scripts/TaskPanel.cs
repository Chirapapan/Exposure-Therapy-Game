using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TaskPanel : MonoBehaviour
{

    public Text taskDescription;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDescription(int planetNum, int weekNum, int cityNum)
    {
        taskDescription.text = PlayerPrefs.GetString("Exercise" + planetNum + "-" + weekNum + "-" + cityNum);
    }
}
