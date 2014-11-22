using UnityEngine;
using System.Collections;

public class SwingingLight : MonoBehaviour {

    public AnimationCurve bobbingCurve;

    private int dir = 1;
    private float speed = 2f;
    private float timer = 0;
    // Use this for initialization
    void Start () {
    }
    
    // Update is called once per frame
    void Update () {
//        this.transform.position = new Vector3 (this.transform.position.x + this.speed * this.dir * Time.deltaTime, this.transform.position.y, this.transform.position.z);
//        if (this.transform.position.x < -10 && this.dir == -1)
//            this.dir = 1;
//        else if (this.transform.position.x > 10 && this.dir == 1) {
//            this.dir = -1;
//        }
        float change = this.bobbingCurve.Evaluate(this.timer);
        Debug.Log (change);
        this.transform.rotation = Quaternion.Euler (this.transform.eulerAngles.x,this.transform.eulerAngles.y,change* 30*this.dir);
        this.timer+= Time.deltaTime;

//        Quaternion newRot = Quaternion.Euler(0,0,30 * this.dir);
//        Debug.Log (this.transform.eulerAngles.z);
//        this.transform.rotation = Quaternion.Lerp (this.transform.rotation, newRot, Time.deltaTime * this.speed);
//        if (Mathf.RoundToInt(this.transform.eulerAngles.z) % 300 == 30) {
//            this.dir = -this.dir;
//            Debug.Log ("switching...");
//        }
    }
}
