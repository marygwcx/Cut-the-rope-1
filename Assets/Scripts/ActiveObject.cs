using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObject : MonoBehaviour
{
    public GameObject ropeSegmentPrefab;       // Your rope segment prefab (with Rigidbody2D + HingeJoint2D)
    public int segmentCount = 10;              // Number of segments
    public Rigidbody2D candyRigidbody;         // Reference to the Candy
    public float segmentSpacing = 0.2f;        // Vertical space between segments

    private bool ropeBuilt = false;
    private GameObject lastSegment;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!ropeBuilt && other.attachedRigidbody == candyRigidbody)
        {
            BuildRope();
            ropeBuilt = true;
        }
    }

    void BuildRope()
    {
        Rigidbody2D previousBody = GetComponent<Rigidbody2D>(); // Pin's body

        Vector3 spawnPoint = transform.position;

        for (int i = 0; i < segmentCount; i++)
        {
            Vector3 pos = spawnPoint + Vector3.down * i * segmentSpacing;
            GameObject segment = Instantiate(ropeSegmentPrefab, pos, Quaternion.identity);
            Rigidbody2D rb = segment.GetComponent<Rigidbody2D>();
            HingeJoint2D joint = segment.GetComponent<HingeJoint2D>();

            joint.connectedBody = previousBody;
            previousBody = rb;

            lastSegment = segment;
        }

        AttachCandyToLastSegment();
    }

    void AttachCandyToLastSegment()
    {
        if (lastSegment != null && candyRigidbody != null)
        {
            HingeJoint2D candyJoint = candyRigidbody.gameObject.AddComponent<HingeJoint2D>();
            candyJoint.connectedBody = lastSegment.GetComponent<Rigidbody2D>();
            candyJoint.autoConfigureConnectedAnchor = false;
            candyJoint.anchor = Vector2.zero;
            candyJoint.connectedAnchor = Vector2.zero;
        }
    }
}
