using UnityEngine;
using System.Collections;

public class UpdateInfo : MonoBehaviour {

    private Player player;
    private TextMesh text;

	// Use this for initialization
	void Start () {
        this.player = this.transform.parent.GetComponent<Player>();
        this.text = this.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        this.text.text = string.Format("Flashlight: {0}", this.player.flashlightPower());
	}
}
