/****
 * Created by: William Gulick
 * Date Created: 9/15/2021
 * 
 * Last edited by:
 * Last updated: 9/15/2021
 * 
 * Description: Controls player movement
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsLock : MonoBehaviour
{

    public Rect bounds;

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bounds.xMin, bounds.xMax), transform.position.y, Mathf.Clamp(transform.position.z, bounds.yMin, bounds.yMax));
    }

    private void OnDrawGizmosSelected()
    {
        const int cubeDepth = 1;
        Vector3 bCenter = new Vector3(bounds.xMin + bounds.width * 0.5f, 0, bounds.yMin + bounds.height * 0.5f);
        Vector3 bHeight = new Vector3(bounds.width, cubeDepth, bounds.height);

        Gizmos.DrawWireCube(bCenter, bHeight);
    }

}
