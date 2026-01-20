using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float force; // แรงที่ต้องการ
    Rigidbody rb; // Component ฟิสิกส์
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //force = 10.5f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0,0,force));
    }
}
