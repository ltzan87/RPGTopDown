using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCanvas : MonoBehaviour
{
    public Transform target;
    
    void Update()
    {
        transform.rotation = Quaternion.Inverse(target.rotation);
    }
}