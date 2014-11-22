using UnityEngine;
using System.Collections;

public class SwingingLight : MonoBehaviour {

    private int dir = 1;
    private float speed = 2f;

    // Use this for initialization
    void Start () {
    }
    
    // Update is called once per frame
    void Update () {
        this.transform.position = new Vector3 (this.transform.position.x + this.speed * this.dir * Time.deltaTime, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.x < -10 && this.dir == -1)
            this.dir = 1;
        else if (this.transform.position.x > 10 && this.dir == 1) {
            this.dir = -1;
        }
    }
}
