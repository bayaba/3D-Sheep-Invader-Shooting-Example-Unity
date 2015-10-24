using UnityEngine;
using System.Collections;

public class CrossPoint : MonoBehaviour
{
    public Camera UICam;
    public RectTransform MyStick;

	void Update()
	{
        Vector3 pos = new Vector3(MyStick.anchoredPosition.x / 15f, MyStick.anchoredPosition.y / 17f, 10f);
        float dist = Vector3.Distance(transform.localPosition, pos);
        Vector3 tarPos = Vector3.MoveTowards(transform.localPosition, pos, dist * 10.0f * Time.deltaTime);

        if (tarPos.x > 6.4f) tarPos.x = 6.4f; 
        if (tarPos.x < -6.4f) tarPos.x = -6.4f;
        if (tarPos.y > 3.6f) tarPos.y = 3.6f;
        if (tarPos.y < -3.6f) tarPos.y = -3.6f;

        transform.localPosition = tarPos;
	}
}
