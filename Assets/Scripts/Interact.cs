using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public GameObject NPC;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (NPC!=null && NPC.tag == "TextNPC" && NPC.GetComponent<Dialogue>().dialogueBox.activeSelf == false)
            {
                
                NPC.GetComponent<Dialogue>().StartDialogue();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        NPC = collision.gameObject;
    }

    void OnCollisionExit(Collision collision)
    {
        NPC = null;
    }
}
