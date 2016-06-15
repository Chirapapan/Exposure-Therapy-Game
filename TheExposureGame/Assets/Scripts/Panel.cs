using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour
{

    private CanvasGroup panelOption;
    public bool IsOpen;

    private void Awake()
    {
        panelOption = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (IsOpen == false)
        {
            panelOption.blocksRaycasts = panelOption.interactable = false;
            panelOption.alpha = 0;
        }
        else
        {
            panelOption.alpha = 1;
            panelOption.blocksRaycasts = panelOption.interactable = true;
        }
    }
}
