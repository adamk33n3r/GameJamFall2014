using UnityEngine;
using System.Collections;

public class GlowLight : MonoBehaviour {

    public float max = 0.7f;
    public float min = 0f;
    public float speed = 1f;

    private Light light;
    private int dir = 1;

	void Start () {
        this.light = this.GetComponentInChildren<Light>();
	}
	
	void Update () {
        this.light.intensity += this.dir * this.speed * Time.deltaTime;
        if (this.light.intensity >= this.max) {
            this.dir = -1;
        } else if (this.light.intensity <= this.min) {
            this.dir = 1;
        }
	}
}
