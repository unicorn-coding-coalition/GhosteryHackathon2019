using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

 public class EventManager : MonoBehaviour
{
    //GameController controller;
    public InputField inputField;
    public string userInput;
    //GameController controller;

    void Awake()
    {
        //controller = GetComponent<GameController>();
        inputField.onEndEdit.AddListener(Meh);
    }

    void Meh(string input)
    {
        userInput = input;
    }

    public void OnButtonClick()
    {
        Debug.Log("In on button click function");
        var go = EventSystem.current.currentSelectedGameObject;
        if (userInput.Length > 0)
        { 
            Debug.Log("Gonna replace dat text.");
            go.GetComponentInChildren<Text>().text = userInput;
            InputComplete();
        }
       // Debug.Log(input);
    }

    void InputComplete()
    {
        //controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }

}
