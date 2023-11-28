using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GridManager : MonoBehaviour
{
    public int Width;
    public int Height;
    private Tile[,] _databaseTile; 
    [Space(5)]

    [SerializeField] private Tile tilePrefab_1;

    internal void Init(InventoriMediator inventoriMediator)
    {
        _databaseTile = new Tile[Width, Height];
        CreateGrid(inventoriMediator);
    }
    private void CreateGrid(InventoriMediator inventoriMediator)
    {

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                var spawnedTile = Instantiate(tilePrefab_1, new Vector3(x, y+1,0.5f), Quaternion.identity, transform);
                spawnedTile.name = $"Tile {x} {y+1}";
                spawnedTile.Init(new Vector2(x, y), inventoriMediator);
                _databaseTile[x, y] = spawnedTile;
            }
        }

    }

    public void ActivationDeactivationTile(Vector2 tileCoordinates, bool actOrDeact, BoostBagMediator boostBagMediator)
    {
        _databaseTile[Mathf.RoundToInt(tileCoordinates.x), Mathf.RoundToInt(tileCoordinates.y)].ActDeactMy(actOrDeact,boostBagMediator);
    }
    public void SearchBostInTiles(Vector2 min, Vector2 max, GrabbableObjectMediator grabbableObjectMediators)
    {
        Debug.Log(min + " / " + max + " / min" + 0);

        int xMin = Mathf.Clamp(Mathf.RoundToInt(min.x) - 1, 0, Width-1);        
        int xMax = Mathf.Clamp(Mathf.RoundToInt(max.x) + 1, 0, Width-1);
        int yMin = Mathf.Clamp(Mathf.RoundToInt(min.y) - 1, 0, Height-1);
        int yMax = Mathf.Clamp(Mathf.RoundToInt(max.y) + 1, 0, Height-1);

        for (int i = xMin; i <= xMax; i++)
        {
            if (yMin != min.y) AddMediator(grabbableObjectMediators, i, yMin);
            if (yMax != max.y) AddMediator(grabbableObjectMediators, i, yMax);
        }  
        for (int i = yMin; i <= yMax; i++)
        {
            if (xMin != min.x) AddMediator(grabbableObjectMediators, xMin,i );
            if (xMax != max.x) AddMediator(grabbableObjectMediators, xMax,i );
        }
    }
    public void AddMediator(GrabbableObjectMediator grabbableObjectMediator, int x,int y)
    {
        Debug.Log(x + " / "+ y + " / " + 0);
        _databaseTile[x, y]._spriteRenderer.color = _databaseTile[x, y].RedColor;
        GrabbableObjectMediator neighborGrabbable = _databaseTile[x, y].GrabbableObjectMediator;
        if (neighborGrabbable)
        {
            neighborGrabbable.AddNeighborObjects(grabbableObjectMediator);
            grabbableObjectMediator.AddNeighborObjects(neighborGrabbable);
        }
    }
}
