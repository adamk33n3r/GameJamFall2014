using UnityEngine;
using System.Collections;
using System.Linq;

public class CameraTracking : MonoBehaviour {

    private GameObject[] players;
    private Vector3 angle;
    public float cameraAngle = 50f;
    public float cameraDistance = 30f;
    public bool zoom = true;

	// Use this for initialization
	void Start () {
        this.players = GameObject.FindGameObjectsWithTag("Player");
        this.transform.rotation = Quaternion.AngleAxis(this.cameraAngle, Vector3.right);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 center = this.players[0].transform.position;

        if (this.players.Length > 1) {
            foreach(GameObject player in this.players) {
                center = Vector3.Lerp(center, player.transform.position, .5f);
            }
        }
        if (this.zoom) {
            Mesh mesh = new Mesh();
            mesh.vertices = (from player in this.players select player.transform.position).ToArray();
            float dist = Vector3.Distance(mesh.bounds.min, mesh.bounds.max);
            this.cameraDistance = Mathf.Max (dist, 10);
        } else {
            this.cameraDistance = 30f;
        }

//        Debug.Log(Camera.main.WorldToViewportPoint(min));
        Vector3 newPos = center + Quaternion.AngleAxis(this.cameraAngle, Vector3.right) * Vector3.back * this.cameraDistance;
        this.transform.position = newPos;
        this.transform.LookAt(center);
	}
}
