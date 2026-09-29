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


    void OnEnable()
    {
        canFire = true;
    }
    void Update()
    {
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

                    objectDetection = PlayerCasting.lookedAtObject;
                    //if (objectDetection != null)
                    //{
                    //    Debug.Log("Detected: " + objectDetection.name);
                    //}
                    //else
                    //{
                    //    Debug.Log("Nothing detected.");
                    //}

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
        if (objectDetection != null)
        {
            Enemy enemy = objectDetection.GetComponent<Enemy>();

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
