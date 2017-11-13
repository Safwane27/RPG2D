using UnityEngine;
using System.Collections;

public class QuestObject : MonoBehaviour {

    public int questIndex;
    public QuestManager qm;

    public string startText;
    public string endText;

    public bool isItemQuest;
    public string targetItem;

    public bool isEnemyQuest;
    public string targetEnemy;
    public int enemiesToKill;
    private int enemyKillCount;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (isItemQuest)
        {
            if (qm.itemCollected == targetItem)
            {
                qm.itemCollected = null;
                EndQuest();
            }
        }

        if (isEnemyQuest)
        {
            if(qm.enemyKilled== targetEnemy)
            { 
                qm.enemyKilled= null;
                enemyKillCount++;

                if(enemyKillCount >= enemiesToKill)
                {
                    EndQuest();
                }
            }
        }
	}

    public void StartQuest()
    {
        qm.ShowQuestText(startText);
    }

    public void EndQuest()
    {
        qm.ShowQuestText(endText);
        qm.questCompleted[questIndex] = true;
        gameObject.SetActive(false);
    }
}
