using System.Collections;
using UnityEngine;

public class HandGunFire : MonoBehaviour
{

    [SerializeField] AudioSource gunFire;
    [SerializeField] GameObject handgun;
    [SerializeField] bool canFire = true;
    [SerializeField] GameObject extraCross;
    [SerializeField] AudioSource emptyGunSound;
    [SerializeField] GameObject objectDetection;

    //Jimmy Vegas provided a lot of the ground work code
    //and I added some things to it for firing the gun
    void OnEnable()
    {
        canFire = true;
    }
    void Update()
    {
        // add the and game complete so player couldnt shoot gun after finishing game
        if (Input.GetMouseButton(0) && !GameComplete.gameComplete)
        {
            if (canFire == true)
            {
                if(GlobalAmmo.handgunAmmoCount == 0)
                {
                    canFire = false;
                    StartCoroutine(EmptyGun());
                }
                else
                {
                    canFire = false;
                    // added the code to check what object is being looked at
                    objectDetection = PlayerCasting.lookedAtObject;

                    StartCoroutine(FiringGun());
                }
            }
        }
    }

    IEnumerator FiringGun()
    {
        gunFire.Play();
        extraCross.SetActive(true);
        GlobalAmmo.handgunAmmoCount -= 1;
        handgun.GetComponent<Animator>().Play("HandgunFire");
        //this part is what I added for detecting enemies and then doing damage 
        //when the enemy is clicked on
        if (objectDetection != null)
        {
            Enemy enemy = objectDetection.GetComponent<Enemy>();

            // this is where to damage occurs
            if (enemy != null)
            {
                enemy.TakeDamage(10);
            }
        }
        yield return new WaitForSeconds(0.5f);
        handgun.GetComponent<Animator>().Play("New State");
        extraCross.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }

    IEnumerator EmptyGun()
    {
        emptyGunSound.Play();
        yield return new WaitForSeconds(0.6f);
        canFire = true;
    }

}
