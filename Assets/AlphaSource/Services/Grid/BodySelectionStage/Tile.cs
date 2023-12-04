using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //public Color BaseColor;
    public Color GreenColor;
    public Color RedColor;
    //public Color GrayColor;
    public bool OnChangeColor = false;

    public SpriteRenderer _spriteRenderer;

    public event Action Disable;
    public event Action<bool, BoostBagMediator> UseUnused;

    [HideInInspector] public bool _isEmpty = true;

    private Vector2 _myCoordinates;
    private GrabbableObjectMediator _grabbableObjectMediator; 
    public GrabbableObjectMediator GrabbableObjectMediator { get { return _grabbableObjectMediator; } }

    private TileBag _tileBag;
    private BoostBagMediator _boostBagMediator;
    public void Init(Vector2 myCoordinates, InventoriMediator inventoriMediator)
    {
        _myCoordinates = myCoordinates;
        _tileBag = GetComponent<TileBag>();
        _tileBag?.Init(this, inventoriMediator);
    }

    public Vector2 MyCoordinates() => _myCoordinates;
    public GrabbableObjectMediator MyOb()
    {
        if (_grabbableObjectMediator) return _grabbableObjectMediator;
        else return null;
    }
    public void ActDeactMy(bool actDeact, BoostBagMediator boostBagMediator)
    {
        _boostBagMediator = boostBagMediator;
        gameObject.SetActive(actDeact);
        if (!actDeact)
        {
            Debug.Log(Disable);
            Disable?.Invoke();
        }
    }
    public void TileUse(GrabbableObjectMediator grabbableObjectMediator, BoostBagMediator boostBagMediator)
    {
        _grabbableObjectMediator = grabbableObjectMediator;
        //_spriteRenderer.color = GreenColor;
        OnChangeColor = true;
        _isEmpty = false;
        if(_boostBagMediator!=null) _grabbableObjectMediator.MyBoostHashSet.Add(_boostBagMediator);
        UseUnused?.Invoke(true, boostBagMediator);
    }   
    public void TileUnused(GrabbableObjectMediator grabbableObjectMediator)
    {
        if(_grabbableObjectMediator == grabbableObjectMediator)
        {
            _grabbableObjectMediator = null;
            OnChangeColor = false;
            _isEmpty = true;
            UseUnused?.Invoke(false,null);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<GrabbableObjectMediator>() != null)
        {
            //if(OnChangeColor == false)            _spriteRenderer.color = BaseColor;
            //else _spriteRenderer.color = GreenColor;
        }
    }
}
