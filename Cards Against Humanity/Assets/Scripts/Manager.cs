using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using System.Linq;

public class Manager : MonoBehaviour
{
    public int numOfPlayers;
    public Button[] selected = new Button[1];
    public Button[] buttons = new Button[10];
    public Button[] placed;
    public Button[] card_slots = new Button[6];
    private int delete;
    

    public void Start(){
        placed = new Button[numOfPlayers];

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<TMP_Text>().text = UnityEngine.Random.Range(0, 10).ToString();
        }
    }

    public void checkPressed()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].GetComponent<GameButtonsManager>().pressed)
            {
                selected[0] = buttons[i];
                break;
            }
        }
    }

    public void checkConfirmed()
    {
        for (int i = 0; i < placed.Length; i++){
            if ((placed[i] == null) && !placed.Contains(selected[0]))
            {
                placed[i] = selected[0];
                selected[0].interactable = false;
                break;
            }
        }
    }

    public void placeCards(){
        for (int i=  0; i < placed.Length; i ++){
            card_slots[i].GetComponent<Image>().color = Color.white;
            card_slots[i].GetComponentInChildren<TMP_Text>().text = placed[i].GetComponentInChildren<TMP_Text>().text;
            placed[i].interactable = true;
        }
    }


    public void Update()
    {
        if (placed[placed.Length - 1] != null){
            placeCards();
            Array.Clear(placed, 0, placed.Length);
        }

    }

}
