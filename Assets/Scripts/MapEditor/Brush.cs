using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ETypeBrush
{
    passable,
    impassable,
    start,
    finish,
}

public class Brush : Singleton<Brush>
{
    [SerializeField] private ETypeBrush _Brush;
    public ETypeBrush CurrentBrush {
        get { return _Brush; }
        private set { _Brush = value; }
    }

    private Dictionary<ETypeBrush, Color> _brushColor;
    public Color GetCurrentColor() => _brushColor[_Brush];
    
    public Color GetImpassableColor() => _brushColor[ETypeBrush.impassable];
    public Color GetPassableColor() => _brushColor[ETypeBrush.passable];
    
    
    // Start is called before the first frame update
    void Start()
    {
        _brushColor = new Dictionary<ETypeBrush, Color>();
        _brushColor[ETypeBrush.passable] = Color.white;
        _brushColor[ETypeBrush.impassable] = Color.gray;
        _brushColor[ETypeBrush.start] = Color.green;
        _brushColor[ETypeBrush.finish] = Color.red;
        
        CurrentBrush = ETypeBrush.impassable;
    }
    
    public void ChangeBrush(ETypeBrush newBrush)
    {
        CurrentBrush = newBrush;
    }
    
    public void ChangeBrush(int newBrush)
    {
        CurrentBrush = (ETypeBrush)newBrush;
    }

 

}
