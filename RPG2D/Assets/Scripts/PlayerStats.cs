using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public int currentLevel;
    public int currentExp;

    public int[] toLevelUp;

    public int[] hpLvls;
    public int[] strLvls;
    public int[] defLvls;

    public int currentHp;
    public int currentStr;
    public int currentDef;

    private PlayerHealthManager playerHM;

    // Use this for initialization
    void Start () {
        currentHp = hpLvls[1];
        currentStr = strLvls[1];
        currentDef = defLvls[1];

        playerHM = FindObjectOfType<PlayerHealthManager>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(currentExp >= toLevelUp[currentLevel])
        {
            LevelUp();
        }
	}

    public void addExp(int expToAdd)
    {
        currentExp += expToAdd;
    }

    public void LevelUp()
    {
        currentLevel++;

        currentHp = hpLvls[currentLevel];

        playerHM.playerMaxHp = currentHp;
        playerHM.playerCurrentHp = currentHp;

        currentStr = strLvls[currentLevel];
        currentDef = defLvls[currentLevel];
    }
}
