using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
    public float speed = 10f;
    public float flashlightSpeed = 6f;
    public float jumpSpeed = 4f;
    public float gravity = 9.8f;

    private float vSpeed = 0;
    private float facing = 1;
    private float bob = 1;

    private CharacterController controller;
    private Transform sprite;
    private Vector3 moveDir = Vector3.zero;
    private bool controlsEnabled;

    private Player player;

	void Start () {
        this.player = this.GetComponent<Player>();
        this.controller = this.gameObject.GetComponent<CharacterController>();
        this.sprite = this.transform.FindChild("Sprite");
        this.controlsEnabled = this.GetComponent<PlayerInfo>().controlsEnabled;
	}
	
	void Update () {
        this.controlsEnabled = this.GetComponent<PlayerInfo>().controlsEnabled;
        Move ();
	}

    void Move() {
        float hor, vert;
        if (this.controlsEnabled) {
            hor = this.player.playerNum == 1 ? Input.GetAxis("KeyHorizontal") : Input.GetAxis("JoyHorizontal");
            vert = this.player.playerNum == 1 ? Input.GetAxis("KeyVertical") : Input.GetAxis("JoyVertical");
            this.facing = hor == 0 ? this.facing : Mathf.Sign(hor);
            this.sprite.transform.localScale = new Vector3(this.facing, 1, 1);

            if (this.controller.isGrounded) {
                if (hor != 0 || vert != 0) {
                    //                this.sprite.transform.position = new Vector3(this.sprite.transform.position.x, this.sprite.transform.position.y + this.bob * Time.deltaTime, this.sprite.transform.position.z);
                    //                this.bob++;
                    //                this.bob = -this.bob;
//                    this.vSpeed = this.jumpSpeed;
                } else {
                    this.vSpeed = 0f;
                }
                if (Input.GetButton ("Jump"))
                    this.vSpeed = this.jumpSpeed;
            }
        } else {
            hor = vert = 0;
        }
        this.vSpeed -= this.gravity * Time.deltaTime;
        moveDir = new Vector3(Mathf.Abs(hor) > 0.1f ? hor : 0, vSpeed, Mathf.Abs (vert) > 0.1f ? vert : 0);
        //moveDir = transform.TransformDirection(moveDir);
        moveDir *= (this.player.playerNum == 2 && Input.GetAxis("Xbox360ControllerTriggers") < 0) || (this.player.playerNum == 1 && Input.GetMouseButton(0)) ? this.flashlightSpeed : this.speed;
        moveDir.y = vSpeed;
        this.controller.Move(moveDir * Time.deltaTime);
    }
}