using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerCardManager : MonoBehaviour
{
    public GameObject manager;
    public Button self;
    public bool pressed;
    public Button[] selected;

    private ArrayList buttons = new ArrayList();


    public void BtnOnClick()
    {
        pressed = true;
        
    }

    public void Update()
    {
        selected = manager.GetComponent<Manager>().selected;
        pressed = false;

    }

    public bool isInArrayList(ArrayList arr, string name)
    {
        for (int i = 0; i < arr.Count; i++)
        {
            if (name == (string)arr[i])
                return true;
        }
        return false;
    }
}
