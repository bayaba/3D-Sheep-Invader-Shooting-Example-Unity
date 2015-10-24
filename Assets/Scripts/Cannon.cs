using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
    public Camera UICam;
    Transform target;

	void Start()
	{
        target = GameObject.Find("UICamera/CrossPoint").transform;
	}
	
	void Update()
	{
        Vector3 pos = UICam.WorldToScreenPoint(target.position);
        Vector3 tarPos = Camera.main.ScreenToWorldPoint(pos);
        transform.LookAt(tarPos);
	}
}
