/****
 * Created by: William Gulick
 * Date Created: 9/13/2021
 * 
 * Last edited by:
 * Last updated: 10/2/2021
 * 
 * Description: Controls player movement
 ****/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //------------------------------
    private Rigidbody ThisBody = null;
    private Transform ThisTransform = null;

    public bool MouseLook = true;
    public string HorzAxis = "Horizontal";
    public string VertAxis = "Vertical";
    public string FireAxis = "Fire1";

    public float MaxSpeed = 8f;
    public float ReloadDelay = 0.05f;
    public bool CanFire = true;

    public Transform[] TurretTransforms;
    //------------------------------
    // Use this for initialization
    void Awake()
    {
        ThisBody = GetComponent<Rigidbody>();
        ThisTransform = GetComponent<Transform>();
    }
    //------------------------------
    // Update is called once per frame
    void FixedUpdate()
    {
        //Update movement
        float Horz = Input.GetAxis(HorzAxis);
        float Vert = Input.GetAxis(VertAxis);

        //horizontal movement and "braking"
        if (Horz != 0f)
        {
            ThisBody.velocity = new Vector3(Horz * MaxSpeed, 0f, ThisBody.velocity.z);
        }

        //vertical movement and "braking"
        if (Vert != 0f)
        {
            ThisBody.velocity = new Vector3(ThisBody.velocity.x, 0f, Vert * MaxSpeed);
        }

        //Should look with mouse?
        if (MouseLook)
        {
            //Update rotation - turn to face mouse pointer
            Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            MousePosWorld = new Vector3(MousePosWorld.x, 0.0f, MousePosWorld.z);

            //Get direction to cursor
            Vector3 LookDirection = MousePosWorld - ThisTransform.position;

            //FixedUpdate rotation
            ThisTransform.localRotation = Quaternion.LookRotation(LookDirection.normalized, Vector3.up);
        }
    }
    //------------------------------

    void Update()
    {
        //Check fire control
        if (Input.GetButtonDown(FireAxis) && CanFire)
        {
            foreach (Transform T in TurretTransforms)
                AmmoManager.SpawnAmmo(T.position, T.rotation);

            CanFire = false;
            Invoke("EnableFire", ReloadDelay);
        }
    }
    void EnableFire()
    {
        CanFire = true;
    }
    //------------------------------
    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameManager.GameOver();
    }
}
