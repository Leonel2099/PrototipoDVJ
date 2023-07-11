using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishBullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);
    }
}
