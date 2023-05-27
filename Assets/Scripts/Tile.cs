using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    [SerializeField] private GameObject xImage;
    public int x, y;

    private bool _occupied;
    public bool occupied {
        set {
            _occupied = value;
            xImage.SetActive(value);
        }
        get {
            return _occupied;
        }
    }

    public void Ping() {
        if (occupied)
            return;
        occupied = true;
        PuzzleManager.instance.Ping(this);
    }

}
