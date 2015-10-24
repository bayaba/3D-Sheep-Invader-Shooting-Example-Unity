using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    void SetTarget(Vector3 pos) // when shoot bomb, call from BombManager.cs
    {
        LeanTween.move(gameObject, pos, 0.5f).setOnComplete(Hide); // bomb move to pos, call Hide() when it complete
    }

    void Hide()
    {
        LeanTween.cancel(gameObject);
        gameObject.SetActive(false); // disable object
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Sheep") // collision with sheep?
        {
            col.SendMessage("HitSheep"); // hit the sheep
            Hide(); // remove bomb
        }
    }
}
