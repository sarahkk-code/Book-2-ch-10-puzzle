using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    void Start()
    {
        int dropdownValue = PlayerPrefs.GetInt("PuzzlePieces", 0);

        int selectedPieces;

        if (dropdownValue == 0)
            selectedPieces = 9;
        else if (dropdownValue == 1)
            selectedPieces = 16;
        else
            selectedPieces = 25;

        // Show only the selected number of pieces
        for (int i = 1; i <= 25; i++)
        {
            GameObject piece = GameObject.Find("Piece" + i);

            if (piece != null)
            {
                piece.SetActive(i <= selectedPieces);
            }
        }

        // Scramble the visible pieces
        for (int i = 1; i <= selectedPieces; i++)
        {
            GameObject piece = GameObject.Find("Piece" + i);

            if (piece != null)
            {
                RectTransform rect = piece.GetComponent<RectTransform>();

                float x = Random.Range(-450f, 450f);
                float y = Random.Range(-300f, 300f);

                rect.anchoredPosition = new Vector2(x, y);
            }
        }
    }
}