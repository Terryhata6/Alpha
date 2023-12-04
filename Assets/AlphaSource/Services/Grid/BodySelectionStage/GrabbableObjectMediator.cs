using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GrabbableObjectMediator : MonoBehaviour
{
    private Camera _camera;
    public Transform VisualTransform;
    [Space(10)]

    public Vector3 NewScale = new Vector3(1,1,1);
    public int TilesNumber;

    public int IdOb;

    public HashSet<BoostBagMediator> MyBoostHashSet = new HashSet<BoostBagMediator>();
    public HashSet<GrabbableObjectMediator> MediatorsNeighborObjects = new HashSet<GrabbableObjectMediator>();




    [HideInInspector] public bool CanBeSelected;
    [HideInInspector] public static bool _isGrabbing;
    [HideInInspector] public UnityEngine.Events.UnityEvent unityEvent_load_true;


    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Vector3 _startScale;
    private Vector3 _mOffset;

    private List<Tile> _collidedTiles = new List<Tile>();

    private int _availableTilesCount;

    private float _mZCoord;

    private bool _canBeDragged;

    private CustomGrid _customGrid;
    private BoostBagMediator _boostBagMediator;
    private InventoriMediator _inventoriMediator;
    private NeighborGrid _neighborGrid;

    private void Start()
    {
        unityEvent_load_true.AddListener(if_load_true);
        _customGrid = GetComponent<CustomGrid>();
        _boostBagMediator = GetComponent<BoostBagMediator>();
        _inventoriMediator = GetComponentInParent<InventoriMediator>();
        _neighborGrid = GetComponentInParent<NeighborGrid>();

        _camera = Camera.main;
        _isGrabbing = false;

        _startPosition = transform.position;
        _startRotation = transform.rotation;
        _startScale = VisualTransform.localScale;        
        _canBeDragged = true;

    }
    public void if_load_true()
    {
        Debug.Log(IdOb + " / canbe" );

        _canBeDragged = false;
        StartCoroutine(off_plane());
    }
    public void AddNeighborObjects(GrabbableObjectMediator grabbableObjectMediator)
    {
        MediatorsNeighborObjects.Add(grabbableObjectMediator);
    }  
    public void MinusNeighborObjects(GrabbableObjectMediator grabbableObjectMediator)
    {
        MediatorsNeighborObjects.Remove(grabbableObjectMediator);
    }


    IEnumerator off_plane()
    {
        yield return new WaitForSeconds(2f);
        yield return new WaitForFixedUpdate();

        for (int i = 0; i < _collidedTiles.Count; i++)
        {
            _collidedTiles[i]._isEmpty = false;
            _collidedTiles[i].OnChangeColor =true;
        }
    }

    private void Update()
    {
        if ( _collidedTiles.Count > 0)
        {
            if (_collidedTiles.Count == TilesNumber)
            {
                _availableTilesCount = 0;
                for (int i = 0; i < _collidedTiles.Count; i++)
                {
                    //_collidedTiles[i].GetComponentInChildren<SpriteRenderer>().color = Color.green;

                    if (_collidedTiles[i]._isEmpty && _collidedTiles[i].GetComponent<TowerTile>() != null)
                    {
                        _availableTilesCount++;
                    }
                }
                if (_availableTilesCount == TilesNumber)
                {
                    CanBeSelected = true;
                }
                else
                {
                    CanBeSelected = false;
                }
            }
            else
            {
                for (int i = 0; i < _collidedTiles.Count; i++)
                {
                    CanBeSelected = false;

                }
                CanBeSelected = false;

            }

        }
        else CanBeSelected = false;
    }

    private void OnMouseDown()
    {
        ResetPlain();
        if (_canBeDragged)
        {
            _isGrabbing = true;
            _customGrid.enabled = true;
            if (GetComponent<CustomGrid>() != null)
            {
                GetComponent<CustomGrid>().enabled = true;
            }


            VisualTransform.localScale = NewScale;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            _mZCoord = _camera.WorldToScreenPoint(gameObject.transform.position).z;
            _mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        }

    }

    private void OnMouseDrag()
    {

        transform.position = GetMouseAsWorldPoint() + _mOffset;
    }

    private void OnMouseUp()
    {
        if ( CanBeSelected)
        {
            VisualTransform.localScale = _startScale;
            SelectObject();
        }
        else
        {
            ResetObject();
        }

        if (GetComponent<CustomGrid>() != null)
        {
            GetComponent<CustomGrid>().enabled = false;
        }
        _isGrabbing = false;

        _customGrid.enabled = false;

    }


    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _mZCoord;
        return _camera.ScreenToWorldPoint(mousePoint);
    }


    private void SelectObject()
    {
        _canBeDragged = false;
        //transform.parent = null;
        Vector2 min = new Vector2(10, 10);
        Vector2 max = new Vector2(0, 0);
        for (int i = 0; i < _collidedTiles.Count; i++)
        {
            _collidedTiles[i].Disable += ResetObject;
            _collidedTiles[i].TileUse(this,_boostBagMediator);
            Vector2 cord = _collidedTiles[i].MyCoordinates();
            Debug.Log(min + " / " + cord);

            if (min.x > cord.x) min.x = cord.x;
            if (min.y > cord.y) min.y = cord.y;
            //if (max.x < cord.x || max.y < cord.y) max = cord;
        }
        if(_neighborGrid) _inventoriMediator.SearchObBost(min, _neighborGrid.checkboxArrayData, this);
            Debug.Log(min);
        
        foreach (var item in MediatorsNeighborObjects)
        {
            Debug.Log(item.gameObject.name);
        }
    }
    private void ResetObject()
    {
        ResetPlain();
        ResetNeighbor();
        MediatorsNeighborObjects.Clear();
        MyBoostHashSet.Clear();
        _collidedTiles.Clear();
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        VisualTransform.localScale = _startScale;
        CanBeSelected = false;
        _canBeDragged = true;
    }
    private void ResetNeighbor()
    {
        foreach (var item in MediatorsNeighborObjects)
        {
            item.MinusNeighborObjects(this);
        }
    }
    private void ResetPlain()
    {
        for (int i = 0; i < _collidedTiles.Count; i++)
        {
            _collidedTiles[i].Disable -= ResetObject;
            _collidedTiles[i].TileUnused(this);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        Tile tile = other.gameObject.GetComponent<Tile>();
        if (tile|| !_collidedTiles.Contains(tile))
        {
            _collidedTiles.Add(tile);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Tile tile = other.gameObject.GetComponent<Tile>();

        if (tile || _collidedTiles.Contains(tile))
        {
            _collidedTiles.Remove(tile);
        }
    }

}
