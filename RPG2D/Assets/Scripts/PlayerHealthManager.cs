using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

    public int playerMaxHp;
    public int playerCurrentHp;

    private SFXManager sfxMan;

	// Use this for initialization
	void Start () {
        playerCurrentHp = playerMaxHp;
        sfxMan = FindObjectOfType<SFXManager>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(playerCurrentHp <= 0)
        {
            gameObject.SetActive(false);
        }
	}

    public void DamagePlayer(int DamageDealt)
    {
        playerCurrentHp -= DamageDealt;
        StartCoroutine("HurtColor");

        sfxMan.playerHurt.Play();
    }

    IEnumerator HurtColor()
    {
        for (int i = 0; i < 3; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f); //Red, Green, Blue, Alpha/Transparency
            yield return new WaitForSeconds(.1f);
            GetComponent<SpriteRenderer>().color = Color.white; //White is the default "color" for the sprite, if you're curious.
            yield return new WaitForSeconds(.1f);
        }
    }

    public void SetMaxHp()
    {
        playerCurrentHp = playerMaxHp;
    }
}
