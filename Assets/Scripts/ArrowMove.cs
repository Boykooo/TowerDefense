using UnityEngine;

public class ArrowMove : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        speed = 100;
        transform.LookAt(target);
        transform.Rotate(transform.rotation.x, 180, transform.rotation.z);
    }

    public Vector3 start;
    public Vector3 target;
    public float damage;

    private float speed;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) > 1)
        {
            transform.LookAt(target);
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z);

            //Vector3 direction = target - start;
            //transform.Translate(direction * Time.deltaTime * speed);

            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
