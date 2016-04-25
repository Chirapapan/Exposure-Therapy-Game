using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpObjectPanel : MonoBehaviour {

    public SavePlayerInput saveInput;
    public GameObject popUp_objectivePrefab;
    GameManager gameManager;
    Text objectiveText;
    Continent continentScript;
    public float offset;

    void Start()
    {
        popUp_objectivePrefab.SetActive(false);
        objectiveText = popUp_objectivePrefab.GetComponent<Text>();
        continentScript = GetComponent<Continent>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //objectiveText.text = saveInput.fear01;
            popUp_objectivePrefab.SetActive(true);
            popUp_objectivePrefab.transform.position = new Vector3(Mathf.Clamp( transform.position.x, -offset, offset), transform.position.y, popUp_objectivePrefab.transform.position.z);
            gameManager.GetContinentMap(continentScript.continentName, continentScript.continentSprite, continentScript.rewardSprite);
        }
    }

    //void Update()
    //{
    //    if (popUp_objectivePrefab.transform.position.x < -0.5)
    //        popUp_objectivePrefab.transform.position = new Vector3(-0.5f, popUp_objectivePrefab.transform.position.y, popUp_objectivePrefab.transform.position.z);

    //    if (popUp_objectivePrefab.transform.position.x > 0.5)
    //        popUp_objectivePrefab.transform.position = new Vector3(0.5f, popUp_objectivePrefab.transform.position.y, popUp_objectivePrefab.transform.position.z);

    //}

    //void OnMouseExit()
    // {
    // popUp_objectivePrefab.SetActive(false);
    // }

}
