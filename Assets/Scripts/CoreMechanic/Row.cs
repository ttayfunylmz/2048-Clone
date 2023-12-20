using UnityEngine;

public class Row : MonoBehaviour
{
    public Cell[] cells { get; private set; }

    private void Awake() 
    {
        cells = GetComponentsInChildren<Cell>();
    }
}
