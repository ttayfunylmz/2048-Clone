using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public TileStateSO tileState { get; private set; }
    public Cell cell { get; private set; }
    public int number { get; private set; }
    public bool isLocked { get; set; }

    [SerializeField] private Image backgroundImage;
    [SerializeField] private TMP_Text numberText;

    public void SetState(TileStateSO tileState, int number)
    {
        this.tileState = tileState;
        this.number = number;

        backgroundImage.color = tileState.backgroundColor;
        numberText.color = tileState.textColor;
        numberText.text = number.ToString();
    }

    public void SpawnTile(Cell cell)
    {
        if(this.cell != null)
        {
            this.cell.tile = null;
        }

        this.cell = cell;
        this.cell.tile = this;

        transform.position = cell.transform.position;
    }

    public void MoveTo(Cell cell)
    {
        if(this.cell != null)
        {
            this.cell.tile = null;
        }

        this.cell = cell;
        this.cell.tile = this;

        StartCoroutine(Animate(cell.transform.position, false));
    }

    public void Merge(Cell cell)
    {
        if(this.cell != null)
        {
            this.cell.tile = null;
        }

        this.cell = null;
        cell.tile.isLocked = true;

        StartCoroutine(Animate(cell.transform.position, true));
    }

    private IEnumerator Animate(Vector3 to, bool isMerging)
    {
        float elapsed = 0f;
        float duration = 0.1f;

        Vector3 from = transform.position;

        while(elapsed < duration)
        {
            transform.position = Vector3.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = to;

        if(isMerging)
        {
            Destroy(this.gameObject);
        }
    }
}
