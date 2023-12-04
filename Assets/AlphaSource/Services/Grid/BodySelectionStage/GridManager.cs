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
    public void SearchBostInTiles(Vector2 min, CheckboxArrayData checkboxArrayData, GrabbableObjectMediator grabbableObjectMediators)
    {

        int xMin = (Mathf.RoundToInt(min.x)-1);        
        int yMin = (Mathf.RoundToInt(min.y)-1);

        for (int x = 0; x < checkboxArrayData.Width; x++)
        {
            for (int y = 0; y < checkboxArrayData.Height; y++)
            {
                if(checkboxArrayData.checkboxStates[x, y].isChecked) AddMediator(grabbableObjectMediators, x+xMin, y+yMin);
            }
        }
    }
    public void AddMediator(GrabbableObjectMediator grabbableObjectMediator, int x,int y)
    {
        Debug.Log(x + " / "+ y + " / " + 0);
        if (x >= 0 && y >= 0 && x < Width && y < Height)
        {
            _databaseTile[x, y]._spriteRenderer.color = _databaseTile[x, y].RedColor;
            GrabbableObjectMediator neighborGrabbable = _databaseTile[x, y].GrabbableObjectMediator;
            if (neighborGrabbable)
            {
                neighborGrabbable.AddNeighborObjects(grabbableObjectMediator);
                grabbableObjectMediator.AddNeighborObjects(neighborGrabbable);
            }
        }

    }
}
