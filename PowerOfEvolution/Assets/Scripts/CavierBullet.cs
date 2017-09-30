using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavierBullet : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CavierBullet collision");
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().takeDamage(10);
        }
        Destroy(gameObject);
    }
}
