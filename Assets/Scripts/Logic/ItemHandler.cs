using UnityEngine;
using System.Collections;

public class ItemHandler : MonoBehaviour {

    public enum Item {
        Battery,
        Wand
    }
    public Item item;
    public AudioClip sound;

	void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            AudioSource.PlayClipAtPoint(this.sound, this.transform.position, 5f);
            switch (this.item) {
                case Item.Battery:
                    other.GetComponent<Player>().decreaseFlashlightPower(-500);
                    Destroy (this.gameObject);
                    break;
                case Item.Wand:
                    other.GetComponent<Player>().turnOnNightVision();
                    Destroy (this.gameObject);
                    break;
            }
        }
    }
}
