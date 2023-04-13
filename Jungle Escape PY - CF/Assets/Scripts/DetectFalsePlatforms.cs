using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFalsePlatforms : MonoBehaviour
{
    public bool hit;
    int FalseLayer = 1 << 8;

    void Update()
    {
        hit = Physics.Raycast(transform.position, transform.forward, 3, FalseLayer);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.red);


        if (hit)
        {
            Debug.LogWarning("Be Careful!");
        }

        else if (!hit)
        {
            Debug.LogWarning("All Clear");
        }
    }
}
