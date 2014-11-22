using UnityEngine;
using System.Collections;

public class FlashlightController : MonoBehaviour {
    private Transform flashlight;
    private bool controlsEnabled;

    void Start() {
        this.flashlight = this.transform.FindChild("Flashlight");
        this.controlsEnabled = this.GetComponent<PlayerSettings>().controlsEnabled;
    }
    
    // Update is called once per frame
	void Update () {
        this.controlsEnabled = this.GetComponent<PlayerSettings>().controlsEnabled;
        if (this.controlsEnabled)
            Point ();
	}

    void Point() {
        float hor = Input.GetAxis("Xbox360ControllerRightX");
        float vert = Input.GetAxis("Xbox360ControllerRightY");
        Vector3 lightPoint = new Vector3(hor, 0, vert);
        if (Mathf.Abs (hor) > 0.1f || Mathf.Abs(vert) > 0.1f) {
            this.flashlight.transform.RotateAround(this.transform.position, Vector3.up, (Mathf.Atan2( vert, hor ) * 180 / Mathf.PI + 90) - this.flashlight.transform.eulerAngles.y);
//            this.flashlight.eulerAngles = new Vector3( 20, Mathf.Atan2( vert, hor ) * 180 / Mathf.PI + 90, 0 );
        }
    }
}
