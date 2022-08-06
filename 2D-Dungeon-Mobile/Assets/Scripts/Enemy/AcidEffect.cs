using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{

    //move at 3 meters per second
    //detect collision with player and deal damage (IDamagaeble interface)
    //destroy this after 5 seconds

    private void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }

    public void Update()
    {
        transform.Translate(Vector3.right * 3 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IDamageable hit = other.GetComponent<IDamageable>();

            if (hit != null)
            {
                hit.Damage();

                Destroy(this.gameObject);
            }


        }
    }
}
