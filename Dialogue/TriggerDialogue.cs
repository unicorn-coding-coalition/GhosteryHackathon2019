using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghostery
{
    public class TriggerDialogue : MonoBehaviour


    {
        // Start is called before the first frame update
        void OnTriggerEvent(Collider col)
        {
            Debug.Log(col.tag);
            Debug.Log("Howdy!");

            //switch (col.tag)
            //{
            //    case "Agent0":
            //        Debug.Log("Let's take you to the gun range");
            //        break;
            //    case "Agent Logger":
            //        break;
            //    case "Agent Daemon":
            //        break;
            //    default:
            //        Debug.Log("No tag available!");
            //        break;

            //}

        }

    }
}
