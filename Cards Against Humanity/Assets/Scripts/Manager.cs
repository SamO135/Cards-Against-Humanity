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
    public Button[] playerCards = new Button[10];
    public Button[] placed;
    public Button[] card_slots = new Button[6];
    private String phase = "submitting";
    

    public void Start(){
        placed = new Button[numOfPlayers];

        for (int i = 0; i < playerCards.Length; i++)
        {
            playerCards[i].GetComponentInChildren<TMP_Text>().text = UnityEngine.Random.Range(0, 10).ToString(); // Randomises the text of the player cards to a number between 0 and 10.
        }
    }

    public void checkPressed()
    {
        if (phase == "submitting"){
            for (int i = 0; i < playerCards.Length; i++){
                if (playerCards[i].GetComponent<GameButtonsManager>().isPressed){
                    selected[0] = playerCards[i];
                    break;
                }
            }      
        }
        else if (phase == "selecting"){
            for (int i = 0; i < card_slots.Length; i++){
                if (card_slots[i].GetComponent<GameButtonsManager>().isPressed){
                    selected[0] = card_slots[i];
                    break;
                }
            }
        }
        
    }

    public void checkConfirmed()
    {
        if (phase == "submitting"){
            for (int i = 0; i < placed.Length; i++){
                if ((placed[i] == null) && !placed.Contains(selected[0])){ //If more cards can be placed and the current card has not already been placed.{
                    placed[i] = selected[0];
                    selected[0].interactable = false;
                    card_slots[i].GetComponent<Image>().color = Color.white; // Place card next to the prompt card, but don't show the text until all cards are placed.
                    break;
                }
            }
        }
        else if (phase == "selecting"){
            for (int i = 0; i < card_slots.Length; i++){
                if (selected[0] == card_slots[i]){
                    Debug.Log("The winner was: " + card_slots[i].GetComponentInChildren<TMP_Text>().text);
                    makePhaseOne();
                }
            }
        }
    }

    public void showCards(){ //write the text onto all the cards that were placed down (effectively turning them over if it was irl)
        for (int i = 0; i < placed.Length; i ++){
            card_slots[i].GetComponentInChildren<TMP_Text>().text = placed[i].GetComponentInChildren<TMP_Text>().text; //Move text from selected card to card slot next to prompt card
            for (int x = 0; i < playerCards.Length; x++){ //Loop through all player cards
                if (playerCards[x].name == placed[i].name){ //If the card has been placed down, remove the text from it (and replace it with some new text later on)
                    playerCards[x].GetComponentInChildren<TMP_Text>().text = "";
                    break;
                }
            }
            placed[i].interactable = true;
        }
    }

    public void reshuffleCards(){ //Get rid of the empty spaces in the player cards by shifting the cards down if there's space
        for (int i = 0; i < playerCards.Length; i++)
        {
            if (playerCards[i].GetComponentInChildren<TMP_Text>().text == "")
            {
                for (int x = i; x < playerCards.Length; x++)
                {
                    if (playerCards[x].GetComponentInChildren<TMP_Text>().text != "")
                    {
                        playerCards[i].GetComponentInChildren<TMP_Text>().text = playerCards[x].GetComponentInChildren<TMP_Text>().text;
                        playerCards[x].GetComponentInChildren<TMP_Text>().text = "";
                        break;
                    }
                }

            }
        }
    }

    public void addNewCards(){
        for (int i = playerCards.Length-1; i > 0; i--){
            if (playerCards[i].GetComponentInChildren<TMP_Text>().text == ""){
                playerCards[i].GetComponentInChildren<TMP_Text>().text = UnityEngine.Random.Range(0, 10).ToString();
            }
            else{
                break;
            }
        }
    }

    public void makePhaseTwo(){
        changePlayerCardColour(new Color(1, 1, 1, 0.5f));
        for (int i = 0; i < card_slots.Length; i++){
            if (card_slots[i].GetComponentInChildren<TMP_Text>().text != ""){
                card_slots[i].interactable = true;
                Array.Clear(selected, 0, selected.Length);
            }
            else{
                break;
            }
        }
        phase = "selecting";
    }

    public void makePhaseOne(){
        changePlayerCardColour(new Color(1, 1, 1, 1));
        for (int i = 0; i < playerCards.Length; i++){
            playerCards[i].interactable = true;
        }
        for (int i = 0; i < card_slots.Length; i++){
            card_slots[i].interactable = false;
            card_slots[i].GetComponent<Image>().color = new Color(0.3372549f, 0.3372549f, 0.3372549f, 1);
            card_slots[i].GetComponentInChildren<TMP_Text>().text = "";
        }
        phase = "submitting";
    }

    public void changePlayerCardColour(Color newColour){
        for (int i = 0; i < playerCards.Length; i++){
            playerCards[i].interactable = false;
            var newColorBlock = playerCards[i].GetComponent<Button>().colors;
            newColorBlock.disabledColor = newColour;
            playerCards[i].GetComponent<Button>().colors = newColorBlock;
        }
    }

    public void pickRoundWinner(){
        for (int i = 0; i < card_slots.Length; i++){
            if (card_slots[i].GetComponent<GameButtonsManager>().isPressed){
                selected[0] = card_slots[i];
                break;
            }
        }
    }



    public void Update()
    {
        if (placed[placed.Length - 1] != null){ //If placed array is full (when all players have selected a card to play).
            showCards();
            reshuffleCards();
            addNewCards();
            makePhaseTwo();
            Array.Clear(placed, 0, placed.Length);
        }

    }

}
