using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider hpBar;
    public Text hpText;
    public PlayerHealthManager playerHp;

    private PlayerStats ps;
    public Text lvlText;

    private static bool UIExists;

	// Use this for initialization
	void Start () {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        ps = GetComponent<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update () {
        hpBar.maxValue = playerHp.playerMaxHp;
        hpBar.value = playerHp.playerCurrentHp;
        hpText.text = "HP: " + playerHp.playerCurrentHp + "/" + playerHp.playerMaxHp;
        lvlText.text = "LV: " + ps.currentLevel;
    }
}
