using UnityEngine;
using System.Collections;

public class Bounds : MonoBehaviour {

    private BoxCollider2D bounds;
    private CameraController cam;

	// Use this for initialization
	void Start () {
        bounds = GetComponent<BoxCollider2D>();
        cam = FindObjectOfType<CameraController>();
        cam.setBounds(bounds);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
