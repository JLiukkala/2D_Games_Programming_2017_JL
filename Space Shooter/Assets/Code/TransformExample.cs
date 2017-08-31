using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformExample : MonoBehaviour {

    public float Speed = 1;

	void Update ()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
	}
}
