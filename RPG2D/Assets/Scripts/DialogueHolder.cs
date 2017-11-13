using UnityEngine;
using System.Collections;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager dManager;

    public string[] dLines;

	// Use this for initialization
	void Start () {
        dManager = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Z))
            {
                //dManager.ShowBox(dialogue);
                if (!dManager.dActive)
                {
                    dManager.dLines = this.dLines;
                    dManager.currentLine = 0;
                    dManager.ShowDialogue();
                }

                if(transform.parent.GetComponent<VillagerMovement>() != null)
                {
                    transform.parent.GetComponent<VillagerMovement>().canMove = false;
                }
            }
        }
    }
}
