using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class WallBuilder : MonoBehaviour
{
    [SerializeField] private List<Pillar> _pillars;
    [SerializeField] private GameObject _wall;

    private GameObject _newWall;
    private bool IsGenerateWall = false;

    private void Update()
    {
        BuildWalls(_pillars[0], _pillars[1]);
        DestroyWall(_pillars[0], _pillars[1]);
    }

    private void BuildWalls(Pillar from, Pillar to)
    {
        if (from.IsActice && to.IsActice && IsGenerateWall == false)
        {
            _newWall = Instantiate(_wall, from.transform.position, Quaternion.identity);
            IsGenerateWall = true;
        }

        if (_newWall != null)
        {
            _newWall.transform.position = _pillars[0].transform.position;
            _newWall.transform.rotation = Quaternion.LookRotation(to.transform.position);
        }
    }
    private float CalculateDistancePillars(Pillar from, Pillar to)
    {
        return Vector3.Distance(from.transform.position, to.transform.position);
    }

    private void DestroyWall(Pillar flom, Pillar to)
    {
        if (flom.IsActice == false)
        {
            Destroy(_newWall);
            IsGenerateWall = false;
        }
    }
}
