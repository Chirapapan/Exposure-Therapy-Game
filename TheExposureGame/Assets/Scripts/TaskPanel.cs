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

    public void SetDescription(City inputCityScript)
    {
        taskDescription.text = PlayerPrefs.GetString("Exercise" + inputCityScript.exerciseNumber);
    }
}
