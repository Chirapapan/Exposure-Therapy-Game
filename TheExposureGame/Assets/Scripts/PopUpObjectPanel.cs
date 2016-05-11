using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpObjectPanel : MonoBehaviour {

    public SavePlayerInput saveInput;
    public Panel popUp_objectivePrefab;
    GameManager gameManager;
    //Text objectiveText;
    public float offset = 0.33f;
    public Panel cityPanel;
    private PopUpPanel popUpPanelScript;
    public PanelManager panelManagerScript;

    void Start()
    {
        panelManagerScript.CloseOption(popUp_objectivePrefab);
        //objectiveText = popUp_objectivePrefab.GetComponent<Text>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        popUpPanelScript = popUp_objectivePrefab.GetComponent<PopUpPanel>();
    }

    void OnMouseOver()
    {
        if (PopUpPanel.MAP_OPEN == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (popUp_objectivePrefab.GetComponent<CanvasGroup>().alpha == 0)
                {
                    //objectiveText.text = saveInput.fear01;
                    panelManagerScript.Option(popUp_objectivePrefab);
                    popUp_objectivePrefab.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -offset, offset), transform.position.y, popUp_objectivePrefab.transform.position.z);
                    popUpPanelScript.SetCity(cityPanel);
                }
            }
        }
    }
}
