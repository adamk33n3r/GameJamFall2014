using UnityEngine;
using System.Collections;

public class LightFollow : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = this.player.transform.position;
        this.transform.position = new Vector3(playerPos.x, playerPos.y + 2, playerPos.z);
	}
}
