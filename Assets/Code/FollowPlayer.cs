using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public GameObject target;

	void Update () {
		transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z); 
	}
}
