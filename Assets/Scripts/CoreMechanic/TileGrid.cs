using UnityEngine;

public class TileGrid : MonoBehaviour
{
    public Row[] rows { get; private set; }
    public Cell[] cells { get; private set; }

    [SerializeField] private int size => cells.Length;
    [SerializeField] private int height => rows.Length;
    [SerializeField] private int width => size / height;

    private void Awake() 
    {
        rows = GetComponentsInChildren<Row>();
        cells = GetComponentsInChildren<Cell>();
    }

    private void Start() 
    {
        //Y EKSENİ
        for (int i = 0; i < rows.Length; ++i)
        {
            //X EKSENİ
            for (int j = 0; j < rows[i].cells.Length; ++j)
            {
                rows[i].cells[j].coordinates = new Vector2Int(j, i);
            }
        }
    }


    public Cell GetRandomEmptyCell()
    {
        int index = Random.Range(0, cells.Length);
        int startingIndex = index;

        while(cells[index].isOccupied)
        {
            index++;
            if (index >= cells.Length) { index = 0; }

            if(index == startingIndex)
            {
                return null;
            }
        }

        return cells[index];
    }

    public Cell GetCell(int x, int y)
    {
        if(x >= 0 && x < width && y >= 0 && y < height)
        {
            return rows[y].cells[x];
        }
        else
        {
            return null;
        }
    }

    public Cell GetAdjacentCell(Cell cell, Vector2Int direction)
    {
        Vector2Int coordinates = cell.coordinates;
        coordinates.x += direction.x;
        coordinates.y -= direction.y;

        return GetCell(coordinates.x, coordinates.y);
    }

    public int GetHeight()
    {
        return height;
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetSize()
    {
        return size;
    }
}
