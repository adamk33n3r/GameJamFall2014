using UnityEngine;
using System.Collections;

public class UpdateInfo : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start () {
        this.player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        this.guiText.text = string.Format("Position: {0}, {1}, {2}", this.player.transform.position.x, this.player.transform.position.y, this.player.transform.position.z);
	}
}
