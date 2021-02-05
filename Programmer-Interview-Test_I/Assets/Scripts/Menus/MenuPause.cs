using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPause : IMenu
{
    [SerializeField] private Button resumeButton;


    // Start is called before the first frame update
    private void Start()
    {
        resumeButton.onClick.AddListener(Show);
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }

    private void ResumeGameOnClick()
    {
        MenuManager.Manager.ClearToHUD();
    }
}
