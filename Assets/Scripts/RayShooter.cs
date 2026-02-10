using System.Transactions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ray_shooter : MonoBehaviour
{
    [SerializeField] private Transform shootPos;
    [SerializeField] private float rayLength = 10;
    

    void Update()
    {
        ShootRay();
    }
    [SerializeField] private GameObject shootVfxPrefab;
    [SerializeField] private GameObject hitVfxPrefab;
    [SerializeField] private int damage = 25;
    void ShootRay()
    {
        // ตัวแปรเก็บว่า Ray ไปชนอะไรตอนนี้
        RaycastHit hit;

        //วาดเส้น Ray ให้เห็น เพื่อดูระยะ และ Debug อื่นๆ (ไม่มีการใช้งานจริง)
        Debug.DrawRay(shootPos.position, transform.forward * rayLength, Color.green);

        //ยิง Ray (แบบมองไม่เห็น) ออกไปเพื่อเช็คการกระทบ Object แล้วเก็ยออกไปใส่ตัวแปร Hit
        if (Physics.Raycast(shootPos.position, transform.forward, out hit, rayLength))
        {
            //วาดเส้น Ray เป็นสีแดง
            Debug.DrawRay(shootPos.position, transform.forward * rayLength, Color.red);

        //พิมพ์ชื่อวัตถุที่ชนลง Log
            Debug.Log($"Ray hits: {hit.collider.name}");
            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                // เสก prefab vfx ที่จุดที่จุดยิงออก
                GameObject shootVfx = Instantiate(shootVfxPrefab, shootPos.position, Quaternion.identity);
                // เสก prefab vfx ที่จุดยิงโดนวัตถุ
                GameObject hitVfx = Instantiate(hitVfxPrefab, hit.point, Quaternion.identity);
                Destroy(shootVfx, 2);
                Destroy(hitVfx, 2);

                if (hit.collider.CompareTag("Enemy"))
                {
                    Enemy enemy = hit.collider.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(damage);
                    }
                }
                else if (hit.collider.CompareTag("Obstacle"))
                {
                    Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddTorque(0, 5000, 0);
                    }
                }
            }
        }
    }
}
