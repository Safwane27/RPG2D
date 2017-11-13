using UnityEngine;
using System.Collections;

public class QuestTrigger : MonoBehaviour {

    private QuestManager qm;

    public int questIndex;

    public bool questInProgress;

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
            if (!qm.questCompleted[questIndex])
            {
                if (questInProgress && !qm.quests[questIndex].gameObject.activeSelf)
                {
                    qm.quests[questIndex].gameObject.SetActive(true);
                    qm.quests[questIndex].StartQuest();
                }

                if(!questInProgress && qm.quests[questIndex].gameObject.activeSelf)
                {
                    qm.quests[questIndex].gameObject.SetActive(false);
                    qm.quests[questIndex].EndQuest();
                }
            }
        }
    }
}
