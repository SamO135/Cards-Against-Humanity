using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCardManager : MonoBehaviour
{
    public Button button1;

    public void BtnOnClick()
    {
        button1.interactable = false;
    }
}
