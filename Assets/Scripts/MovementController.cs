using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    public bool enableControls = true;
    public float speed = 6f;
    public float jumpSpeed = 2f;
    public float gravity = 9.8f;

    private float vSpeed = 0;

    private CharacterController controller;
    private Transform sprite;
    private Vector3 moveDir = Vector3.zero;

	void Start () {
        this.controller = this.gameObject.GetComponent<CharacterController>();
        this.sprite = this.transform.FindChild("Sprite");
	}
	
	void Update () {
        if (this.enableControls) {
            Move ();
        }
        FaceCamera();
	}

    void Move() {
        float hor = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if (this.controller.isGrounded) {
            this.vSpeed = 0f;
            if (Input.GetButton ("Jump"))
                this.vSpeed = this.jumpSpeed;
        }
        vSpeed -= this.gravity * Time.deltaTime;
        moveDir = new Vector3(Mathf.Abs(hor) > 0.1f ? hor : 0, vSpeed, Mathf.Abs (vert) > 0.1f ? vert : 0);
        //moveDir = transform.TransformDirection(moveDir);
        moveDir *= this.speed;
        this.controller.Move(moveDir * Time.deltaTime);
    }

    void FaceCamera() {
        Quaternion rot = this.transform.rotation;
        this.sprite.transform.rotation = new Quaternion(Camera.main.transform.rotation.x, rot.y, rot.z, rot.w);
    }
}