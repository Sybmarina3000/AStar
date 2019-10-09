using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class AbstractIMapItem :  IMapItem
{
    public virtual IMapItem Last { get; set; }
    public virtual int Cost { get; set; }
    public virtual Vector2Int Position { get; set; }
    public virtual bool IsPassable { get; set; }
}
