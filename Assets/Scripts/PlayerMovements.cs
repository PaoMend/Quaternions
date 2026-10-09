using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 5f;
    public float rotation = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position += transform.forward * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 0.96f, transform.position.z);
        transform.Rotate(0,horizontalInput * rotation * Time.deltaTime, 0);

    }
}
