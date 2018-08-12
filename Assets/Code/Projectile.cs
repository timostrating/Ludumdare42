using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private Transform myTransform;
    private float speed = 20;

    void Start() {
        myTransform = transform;
        Destroy(this, 10f);
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }

    void Update() {
        myTransform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
