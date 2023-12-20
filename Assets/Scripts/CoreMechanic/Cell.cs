using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int coordinates { get; set; }
    public Tile tile { get; set; }

    public bool isEmpty => tile == null;
    public bool isOccupied => tile != null;



}
