using UnityEngine;
using System.Collections;

public class AvatarBody : MonoBehaviour
{
    public GameObject avatarHead;

    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, avatarHead.transform.rotation.eulerAngles.y, transform.rotation.z));
    }
}
