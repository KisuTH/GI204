using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPos;
    [SerializeField] private float shootForce;
   

    
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
       
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, shootPos.position, shootPos.rotation);
        var rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(shootPos.forward * shootForce, ForceMode.Impulse);

        Destroy(bullet, 2.5f);
    }
}
