using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectScript : MonoBehaviour {

    private Animator slidingIn;

    public bool isOpen;
    public Image objective;
    public Text objectiveName;

	// Use this for initialization
	void Start () {
        slidingIn = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    public void ChangeImage(Sprite obj, string name)
    {
        objective.sprite = obj;
        objectiveName.text = name;
    }

    public void OnClickArrow()
    {
        if(!isOpen)
        {
            slidingIn.Play("SlidingPanel");
            isOpen = true;
        }
        else
        {
            slidingIn.Play("SlidingPanelBack");
            isOpen = false;

        }
        
    }
}
