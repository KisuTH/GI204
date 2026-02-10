using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathVfxPrefab;
    [SerializeField] private int health = 50;
    public void TakeDamage(int damage)
    {
        //RaycastHit hit;
        health -= damage;
        print($"{name} took {damage} damage!!!");
        if (health <= 0)
        {
            GameObject deathVfx = Instantiate(deathVfxPrefab, transform.position, Quaternion.identity);
            Destroy(deathVfx, 1);
            Destroy(gameObject, 1);
        }
    }
}
