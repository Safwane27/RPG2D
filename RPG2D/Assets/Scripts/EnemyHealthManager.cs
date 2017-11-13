using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

    public int MaxHp;
    public int CurrentHp;

    private PlayerStats playerStats;

    public int expToGive;

    //Variables to send the name of the enemy to the Quest Manager
    public string enemyQuestName;
    private QuestManager qm;

    // Use this for initialization
    void Start()
    {
        CurrentHp = MaxHp;

        playerStats = FindObjectOfType<PlayerStats>();
        qm = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHp <= 0)
        {
            qm.enemyKilled = enemyQuestName;

            Destroy(gameObject);

            playerStats.addExp(expToGive);
        }
    }

    public void DamageEnemy(int damageDealt)
    {
        CurrentHp -= damageDealt;
    }

    public void SetMaxHp()
    {
        CurrentHp = MaxHp;
    }
}

