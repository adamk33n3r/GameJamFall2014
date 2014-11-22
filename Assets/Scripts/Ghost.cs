using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {
    public float forgetDistance = 15;
    public float moveSpeed = 0.05f;
    public float transparency = 0.3f;

    private SpriteRenderer spriteRenderer;
    private bool angry = false, changeState = false, shined = false, moving = false;
    private GameObject target;
    private Vector3 moveTo = Vector3.zero;

	void Start () {
        this.spriteRenderer = this.transform.FindChild ("Sprite").GetComponent<SpriteRenderer>();
        this.spriteRenderer.color = new Color(1f, 1f, 1f, transparency);
	}

    void Update() {
        if (this.target && Vector3.Distance(this.target.transform.position, this.transform.position) > this.forgetDistance) {
            this.target = null;
            this.angry = false;
            this.changeState = true;
        }
//        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
//        foreach (GameObject player in players) {
//
//        }
    }
	
	void FixedUpdate () {
        if (this.changeState) {
            this.changeState = false;
            if (this.angry) {
                spriteRenderer.color = new Color(1f, 0f, 0f, transparency);
            } else {
                spriteRenderer.color = new Color(1f, 1f, 1f, transparency);
            }
        }
        if (this.target && !this.shined)
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.target.transform.position, this.moveSpeed);
        if (!this.target) {
            if (!this.moving) {
                this.moveTo = new Vector3(Random.Range (0, 40), 2, Random.Range (0, 40));
                this.moving = true;
            }
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.moveTo, this.moveSpeed);
            if (this.moveTo == this.transform.position) {
                this.moving = false;
            }
        }
        this.shined = false;
	}

    void HitByRaycast(GameObject source) {
        this.target = source;
        this.changeState = this.angry = this.shined = this.moving = true;
        Debug.Log("OUCH! THE LIGHT!!!!");
    }
}
