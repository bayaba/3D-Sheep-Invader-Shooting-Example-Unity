using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour
{
    public float Delay;

    void OnEnable()
    {
        Invoke("Hide", Delay);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}
