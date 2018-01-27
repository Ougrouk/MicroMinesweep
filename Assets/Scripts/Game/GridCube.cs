using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCube : MonoBehaviour {

    #region Properties

    [Header("GridCube")]
    [SerializeField]
    private MeshRenderer meshRenderer;

    public float CubeSize = 1f;

    [SerializeField]
    private int mineValue = 0;
    public int MineValue {
        get { return this.mineValue; }
        set { this.mineValue = value; }
    }

    private Vector2 gridPos;
    public Vector2 GridPos {
        get { return this.gridPos; }
    }

    [SerializeField]
    private CubeValueInfo cubeValueInfoPrefab;

    private CubeValueInfo cubeValueInfo;
    public CubeValueInfo CubeValueInfo {
        get { return this.cubeValueInfo; }
    }

    #endregion

    public void SetGridPosition(Vector2 gridPos, int mineValue) {
        this.gridPos = gridPos;
        this.mineValue = mineValue;

        this.InstantiateGridValueInfo();

    }

    private void InstantiateGridValueInfo() {

        CubeValueInfo cubeValue = GameObject.Instantiate<CubeValueInfo>(this.cubeValueInfoPrefab);

        cubeValue.RT.SetParent(GameManager.Instance.CubeValueInfoParent);
        cubeValue.SetCubeToFollow(this);

    }

}
