using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{

    [Header("Transform")]
    [SerializeField] private RectTransform gridTransform;
    [SerializeField] private RectTransform canvasTransform;


    [Header("Prefab")]
    [SerializeField] private Tile tilePrefab;

    [Header("Puzzle Manager")]
    [SerializeField] private PuzzleManager puzzleManager;

    [Header("Slider")]
    [SerializeField] private Slider nSlider;
    [SerializeField] private TextMeshProUGUI nText;


    public void Grid() {
        DestroyGrid();
        CreateGrid();
    }

    // Destroy current grid tiles if exists
    private void DestroyGrid() {
        for (int i = gridTransform.childCount - 1;i >= 0 ;i--) {
            Destroy(gridTransform.GetChild(i).gameObject);
        }
    }


    // Create grid with slider value
    private void CreateGrid() {
        int n = (int)nSlider.value;

        // Size uses 9/10 of screen. Canvas transform expands according to screen resolution.
        // So i use smallest value between height and width and use 9/10 of that value as grid size
        float size = (canvasTransform.rect.width < canvasTransform.rect.height) ? (canvasTransform.rect.width * 7 / 10) : (canvasTransform.rect.height * 7 / 10);

        // New grid size
        gridTransform.sizeDelta = new Vector2(size, size);

        GridLayoutGroup gridLayout = gridTransform.GetComponent<GridLayoutGroup>();

        float cellSize = size / n;

        // Cell size automatically resizes all cells inside tile sizes because it has gridLayout
        gridLayout.cellSize = new Vector2(cellSize, cellSize);

        List<Tile> tiles = new List<Tile>();

        for (int i = n - 1;i >= 0;--i) {
            for (int j = 0;j < n;j++) {
                tiles.Add(Instantiate(tilePrefab, gridTransform));
                tiles[tiles.Count - 1].y = i;
                tiles[tiles.Count - 1].x = j;
            }
        }

        // Set tiles of puzzle manager
        puzzleManager.SetTiles(tiles);
    }

    public void OnSliderValueChanged() => nText.text = nSlider.value.ToString();
}
