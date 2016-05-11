using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpObjectPanel : MonoBehaviour {

    public SavePlayerInput saveInput;
    public GameObject popUp_objectivePrefab;
    public Panel cityMap;
    Text objectiveText;

    public float offset = 0.33f;

    private bool isLocked = true;

    private PopUpForCity popUpForCityScript;

    void Start()
    {
        CanvasGroup thisGroup = cityMap.GetComponent<CanvasGroup>();
        thisGroup.alpha = 0;
        popUp_objectivePrefab.SetActive(false);
        objectiveText = popUp_objectivePrefab.GetComponent<Text>();
        popUpForCityScript = popUp_objectivePrefab.GetComponent<PopUpForCity>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //objectiveText.text = saveInput.fear01;
            popUp_objectivePrefab.SetActive(true);
            popUp_objectivePrefab.transform.position = new Vector3(Mathf.Clamp( transform.position.x, -offset, offset), transform.position.y, popUp_objectivePrefab.transform.position.z);
            popUpForCityScript.SetCityMap(cityMap);
        }
    }

}
