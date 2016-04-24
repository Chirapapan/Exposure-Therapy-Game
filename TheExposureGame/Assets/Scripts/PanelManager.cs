using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour
{

    public Panel CurrentOption;
    private CanvasGroup canvasGroupCurrentOption;

    private void Awake()
    {
        //_canvasGroup = GetComponent<CanvasGroup> ();
        canvasGroupCurrentOption = CurrentOption.GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        Option(CurrentOption);
        //_canvasGroup.alpha = 1;
    }

    public void Option(Panel option)
    {
        if (CurrentOption != null)
        {
            CurrentOption.IsOpen = false;
        }

        CurrentOption = option;
        CurrentOption.IsOpen = true;
        canvasGroupCurrentOption.alpha = 1;
    }
}
