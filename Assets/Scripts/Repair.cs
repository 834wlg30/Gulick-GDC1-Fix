using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public int healAmt;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Health h = other.gameObject.GetComponent<Health>();
            h.HP += healAmt;

            Destroy(this.gameObject);
        }
    }
}
