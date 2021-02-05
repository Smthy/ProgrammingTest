using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Manager { get; private set; }

    public MenuPause menuPause;
    public MenuHUD menuHud;
    public MenuDeath menuDeath;

    public Stack<IMenu> menuStack = new Stack<IMenu>();


    #region UNITY EVENTS
    private void Awake()
    {
        Manager = this;
    }

    private void Start()
    {
        menuStack.Push(menuHud);
        menuStack.Peek().Show();
    }
    #endregion

    #region MENU DISPLAY FUNCTIONS
    public void DisplayPauseMenu()
    {
        GameData.paused = true;
        PushMenu(menuPause);
    }

    public void DisplayDeathMenu()
    {
        GameData.paused = true;
        PushMenu(menuDeath);
    }
    #endregion

    #region MENU STACK STUFF
    public void PushMenu(IMenu _menu, bool _andShow = true)
    {
        menuStack.Push(_menu);

        if (_andShow)
        {
            menuStack.Peek().Show();
        }
    }

    public void PopMenu(bool _showNextMenu = true)
    {
        if (menuStack.Count > 0)
        {
            menuStack.Pop().Hide();
        }

        if (menuStack.Count > 0 && _showNextMenu)
        {
            menuStack.Peek().Show();
        }
    }

    public void ClearToHUD()
    {
        if (menuStack.Count > 0)
        {
            menuStack.Peek().Hide();
        }

        menuStack.Clear();

        menuStack.Push(menuHud);
        menuHud.Show();
        GameData.paused = false;
    }
    #endregion
}
