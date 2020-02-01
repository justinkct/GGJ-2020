using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float movementSpeed = 1;
    public Tilemap highlightMap;
    public Tilemap activeMap;
    public Tile highlightTile;
    public Tile dugTile;

    private Vector2Int dir;
    private Vector3Int targetTile;
    private Vector3Int previousTile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        targetTile = activeMap.WorldToCell(transform.position);
        targetTile.x += dir.x;
        targetTile.y += dir.y;
    }

    public void Highlight(bool check)
    {
        if (!check)
        {
            if (targetTile != previousTile)
            {
                highlightMap.SetTile(targetTile, highlightTile);
                highlightMap.SetTile(previousTile, null);
                previousTile = targetTile;
            }
        }
    }

    public void Dig()
    {
        TileBase selected = activeMap.GetTile(targetTile);
        if (selected != null)
            if (selected.name == "roguelikeDungeon_transparent_331")
            {
                GameManager.instance.AddMaterial();
            } 

        activeMap.SetTile(targetTile, dugTile);
        highlightMap.SetTile(previousTile, null);
    }

    public void SetDir(Vector2Int direction)
    {
        dir = direction;
    }
}
