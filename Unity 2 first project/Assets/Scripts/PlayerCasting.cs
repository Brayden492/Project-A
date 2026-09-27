using UnityEngine;

public class PlayerCasting : MonoBehaviour
{

    public static float distanceFromTarget;
    public static GameObject lookedAtObject;
    [SerializeField] float toTarget;

    void Update()
    {

        lookedAtObject = null;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            distanceFromTarget = hit.distance;
            toTarget = hit.distance;

            lookedAtObject = hit.collider.gameObject;

            //Debug.Log(lookedAtObject.name);
        }
    }
}
