using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandTransformMatcher : MonoBehaviour {

    public Transform rHandTransform;
    public Transform armatureTransform;

    private void Start()
    {
        rHandTransform.position = armatureTransform.position;
        rHandTransform.rotation = armatureTransform.rotation;
    }

    private void FixedUpdate()
    {
        rHandTransform.position = armatureTransform.position;
        rHandTransform.rotation = armatureTransform.rotation;
    }


}
