using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

    public int damageDealt;
    private int currentDmg;
    public GameObject damageNumber;

    private PlayerStats pS;
	// Use this for initialization
	void Start () {
        pS = FindObjectOfType<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            currentDmg = damageDealt - pS.currentDef;
            if(currentDmg < 0)
            {
                currentDmg = 0;
            }

            other.gameObject.GetComponent<PlayerHealthManager>().DamagePlayer(currentDmg);

            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDmg;
        }
    }
}
