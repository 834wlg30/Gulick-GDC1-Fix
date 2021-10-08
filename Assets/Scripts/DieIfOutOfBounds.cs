using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieIfOutOfBounds : MonoBehaviour
{
    void Update()
    {
        if(this.gameObject.transform.position.z < 20)
        {
            Destroy(this.gameObject);
        }
    }
}
