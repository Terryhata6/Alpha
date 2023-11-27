using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventoriMediator : MonoBehaviour
{
    public GridManager[] GridManagers;
    // to do тут має юути ініціалізація з класу що буде зверху по ієрархії
    private void Awake()
    {
        GridManagers = GetComponentsInChildren<GridManager>();
        foreach (var item in GridManagers)
        {
            item.Init(this);
        }
    }
    public void ActivationDeactivationTile(Vector2 tileCoordinates, bool actOrDeact, BoostBagMediator boostBagMediator)
    {
        GridManagers[0].ActivationDeactivationTile(tileCoordinates, actOrDeact,boostBagMediator);
    }
    public void SearchObBost(Vector2 min, Vector2 max, GrabbableObjectMediator  grabbableObjectMediators)
    {
        GridManagers[0].SearchBostInTiles(min, max, grabbableObjectMediators);
    }


}
