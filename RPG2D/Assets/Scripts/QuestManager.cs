using UnityEngine;
using System.Collections;

public class QuestManager : MonoBehaviour {

    public QuestObject[] quests;
    public bool[] questCompleted;

    public DialogueManager dm;

    public string itemCollected;

    public string enemyKilled;

	// Use this for initialization
	void Start () {
        questCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowQuestText(string questText)
    {
        dm.dLines = new string[1];
        dm.dLines[0] = questText;

        dm.currentLine = 0;
        dm.ShowDialogue();
    }
}
