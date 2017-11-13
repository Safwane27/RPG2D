using UnityEngine;
using System.Collections;

public class SFXManager : MonoBehaviour {

    public AudioSource playerHurt;
    public AudioSource playerAttack;

    private static bool sfxManExists;

	// Use this for initialization
	void Start () {
        if (!sfxManExists)
        {
            sfxManExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
