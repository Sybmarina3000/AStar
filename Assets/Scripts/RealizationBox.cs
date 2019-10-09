using DisplayMap;
using Map;
using UnityEngine;
using WayAlgorithm;

public class RealizationBox : Singleton<RealizationBox>
{
    [SerializeField] private GridMap _Map;
    [SerializeField] private GridMapEditor _Grigmanager;
    [SerializeField] private A_Star AlgoritmSearchWay;

    public IMap Map => _Map;
    public IMapEditor MapEditor => _Grigmanager;
    public ISearchWayAlgorithm SearchWayAlgorithm => AlgoritmSearchWay;

}
