using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public LayerMask deathLayer;
    public LayerMask buttonLayer;
    private Transform flashlight;
    private PlayerInfo playerSettings;
    private GameSettings gameSettings;

    private Color oldColor, newColor;

	// Use this for initialization
	void Start () {
        this.flashlight = this.transform.FindChild("Flashlight");
        this.playerSettings = this.GetComponent<PlayerInfo>();
        this.gameSettings = GameObject.FindObjectOfType<GameSettings>();
    }
	
	void FixedUpdate () {
        if (Physics.CheckSphere(this.transform.position, 1, this.deathLayer)) {
//            this.playerSettings.controlsEnabled = false;
        }
	}

    public void decreaseFlashlightPower(int amount = 1) {
        this.playerSettings.flashlightPower -= this.playerSettings.flashlightPower == 0 ? 0 : amount;
    }

    public void fillFlashlightPower() {
        this.playerSettings.flashlightPower = 1000;
    }

    public int flashlightPower() {
        return this.playerSettings.flashlightPower / 10;
    }

    public void turnOnNightVision() {
//        this.playerSettings.nightVision = true;
//        this.oldColor = this.gameSettings.getAmbient();
        this.oldColor = Color.black;
        this.newColor = new Color(.25f, .25f, .25f);
        CancelInvoke("turnOffNightVision");
        CancelInvoke("transitionAmbientDown");
        InvokeRepeating("transitionAmbientUp", 0, 0.05f); 
        Invoke ("turnOffNightVision", 10);
    }

    public void turnOffNightVision() {
//        this.playerSettings.nightVision = false;
        CancelInvoke("transitionAmbientUp");
        CancelInvoke("turnOffNightVision");
        InvokeRepeating("transitionAmbientDown", 0, 0.05f);
        Invoke ("cancelTransitionDown", 5);
    }

    private void cancelTransitionDown() {
        CancelInvoke("transitionAmbientDown");
        this.gameSettings.setAmbient(this.oldColor);
    }

    
    private void transitionAmbientUp() {
        this.gameSettings.setAmbient(Color.Lerp (this.gameSettings.getAmbient(), this.newColor, Time.deltaTime*2));
    }
    
    private void transitionAmbientDown() {
        this.gameSettings.setAmbient(Color.Lerp (this.gameSettings.getAmbient(), this.oldColor, Time.deltaTime*2));
    }

    public bool OnButton () {
        return Physics.CheckSphere(this.transform.position, 2, buttonLayer);
    }
}