using UnityEngine;
using System.Collections;

public class FlashlightController : MonoBehaviour {
    public float flashlightDist = 7;
    public LayerMask layerMask, layerMask2;

    private Transform flashlight;
    private bool controlsEnabled;
    private Player player;

    private bool flashlightOn = false;

    void Start() {
        this.flashlight = this.transform.FindChild("Flashlight");
        this.controlsEnabled = this.GetComponent<PlayerInfo>().controlsEnabled;
        this.player = this.GetComponent<Player>();
        Debug.Log (this.player.playerNum);
    }
    
	void Update () {
        this.controlsEnabled = this.GetComponent<PlayerInfo>().controlsEnabled;
        if (this.controlsEnabled) {
            if ((this.player.playerNum == 1 && Input.GetMouseButton(0)) || (this.player.playerNum == 2 && Input.GetAxis("Xbox360ControllerTriggers") < 0)) {
                this.flashlightOn = true;
            } else {
                this.flashlightOn = false;
            }
            Point ();
        }
	}

    void FixedUpdate() {
        if (this.flashlightOn && this.player.flashlightPower() > 0) {
            CastRays();
            this.flashlight.gameObject.SetActive(true);
            this.player.decreaseFlashlightPower();
        } else {
            this.flashlight.gameObject.SetActive(false);
        }
    }

    void CastRays() {
        RaycastHit hitt;
        if (!Physics.Raycast(this.transform.position, this.flashlight.transform.forward, out hitt, this.flashlightDist, this.layerMask2)) {
            RaycastHit[] hits = Physics.RaycastAll (this.transform.position, this.flashlight.transform.forward, this.flashlightDist, this.layerMask);
            if (hits.Length > 0) {
                foreach (RaycastHit hit in hits) {
                    hit.transform.SendMessage("HitByRaycast", this.gameObject, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }

    void Point() {
        float hor = this.player.playerNum == 1 ? (Input.mousePosition.x * 2 / Screen.width) - 1 : Input.GetAxis("Xbox360ControllerRightX");
        float vert = this.player.playerNum == 1 ? (-Input.mousePosition.y * 2 / Screen.height) + 1 : Input.GetAxis("Xbox360ControllerRightY");
        Vector3 lightPoint = new Vector3(hor, 0, vert);
        if (Mathf.Abs (hor) > 0.1f || Mathf.Abs(vert) > 0.1f) {
            this.flashlight.transform.RotateAround(this.transform.position, Vector3.up, (Mathf.Atan2( vert, hor ) * 180 / Mathf.PI + 90) - this.flashlight.transform.eulerAngles.y);
//            this.flashlight.eulerAngles = new Vector3( 20, Mathf.Atan2( vert, hor ) * 180 / Mathf.PI + 90, 0 );
        }
    }
}
