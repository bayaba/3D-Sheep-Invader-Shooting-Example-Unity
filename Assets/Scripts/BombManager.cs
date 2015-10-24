using UnityEngine;
using System.Collections;

public class BombManager : MonoBehaviour
{
    public Transform Cannon;
    Camera UICam;
    GameObject cross;

    void Start()
    {
        UICam = GameObject.Find("UICamera").GetComponent<Camera>();
        cross = GameObject.Find("UICamera/CrossPoint");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) CreateBomb(); // push space to attack
    }

    void CreateBomb()
    {
        for (int i = 0; i < transform.childCount; i++) // object pooling
        {
            if (!transform.GetChild(i).gameObject.activeInHierarchy)
            {
                transform.GetChild(i).localPosition = Cannon.position; // bomb move to cannon's position
                transform.GetChild(i).gameObject.SetActive(true); // active bomb
                Bomb bomb = GetComponent<Bomb>();

                Vector3 tarpos = Camera.main.ScreenToWorldPoint(UICam.WorldToScreenPoint(cross.transform.position));

                Vector3 pos = GetSheepPosition();
                if (pos != Vector3.zero) tarpos= pos;
                transform.GetChild(i).SendMessage("SetTarget", tarpos);
                break;
            }
        }
    }

    Vector3 GetSheepPosition()
    {
        Vector3 result = Vector3.zero;

        RaycastHit hit;
        Vector3 tarpos = UICam.WorldToScreenPoint(cross.transform.position);
        tarpos.z = 0f;
        Ray ray = Camera.main.ScreenPointToRay(tarpos);

        if (Physics.Raycast(ray, out hit, 10f))
        {
            if (hit.collider.name == "Sheep")
            {
                SheepMove sheep = hit.collider.GetComponent<SheepMove>();
                if (!sheep.isDead) result = hit.point;
            }
        }
        return result;
    }
}
