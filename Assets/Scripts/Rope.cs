using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public GameObject candy;
    public GameObject ropeJoint;
    public float distance = 0.2f;
    
    private List<Transform> ropeJoints = new();
    
    void Start()
    {
        int count = (int)(Vector3.Distance(transform.position, candy.transform.position) / distance);
        
        Vector3 pos = transform.position;

        for (int i = 0; i < count; i++)
        {
            GameObject joint = Instantiate(ropeJoint, pos, Quaternion.identity, transform);
            
            pos = Vector3.Lerp(transform.position, candy.transform.position, (float)i / count);


            if (i == 0)
                joint.GetComponent<Joint2D>().connectedBody = GetComponent<Rigidbody2D>();
            else
                joint.GetComponent<Joint2D>().connectedBody = ropeJoints[i - 1].GetComponent<Rigidbody2D>();
            
            ropeJoints.Add(joint.transform);
        }

        Joint2D candyJoint = candy.AddComponent<HingeJoint2D>();
        candyJoint.connectedBody = ropeJoints[^1].GetComponent<Rigidbody2D>();
    }
}
