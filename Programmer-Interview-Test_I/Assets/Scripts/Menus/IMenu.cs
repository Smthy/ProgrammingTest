using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMenu : MonoBehaviour
{
    public GameObject panel;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    public virtual void Show()
    {
        panel.SetActive(true);
    }

    public virtual void Hide()
    {
        panel.SetActive(false);
    }
}
