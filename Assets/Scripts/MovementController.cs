using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private LayerMask walkableLayer;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit hitInfo;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.farClipPlane;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            if (Physics.Raycast(Camera.main.transform.position, worldPos, out hitInfo, 500f, walkableLayer))
            {
                player.SetDestination(hitInfo.point);
            }
        }
    }
}
