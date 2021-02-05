using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuDeath : IMenu
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private Button restartButton;


    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    public override void Show()
    {
        base.Show();

        scoreText.text = "Score: " + GameData.timeBeingChased.ToString("N0");
    }

    public override void Hide()
    {
        base.Hide();
    }

    private void RestartGame()
    {
        MenuManager.Manager.ClearToHUD();
        GameController.Instance.RestartGame();
    }
}
