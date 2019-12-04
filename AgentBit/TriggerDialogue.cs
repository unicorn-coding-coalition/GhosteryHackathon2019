using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour


{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.tag);
        Debug.Log("Howdy!");

        switch (col.tag)
        {
            case "Agent0":
                Debug.Log("let's take you to the gun range");
                //Add function that moves Agent 0 to the gun range wing
                break;
            case "Agent Logger":
                Debug.Log("Let's start the Firewall minigame!");
                break;
            case "Agent Daemon":
                Debug.Log("Ugh Let's go to the mall....today");
                break;
            default:
                break;

        }

    }

}
