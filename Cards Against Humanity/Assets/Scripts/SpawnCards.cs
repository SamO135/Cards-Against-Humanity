using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.Events; //For UnityAction
//using UnityEditor.Events; //For UnityEventTools

public class SpawnCards : MonoBehaviour
{
    public GameObject manager;
    public GameObject Parent;
    public Button promptCard;
    public Button cardSlot;
    public int numOfCardSlots = 6;
    public float promptCardX;
    public float promptCardY;
    public float cardSlotX; //x position of the first card slot.
    public float cardSlotY; //y position of the first card slot.

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = new GameObject();
        temp = PhotonNetwork.Instantiate(promptCard.name, new Vector2(promptCardX, promptCardY), Quaternion.identity);
        temp.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);

        for (int i = 0; i < numOfCardSlots; i++){
            temp = PhotonNetwork.Instantiate(cardSlot.name, new Vector2(cardSlotX + (i*140), cardSlotY), Quaternion.identity);
            temp.name += i;
            temp.transform.SetParent(Parent.transform);
            temp.GetComponent<GameButtonsManager>().manager = manager;

            //temp.GetComponent<Button>().onClick.AddListener(() => {manager.GetComponent<Manager>().checkPressed("selecting");});
            //UnityEventTools.AddPersistentListener(temp.GetComponent<Button>().onClick, new UnityAction(manager.GetComponent<Manager>().checkPressed)); // No clue how or why this works but I am very happy that it does.
            // All this line of code does is add the active/instantiated (in the scene) 'Manager' game object to the 'On Click ()' part of the 'Button' 
            // component on the 'card slot' game objects, and then select the overloaded method 'checkPressed' (the one with no parameters) to give the
            // button its functionality.
            // I had to do this because the instantiated 'card slot' game objects each needed a reference to the active/instantiated 'Manager' game 
            // object instead of the prefab one so the second phase (selecting phase) would work (otherwise 'playerCards' and 'confirmButton' would have
            // references to the active/instantiated 'Manager' game object and the 'card slot's would be referencing the prefab and this was causing problems).
            
            // P.S. I had to do it this way because I couldn't add the active/instantiated 'Manager' game object to the components in the 'CardSlot' prefab
            // in the Unity interface.
        }
    }


    // Update is called once per frame
    void Update()
    {
        /*if (timer > delay){
            PhotonNetwork.Instantiate(promptCard.name, new Vector2(promptCardX, promptCardY), Quaternion.identity);

            for (int i = 0; i < numOfCardSlots; i++){
                PhotonNetwork.Instantiate(cardSlot.name, new Vector2(cardSlotX + (i*140), cardSlotY), Quaternion.identity);
            }
        }
        timer += Time.deltaTime;*/
    }
}
