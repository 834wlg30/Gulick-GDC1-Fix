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
        Health pH = other.gameObject.GetComponent<Health>();
        Health tH = this.gameObject.GetComponent<Health>();

        if(pH == null) { return; }

        pH.HP -= dmgVal;
        tH.HP = 0; //object dies upon collision
    }

    private void OnDestroy()
    {
        
    }
}
