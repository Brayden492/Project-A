using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float distance = 5f;

    private Vector3 startPosition;
    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingForward)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Vector3.Distance(startPosition, transform.position) >= distance)
            {
                movingForward = false;
            }
        }
        else
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);

            if (Vector3.Distance(startPosition, transform.position) <= 0.1f)
            {
                movingForward = true;
            }
        }
    }
}
