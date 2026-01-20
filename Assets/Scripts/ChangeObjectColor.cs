using UnityEngine;

public class ChangeObjectColor : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        //เปลี่ยนสีของวัตถุตนเอง (วัตถุที่เอา Script ตัวนี้ใส่)
        GetComponent<Renderer>().material.color = Color.crimson;

        //เปลี่ยนสีของวัตถุที่ไปชน (other)
        other.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().material.color = Color.violetRed;

        other.gameObject.GetComponent<Renderer>().material.color = Color.indigo;
    }
}
