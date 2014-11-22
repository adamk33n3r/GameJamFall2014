using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public LayerMask layerMask;
    private Transform flashlight;
    private PlayerSettings playerSettings;

	// Use this for initialization
	void Start () {
        this.flashlight = this.transform.FindChild("Flashlight");
        this.playerSettings = this.GetComponent<PlayerSettings>();
	}
	
	void FixedUpdate () {
        RaycastHit hit;
        if (Physics.Raycast (this.transform.position, this.flashlight.transform.forward, out hit, 13)) {
            hit.transform.SendMessage("HitByRaycast", this.gameObject, SendMessageOptions.DontRequireReceiver);
        }
        if (Physics.CheckSphere(this.transform.position, 1, this.layerMask))
                this.playerSettings.controlsEnabled = false;
	}
}
