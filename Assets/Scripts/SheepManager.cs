using UnityEngine;
using System.Collections;

public class SheepManager : MonoBehaviour
{
	void Start()
	{
        StartCoroutine(CreateSheep());
	}

	IEnumerator CreateSheep()
	{
	    while (true)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (!transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    transform.GetChild(i).position = new Vector3(Random.Range(-6.0f, 6.0f), -0.96f, 18f);
                    transform.GetChild(i).gameObject.SetActive(true);
                    break;
                }
            }
            yield return new WaitForSeconds(2f);
        }
	}
}
