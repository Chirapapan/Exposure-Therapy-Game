using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameObject panelManagerObj;
    public Panel continentPanelObj;
    public Image mapSprite;
    public Image rewardSprite;
    public Text continentText;

    private PanelManager panelManagerScript;
    

    void Awake()
    {
        panelManagerScript = panelManagerObj.GetComponent<PanelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 8))
            {
                if (hit.collider.tag == "Continent")
                {
                    Continent hitContinent = hit.transform.gameObject.GetComponent<Continent>();
                    mapSprite.sprite = hitContinent.continentSprite;
                    rewardSprite.sprite = hitContinent.rewardSprite;
                    continentText.text = hitContinent.continentName;
                    panelManagerScript.Option(continentPanelObj);
                }
            }
        }
    }
}
