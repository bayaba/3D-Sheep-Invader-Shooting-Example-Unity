﻿using UnityEngine;
using System.Collections;

public class GlassManager : MonoBehaviour
{
	void CreateGlass(Vector3 pos)
	{
        for (int i = 0; i < transform.childCount; i++)
        {
            if (!transform.GetChild(i).gameObject.activeInHierarchy)
            {
                transform.GetChild(i).position = pos;
                transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }
    }
}
