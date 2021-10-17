using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SpawnCards : MonoBehaviour
{
    public GameObject Parent;
    public Button promptCard;
    public Button cardSlot;
    public int numOfCardSlots = 6;
    public float promptCardX;
    public float promptCardY;
    public float cardSlotX; //x position of the first card slot.
    public float cardSlotY; //y position of the first card slot.
    private float delay = 1f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = new GameObject();
        temp = PhotonNetwork.Instantiate(promptCard.name, new Vector2(promptCardX, promptCardY), Quaternion.identity);
        temp.transform.SetParent(Parent.transform);

        for (int i = 0; i < numOfCardSlots; i++){
            temp = PhotonNetwork.Instantiate(cardSlot.name, new Vector2(cardSlotX + (i*140), cardSlotY), Quaternion.identity);
            temp.name += i;
            temp.transform.SetParent(Parent.transform);
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
