using UnityEngine;
using System.Collections;

public class QuestItem : MonoBehaviour {

    public int questIndex;

    private QuestManager qm;

    public string itemName;

	// Use this for initialization
	void Start () {
        qm = FindObjectOfType<QuestManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if(!qm.questCompleted[questIndex] && qm.quests[questIndex].gameObject.activeSelf)
            {
                qm.itemCollected = itemName;
                gameObject.SetActive(false);
            }
        }
    }
}
