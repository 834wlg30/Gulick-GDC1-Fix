/****
 * Created by: William Gulick
 * Date Created: 9/20/2021
 * 
 * Last edited by:
 * Last updated: 9/20/2021
 * 
 * Description: Controls player health
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health = 100f;

    public bool destroyOnDeath = true;
    public GameObject deathEffect = null;

    public float HP
    {
        get { return _health; }
        set
        {
            _health = value;
            if (HP <= 0)
            {
                SendMessage("Ded", SendMessageOptions.DontRequireReceiver);

                if (deathEffect != null)
                {
                    Instantiate(deathEffect, transform.position, transform.rotation);
                }

                if (destroyOnDeath)
                {
                    Destroy(gameObject);
                }
            }
        } //end set
    } // end public HP

    // Update is called once per frame
    void Update()
    {
        //debug health test
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HP = 0;
        }
    }
}
