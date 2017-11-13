using UnityEngine;
using System.Collections;

public class AttackEnemy : MonoBehaviour {

    public int damageDealt;
    private int currentDmg;
    public GameObject damageBurst;
    public Transform impactPoint;
    public GameObject damageNumber;

    private PlayerStats pS;

    // Use this for initialization
    void Start () {
        pS = FindObjectOfType<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            currentDmg = damageDealt + pS.currentStr;

            other.gameObject.GetComponent<EnemyHealthManager>().DamageEnemy(currentDmg);
            Instantiate(damageBurst, impactPoint.position, impactPoint.rotation);
            var clone = (GameObject) Instantiate(damageNumber, impactPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDmg;
        }
    }
}
