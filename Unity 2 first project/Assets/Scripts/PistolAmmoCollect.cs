using UnityEngine;

public class PistolAmmoCollect : MonoBehaviour
{
    [SerializeField] AudioSource ammoCollect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        ammoCollect.Play();
        GlobalAmmo.handgunAmmoCount += 10;
        Destroy(gameObject);
    }
}
