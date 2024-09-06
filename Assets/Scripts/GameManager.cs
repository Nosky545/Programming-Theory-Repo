using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Camera GameCamera;
    private GameObject Marker;
    private TextMeshProUGUI textDisplay;
    private GameObject textSelect;
    private Shape m_Selected = null;

    private void Awake()
    {
        GameCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Marker = GameObject.Find("Marker");
        textDisplay = GameObject.Find("Text Display").GetComponent<TextMeshProUGUI>();
        textSelect = GameObject.Find("Select Text");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleSelection(); //ABSTRACTION
        }

        MarkerHandling(); //ABSTRACTION
    }

    void HandleSelection()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var shape = hit.collider.GetComponentInParent<Shape>();
                m_Selected = shape;
                textDisplay.text = $"Type: {shape.Type} Color: {shape.Color} Size: {shape.Size}";
                textSelect.SetActive(false);
            }
            
            else
            {
                textSelect.SetActive(true);
                textDisplay.text = "Type: Color: Size: ";
                m_Selected = null;
            }
    }

    void MarkerHandling()
    {
        if (m_Selected == null && Marker.activeInHierarchy)
        {
            Marker.SetActive(false);
            Marker.transform.SetParent(null);
        }
        else if (m_Selected != null && Marker.transform.parent != m_Selected.transform)
        {
            Marker.SetActive(true);
            Marker.transform.SetParent(m_Selected.transform, false);
            Marker.transform.localPosition = new(0, 1.5f, 0);
            Marker.transform.localScale = new Vector3(0.15f, 1, 1);
        }    
    }
}
