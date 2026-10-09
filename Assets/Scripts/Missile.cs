using UnityEngine;

public class Missile : MonoBehaviour
{
    private float targetDistance = 1f;
    public float speed = 10f;
    public float lifeTime = 5f;
    private Transform target;
    private PlayerHP playerHP;

    void Start()
    {
        playerHP = FindFirstObjectByType<PlayerHP>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy (gameObject, lifeTime);
    }

    void Update()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 5f * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (target == null)
            return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= targetDistance)
        {
            Destroy (gameObject);
            playerHP.TakeDamage(20f);
        }

    }
}
