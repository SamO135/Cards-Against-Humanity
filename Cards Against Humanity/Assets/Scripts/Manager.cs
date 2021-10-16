using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Button[] selected = new Button[1];
    public Button[] buttons = new Button[10];
    

    public void checkPressed()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].GetComponent<PlayerCardManager>().pressed)
            {
                selected[0] = buttons[i];
                break;
            }
        }
    }

    public void checkConfirmed()
    {
        selected[0].interactable = false;
    }


    public void Update()
    {
        

    }

}
