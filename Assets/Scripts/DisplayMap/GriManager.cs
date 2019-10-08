using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriManager : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private GameObject SpriteGrid;

    private GameObject[,] _sprites;
    // Start is called before the first frame update
    void Start()
    {
        BuildGrid();
    }


    public void BuildGrid()
    {
        _sprites = new GameObject[size, size];
        
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                _sprites[i, j] = Instantiate(SpriteGrid,this.transform);
                _sprites[i, j].transform.position = new Vector2( j, i );
            }    
        }
    }
}
