using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public SavePlayerInput saveInput;

    public PanelManager panelManagerScript;
    public Panel continentPanelObj;
    public Image mapSprite;
    public Image rewardSprite;
    public Text continentText;

    void Awake()
    {

    }

    public void GetContinentMap(string name, Sprite continent, Sprite reward)
    {
        mapSprite.sprite = continent;
        rewardSprite.sprite = reward;
        continentText.text = name;
    }

    public void ActivateMap()
    {
        panelManagerScript.Option(continentPanelObj);
    }

    public void SaveInput()
    {
        saveInput.fear01 = saveInput.input01.text;
        saveInput.fear02 = saveInput.input02.text;
        saveInput.fear03 = saveInput.input03.text;
        saveInput.fear04 = saveInput.input05.text;
        saveInput.fear05 = saveInput.input05.text;
        saveInput.fear06 = saveInput.input06.text;
        saveInput.fear07 = saveInput.input07.text;
        saveInput.fear08 = saveInput.input08.text;
        saveInput.fear09 = saveInput.input09.text;
        saveInput.fear10 = saveInput.input10.text;

    }

	public void OpenGlobeScene()
	{
		SceneManager.LoadScene("Globe");
	}

    public void OpenStart()
    {
        SceneManager.LoadScene("TheExposure");
    }
}
