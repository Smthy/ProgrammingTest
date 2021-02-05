using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuHUD : IMenu
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI coinsCollectedText;


    // Start is called before the first frame update
    private void Start()
    {

    }

    public override void Show()
    {
        base.Show();

        StartCoroutine(UpdateTimer());
    }

    public override void Hide()
    {
        base.Hide();
    }

    private void PauseOnClick()
    {
        MenuManager.Manager.PopMenu(false);
        MenuManager.Manager.DisplayPauseMenu();
    }

    public void PlayerTurnLeftOnPress()
    {
        GameController.Instance.Player.TurnLeft();
    }

    public void PlayerTurnRightOnPress()
    {
        GameController.Instance.Player.TurnRight();
    }

    public void PlayerStopTurn()
    {
        GameController.Instance.Player.StopTurn();
    }

    private IEnumerator UpdateTimer()
    {
        yield return null;

        while(panel.activeSelf)
        {
            timerText.text = "Time Being Chased: " + GameData.timeBeingChased.ToString("N0");
            yield return new WaitForSeconds(1f);
            GameData.timeBeingChased++;
        }
    }
}
