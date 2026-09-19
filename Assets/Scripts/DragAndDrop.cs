using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 correctPosition;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        GameObject board = GameObject.Find("PuzzleBoard");

        if (board == null)
        {
            Debug.LogError("PuzzleBoard was not found!");
            return;
        }

        RectTransform boardRect = board.GetComponent<RectTransform>();

        int pieceNumber = int.Parse(gameObject.name.Replace("Piece", ""));

        // Our current puzzle is the 5 x 5 version
        int gridSize = 5;

        int column = (pieceNumber - 1) % gridSize;
        int row = (pieceNumber - 1) / gridSize;

        float spacingX = 100f;
        float spacingY = 150f;

        float startX = -200f;
        float startY = 300f;

        correctPosition = boardRect.anchoredPosition + new Vector2(
            startX + column * spacingX,
            startY - row * spacingY
        );
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float distance = Vector2.Distance(
            rectTransform.anchoredPosition,
            correctPosition
        );

        if (distance < 75f)
        {
            rectTransform.anchoredPosition = correctPosition;
        }
    }
}