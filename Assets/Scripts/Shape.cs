using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    // ENCAPSULATION
    
    public string Type { get; set; }
    public string Color { get; set; }
    public string Size { get; set; }
}
