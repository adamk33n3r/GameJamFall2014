using UnityEngine;
using System.Collections;

public class FaceCameraBehavior : MonoBehaviour {
    private Transform sprite;
    
    void Start () {
        Transform baseTrans = this.transform.FindChild("Sprite");
        this.sprite = baseTrans ? baseTrans : this.transform.GetChild(0).FindChild("Sprite");
    }

	void Update () {
        FaceCamera();
	}
    
    void FaceCamera() {
        Quaternion rot = this.transform.rotation;
        this.sprite.transform.rotation = new Quaternion(Camera.main.transform.rotation.x, rot.y, rot.z, rot.w);
    }
}
