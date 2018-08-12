using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour {

    [SerializeField]
    private Gun myGun;

    public void Shoot() {
        myGun.Shoot();
    }

}
