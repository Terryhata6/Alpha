using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBag : MonoBehaviour
{
    private InventoriMediator _inventoriMediator;
    private Tile _tile;
    internal void Init(Tile tile, InventoriMediator inventoriMediator)
    {
        _inventoriMediator = inventoriMediator;
        _tile = tile;
        tile.UseUnused += ActDeactTile;
    }
    public void ActDeactTile(bool t, BoostBagMediator boostBagMediator)
    {
        Vector2 result = _tile.MyCoordinates();
        _inventoriMediator.ActivationDeactivationTile(result, t, boostBagMediator);
    }
}
