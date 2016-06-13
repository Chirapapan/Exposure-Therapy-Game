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

    void Start()
    {
        cameraStartPos = Camera.main.transform.position;
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
        //currentObject.GetComponent
    }
 
}
