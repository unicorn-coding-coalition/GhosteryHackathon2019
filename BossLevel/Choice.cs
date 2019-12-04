using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.sprite;

public class Choice : MonoBehaviour
{

    public Text TextBox;
    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public Sprite defaultSprite;
    public Sprite sadSprite;
    public Sprite oldSprite;
    public Sprite happySprite;
    private int idx = 0;
    private int score = 0;

    public static List<string> questions = new List<string>(new string[]
    {"What is the best password practice?","Why should you use a VPN?", "What tool can spoof your IP address?",
    "You receive an email from a Nigerian prince asking you to open an attachment in order for you to earn millions of dollars. What should you do?",
    "Most hacks/cyber security attacks have occured because...",
    "You open up an email from a person claiming to be part of your company. Their email contains a link to a login page for your company account. What should you do?",
    "Why should you care if someone is recording your data?",
    "What is the purpose of a keylogger?",
    "Virus protection can always detect and remove all viruses",
    "You should have a different strong password for all of your accounts"
    });

    List<(bool, string)> Choice1List = new List<(bool, string)>
     {
      (true, "Make sure your password is strong, consisting of uppercase, lowercase, special characters, and numbers. "),
      (false, "VPNs help keep your personal information private"),
      (true, "VPN"),
      (false, "Download the attachment. You are going to be rich!"),
      (true, "A password was easily guessed or compromised"),
      (false, "Click on the link and enter your credentials. If it’s from a colleague, it can’t be malicious!"),
      (false, "You are making yourself more vulnerable to identity theft if you don’t protect your personal data"),
      (false, "To place malware on your webcam"),
      (false, "True"),
      (true, "True")
    };

    List<(bool, string)> Choice2List = new List<(bool, string)>
     {
      (false, "You can choose the same password for every account as long as it’s a strong one."),
      (false, "VPNs can help anonymize your browsing"),
      (false, "Firewall"),
      (true, "Delete the email"),
      (false, "A sophisticated virus was planted in a computer"),
      (false, "Click on the link to see where it takes you, just to see!"),
      (true, "Both"),
      (true, "To steal your credentials"),
      (true, "False"),
      (false, "False")
    };

    List<(bool, string)> Choice3List = new List<(bool, string)>
     {
      (false, "Choose one password for all accounts, but just add a different character or number after the password so you can remember it. "),
      (true, "Both"),
      (false, "Virus Protection"),
      (false, "Send the email to your friends so they can get a laugh out of it."), 
      (false, "Someone hacked through the mainframe"),
      (true, "Verify that the email is from an actual colleague before clicking on the link"),
      (false, "Companies are making money off of you without your consent"),
      (false, "To damage your keyboard"),
      (false, "It can always detect viruses, but not always remove."),
      (false, "It is safe to use the same password for some accounts if it strong")
    };

    //public Dictionary<string, List<string>> optionDict = new Dictionary<string, List<string>>();
    //optionDict.Add("option1", Choice1List);

    // Start is called before the first frame update
    public void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        TextBox.text = questions[idx];
        choice1.GetComponentInChildren<Text>().text = Choice1List[idx].Item2;
        choice2.GetComponentInChildren<Text>().text = Choice2List[idx].Item2;
        choice3.GetComponentInChildren<Text>().text = Choice3List[idx].Item2;
        ContinueGame();
    }

    private void SadMonsterExpression()
    {
        //oldSprite.GetComponent<SpriteRenderer>().sprite = sadSprite;
        Debug.Log("Monster says : I'm sad");
    }


    private void HappyMonsterExpression()
    {
        //oldSprite.GetComponent<SpriteRenderer>().sprite = happySprite;
        Debug.Log("Monster says : I'm happy >:}");
    }

    public void ContinueGame()
    {
        Debug.Log("In ContinueGame function");
        var b = EventSystem.current.currentSelectedGameObject;

        switch (b.name)
        {
            case "Option1":
                if (Choice1List[idx].Item1 == true)
                {
                    Debug.Log("You chose correctly!");
                    score++;
                    idx++;
                    //SadMonsterExpression();
                }
                else
                    goto default;
                break;
            case "Option2":
                if (Choice2List[idx].Item1 == true)
                {
                    Debug.Log("You chose correctly!");
                    score++;
                    idx++;
                    //SadMonsterExpression();
                }
                else 
                    goto default;
                break;
            case "Option3":
                if (Choice3List[idx].Item1 == true)
                {
                    Debug.Log("You chose correctly!");
                    score++;
                    idx++;
                    //SadMonsterExpression();
                }
                else 
                    goto default;
                break;
            default:
                Debug.Log("Incorrect >:}");
                idx++;
                //HappyMonsterExpression();
                break;
        }

        if (idx < 10)
        {
            EventSystem.current.SetSelectedGameObject(null);
            UpdateText();
        }

        else
        {
            if (score >= 7)
            {
                Debug.Log("You win!");
                SceneManager.LoadScene(sceneName: "Base");
                SadMonsterExpression();
            }

            else
            {
                Debug.Log("You Lose >:}");
                HappyMonsterExpression();
                SceneManager.LoadScene(sceneName: "Base");
            }
        }

    }

}
