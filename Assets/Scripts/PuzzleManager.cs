using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    // Singleton for GridManager and Tiles to access
    public static PuzzleManager instance;

    private List<Tile> tiles;
    private List<Tile> foundTiles = new List<Tile>();


    private void Awake() {
        // Singleton for GridManager and Tiles to access
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Set tiles from GridManager when new grid is created
    public void SetTiles(List<Tile> newTiles) => tiles = newTiles;


    // Ping coming from tile to Mark tile and check for^end situation
    public void Ping(Tile tile) {
        foundTiles.Clear();
        CheckAllDirections(tile);

        // If more than 2 tiles are adjacent, pop them
        if(foundTiles.Count >= 3) {
            for (int i = 0;i < foundTiles.Count;i++) {
                foundTiles[i].occupied = false;
            }
        }
    }


    // Check all directions recursively while marking found tiles to fountTiles list
    private void CheckAllDirections(Tile tile) {
        // Mark current tile as found
        foundTiles.Add(tile);
        Tile foundTile;

        // Check up-down-left-right tile, if exists check if occupied, if occupied check if recursive already checked it, if not recursively go to that tile
        if ((foundTile = FoundTile(tile.x + 1, tile.y)) != null && foundTile.occupied && !foundTiles.Contains(foundTile)) {
            CheckAllDirections(foundTile);
        }
        if ((foundTile = FoundTile(tile.x - 1, tile.y)) != null && foundTile.occupied && !foundTiles.Contains(foundTile)) {
            CheckAllDirections(foundTile);
        }
        if ((foundTile = FoundTile(tile.x, tile.y - 1)) != null && foundTile.occupied && !foundTiles.Contains(foundTile)) {
            CheckAllDirections(foundTile);
        }
        if ((foundTile = FoundTile(tile.x, tile.y + 1)) != null && foundTile.occupied && !foundTiles.Contains(foundTile)) {
            CheckAllDirections(foundTile);
        }
    }

    // Use Linq query to find tile, if x or y is out of bound then return null
    private Tile FoundTile(int x, int y) => tiles.Find(listTile => listTile.x == x && listTile.y == y);

}
