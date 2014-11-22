using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
    public float speed = 6f;
    public float jumpSpeed = 2f;
    public float gravity = 9.8f;

    private float vSpeed = 0;
    private float facing = 1;

    private CharacterController controller;
    private Transform sprite;
    private Vector3 moveDir = Vector3.zero;
    private bool controlsEnabled;

	void Start () {
        this.controller = this.gameObject.GetComponent<CharacterController>();
        this.sprite = this.transform.FindChild("Sprite");
        this.controlsEnabled = this.GetComponent<PlayerSettings>().controlsEnabled;
	}
	
	void Update () {
        this.controlsEnabled = this.GetComponent<PlayerSettings>().controlsEnabled;
        Move ();
	}

    void Move() {
        float hor, vert;
        if (this.controlsEnabled) {
            hor = Input.GetAxis("Horizontal");
            vert = Input.GetAxis("Vertical");
            this.facing = Mathf.Sign(hor);
            this.sprite.transform.localScale = new Vector3(this.facing, 1, 1);
            if (this.controller.isGrounded) {
                this.vSpeed = 0f;
                if (Input.GetButton ("Jump"))
                    this.vSpeed = this.jumpSpeed;
            }
        } else {
            hor = vert = 0;
        }
        this.vSpeed -= this.gravity * Time.deltaTime;
        moveDir = new Vector3(Mathf.Abs(hor) > 0.1f ? hor : 0, vSpeed, Mathf.Abs (vert) > 0.1f ? vert : 0);
        //moveDir = transform.TransformDirection(moveDir);
        moveDir *= this.speed;
        this.controller.Move(moveDir * Time.deltaTime);
    }
}