using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testdegrees : MonoBehaviour
{
    public GameObject target;
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 posSelf = transform.position;
            Vector3 posTarget = target.transform.position;

            float adj = posTarget.z - posSelf.z;
            float opp = posTarget.x - posSelf.x;

            float inverse = 0;
            if (posSelf.z > posTarget.z)
            {
                inverse = 180;
            }

            float newRotateY = ((Mathf.Atan(opp / adj) * Mathf.Rad2Deg) + inverse);

            transform.rotation = Quaternion.Euler(transform.rotation.x, newRotateY, transform.rotation.z);
            //Debug.Log("Atan: " + newRotateY);
        }
    }
}
