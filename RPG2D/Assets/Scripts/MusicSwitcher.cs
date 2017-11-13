using UnityEngine;
using System.Collections;

public class MusicSwitcher : MonoBehaviour {

    private MusicController mc;

    public int newTrack;

    public bool switchOnStart;

	// Use this for initialization
	void Start () {
        mc = FindObjectOfType<MusicController>();

        if (switchOnStart == true)
        {
            mc.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            mc.SwitchTrack(newTrack);
            gameObject.SetActive(false);

        }
    }
}
