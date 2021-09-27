/****
 * Created by: William Gulick
 * Date Created: 9/20/2021
 * 
 * Last edited by:
 * Last updated: 9/20/2021
 * 
 * Description: defines which object this game object will face
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceObj : MonoBehaviour
{
    public Transform target = null;
    public bool facePlayer = false;

    private void Awake()
    {
        if(!facePlayer) { return; }

        GameObject plrObj = GameObject.FindGameObjectWithTag("Player");

        if(plrObj != null)
        {
            target = plrObj.transform;
        }
    } //end Awake()

    // Update is called once per frame
    void Update()
    {
        if(target == null) { return; }

        Vector3 targetDir = target.position - transform.position;

        if(targetDir != Vector3.zero)
        {
            transform.localRotation = Quaternion.LookRotation(targetDir.normalized, Vector3.up);
        }
    } //end Update()
}
