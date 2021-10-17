using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButtonsManager : MonoBehaviour
{
    public GameObject manager;
    public Button self;
    public bool isPressed;
    public Button[] selected;


    private ArrayList buttons = new ArrayList();


    public void BtnOnClick()
    {
        isPressed = true;
    }

    public void Update()
    {
        //selected = manager.GetComponent<Manager>().selected;
        isPressed = false;
    }

    /*public bool isInArrayList(ArrayLis    t arr, string name)
    {
        for (int i = 0; i < arr.Count; i++)
        {
            if (name == (string)arr[i])
                return true;
        }
        return false;
    }*/
}
