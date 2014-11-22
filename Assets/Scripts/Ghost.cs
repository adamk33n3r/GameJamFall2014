using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private bool angry = false, changeState = false, shined = false;
    private GameObject target;

	void Start () {
        this.spriteRenderer = this.transform.FindChild ("Sprite").GetComponent<SpriteRenderer>();
        this.spriteRenderer.color = new Color(1f, 1f, 1f, 0.1f);
	}
	
	void FixedUpdate () {
        if (this.changeState) {
            this.changeState = false;
            if (this.angry) {
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            } else {
                spriteRenderer.color = new Color(1f, 1f, 1f, 0.1f);
            }
        }
        if (this.target && !this.shined)
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.target.transform.position, .1f);
        this.shined = false;
	}

    void HitByRaycast(GameObject source) {
        this.spriteRenderer.color = new Color(1f,0f,0f);
        this.target = source;
        this.changeState = this.angry = this.shined = true;
//        Debug.Log("OUCH! THE LIGHT!!!!");
    }
}
