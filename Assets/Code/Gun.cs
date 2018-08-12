using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Transform gunTip;
    public Projectile bullet;
    public float msBetweenShots = 200;
    public float bulletSpeed = 30;

    float nextShootTime = 0 ;

    public void Shoot() {
        if(Time.time > nextShootTime) {
            nextShootTime = Time.time + msBetweenShots / 1000;
            Projectile newProjectile = Instantiate(bullet, gunTip.position, gunTip.rotation) as Projectile;
            newProjectile.SetSpeed(bulletSpeed);
        }
    }

}
