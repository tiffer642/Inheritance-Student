using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwungWeapon : Weapon
{
    //swinging variables
    [Header("Swinging Variables")]
    public float swingSpeed;
    public float swingDegrees;

    public override void Attack()
    {
        //Rotate To start pos
        transform.localEulerAngles = new Vector3(0, 0, -swingDegrees);
        //activate weapon
        EnableWeapon();
        //Swing and then deactivate
        StartCoroutine(Swing());

    }

    //swinging corutine
    IEnumerator Swing()
    {
        float degrees = 0;
        while(degrees < swingDegrees * 2)
        {
            transform.Rotate(Vector3.forward, swingSpeed * Time.deltaTime);
            degrees += swingSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        DisableWeapon();
    }
}
