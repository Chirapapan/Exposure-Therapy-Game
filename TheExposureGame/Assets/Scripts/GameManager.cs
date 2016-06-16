using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public Sprite[] storyBoards;
    public Image story;
    private int currentSpriteNum;
    private GameObject currentObject;

    private Vector3 cameraStartPos;
    public GameObject backgroundSea;

    void Start()
    {
        cameraStartPos = Camera.main.transform.position;
        ShowPlayerprefs();
    }
    public void NextStorySprite()
    {
        if (currentSpriteNum < storyBoards.Length - 1)
        {
            Debug.Log("current < storyboard");
            currentSpriteNum++;
            story.sprite = storyBoards[currentSpriteNum];
        }

        else 
        {
            Debug.Log("current == storyboard");
            SceneManager.LoadScene("TheExposure");
        }
    }

	public void OpenGlobeScene()
	{
		SceneManager.LoadScene("Globe");
	}

    public void OpenStart()
    {
        SceneManager.LoadScene("TheExposure");
    }

    public void EnableGameObject(GameObject obj)
    {
        currentObject = obj;
        currentObject.SetActive(true);
    }

    public void Back()
    {
        Camera.main.transform.position = cameraStartPos;
        TurnOffSea();
        //currentObject.GetComponent
    }

    public void TurnOffSea()
    {
        backgroundSea.SetActive(false);
    }

    /// <summary>
    /// resets all the players player prefs of the game very dangerous
    /// </summary>
    public void ResetAllPlayerprefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void ShowPlayerprefs()
    {
        Debug.Log( PlayerPrefs.GetInt("LastPlanet"));
        Debug.Log(PlayerPrefs.GetInt("LastContinent"));
        Debug.Log(PlayerPrefs.GetInt("lastExercise"));
    }
}
