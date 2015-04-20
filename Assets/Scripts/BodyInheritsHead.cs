using UnityEngine;
using System.Collections;

public class BodyInheritsHead : MonoBehaviour
{
    public Transform head;

    void Start()
    {
        if (!head) Debug.LogError(name + " has no head!");
    }

    void Update()
    {
        //transform.position = new Vector3(head.position.x, transform.position.y, head.position.z);
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, head.rotation.eulerAngles.y, transform.rotation.z));
    }
}
