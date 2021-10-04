/****
 * Created by: William Gulick
 * Date Created: 9/20/2021
 * 
 * Last edited by:
 * Last updated: 9/20/2021
 * 
 * Description: Controls enemy movement
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float maxSpeed = 7f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * maxSpeed * Time.deltaTime;
    } //end update
}
