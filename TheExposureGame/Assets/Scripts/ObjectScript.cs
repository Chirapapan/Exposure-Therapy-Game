using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectScript : MonoBehaviour {

    private Animator slidingIn;

    public bool isOpen;
    public Image objective;
    public Text objectiveName;
    public Text toDo;
    public Button clickToDestroy;
    public GameObject done;

	// Use this for initialization
	void Start () {
        slidingIn = gameObject.GetComponent<Animator>();
        done.SetActive(false);
	}
	



    public void ChangeImage(Sprite obj, string state,string name)
    {
        objective.sprite = obj;
        objectiveName.text = name;
        toDo.text = state;
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
