using UnityEngine;
using System.Collections;

public class DeformSway : MonoBehaviour
{
    public SkinnedMeshRenderer mr;
    
	// Use this for initialization
	void Start ()
    {
        mr = GetComponent<SkinnedMeshRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        mr.SetBlendShapeWeight(0, Mathf.Abs(Mathf.Cos(Time.time) * 100));
	}
}
