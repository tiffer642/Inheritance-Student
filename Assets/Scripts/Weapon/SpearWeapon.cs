using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearWeapon : Weapon
{
    //swinging variables
    [Header("Swinging Variables")]
    public float swingSpeed;
    public float swingDegrees;
    public float maxDistance;
    public float thrustSpeed;
    public Transform spawnPos;

    public void Start()
    {
        // Get the rigidbody, sprite renderer, and box collider components of the weapon.
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        spawnPos = transform.parent.transform;

        // Disable the weapon to start with.
        DisableWeapon();

    }

    public override void Attack()
    {
        //Rotate To start pos
        transform.localEulerAngles = new Vector3(0, 0, -swingDegrees * 2);
        //activate weapon
        EnableWeapon();
        //Swing and then deactivate
        StartCoroutine(SwingDown());

    }

    public void ResetPos()
    {
        transform.localEulerAngles = Vector3.zero;
        transform.position = spawnPos.position;
    }

    //swinging corutine
    IEnumerator SwingDown()
    {
        ResetPos();
        float degrees = 0;
        while (degrees < swingDegrees * 2)
        {
            transform.Rotate(Vector3.forward, swingSpeed * Time.deltaTime);
            degrees += swingSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(Thrust());

    }

    IEnumerator Thrust()
    {
        ResetPos();
        float distance = 0;
        transform.Translate(Vector3.left * 1);
        while (distance < maxDistance)
        {
            transform.Translate(Vector3.right * thrustSpeed * Time.deltaTime);
            distance += thrustSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        DisableWeapon();
    }
}
