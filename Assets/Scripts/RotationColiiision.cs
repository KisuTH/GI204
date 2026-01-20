using UnityEngine;

public class RotationColiiision : MonoBehaviour
{
    [SerializeField] float torque; // แรงที่ต้องการ
    Rigidbody rb; // Component ฟิสิกส์
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //force = 10.5f;
    }

    
    void Update()
    {
        rb.AddTorque(Vector3.up);
    }

    private void OnCollisionEnter(Collision other)
    {
        other.rigidbody.AddTorque(Vector3.up * torque);
    }
}
