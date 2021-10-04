/****
 * Created by: William Gulick
 * Date Created: 9/20/2021
 * 
 * Last edited by:
 * Last updated: 9/20/2021
 * 
 * Description: Deals damage to colliding object with health component
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyDamage : MonoBehaviour
{
    public float dmgVal = 10f; //dmg on collision

    private void OnTriggerEnter(Collider other)
    {
        Health h = other.gameObject.GetComponent<Health>();

        if(h == null) { return; }

        h.HP -= dmgVal;
        Destroy(this.gameObject); //object dies upon collision
    }

    private void OnDestroy()
    {
        
    }
}
