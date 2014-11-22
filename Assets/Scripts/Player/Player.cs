using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public LayerMask layerMask;
    private Transform flashlight;
    private PlayerInfo playerSettings;

	// Use this for initialization
	void Start () {
        this.flashlight = this.transform.FindChild("Flashlight");
        this.playerSettings = this.GetComponent<PlayerInfo>();
	}
	
	void FixedUpdate () {
        if (Physics.CheckSphere(this.transform.position, 1, this.layerMask))
            this.playerSettings.controlsEnabled = false;
	}

    public void decreaseFlashlightPower() {
        return;
        this.playerSettings.flashlightPower -= this.playerSettings.flashlightPower == 0 ? 0 : 1;
    }

    public int flashlightPower() {
        return this.playerSettings.flashlightPower / 10;
    }
}