using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    [SerializeField] BuildingsController buildingsController;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 2500);

            if (hit.collider != null)
            {
                buildingsController.ClickOnBuilding(hit.collider.gameObject.name);
            }
        }   
    }
}
