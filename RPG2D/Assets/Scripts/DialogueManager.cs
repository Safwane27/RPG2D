using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dActive;

    public string[] dLines;
    public int currentLine;

    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (dActive && Input.GetKeyUp(KeyCode.Z))
        {
            //dBox.SetActive(false);
            //dActive = false;
            currentLine++;
        }

        if(currentLine >= dLines.Length)
        {
            dBox.SetActive(false);
            dActive = false;

            currentLine = 0;
            player.canMove = true;
        }

        dText.text = dLines[currentLine];
    }

    public void ShowBox(string dialogue)
    {
        dBox.SetActive(true);
        dActive = true;
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dBox.SetActive(true);
        dActive = true;
        player.canMove = false;
    }
}
