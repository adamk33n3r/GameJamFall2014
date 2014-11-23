using UnityEngine;
using System.Collections;
using System.Linq;

public class GameController : MonoBehaviour {

    private Player[] players;

	void Start () {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        this.players = (from playerObject in playerObjects select playerObject.GetComponent<Player>()).ToArray();
	}
	
	void Update () {
        int onButton = 0;
	    foreach (Player player in this.players) {
            onButton += player.OnButton() ? 1 : 0;
        }
        if (onButton == this.players.Length) {
            Debug.Log ("You Win!");
        }
	}
}
