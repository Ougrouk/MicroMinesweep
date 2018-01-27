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

    private bool isRevealed = false;
    public bool IsRevealed {
        get { return this.isRevealed; }
    }

    #endregion

    /// <summary>
    /// Init the cube in the grid
    /// </summary>
    public void SetGridPosition(Vector2 gridPos, int mineValue) {
        this.gridPos = gridPos;
        this.mineValue = mineValue;

        this.InstantiateGridValueInfo();

        // Cube are hidden by default
        this.HideCube();

    }

    private void InstantiateGridValueInfo() {

        CubeValueInfo cubeValue = GameObject.Instantiate<CubeValueInfo>(this.cubeValueInfoPrefab);

        cubeValue.RT.SetParent(GameManager.Instance.CubeValueInfoParent);
        cubeValue.SetCubeToFollow(this);

    }

    public void OnMouseDown()
    {
#if USELOG
        Debug.Log("GridCube.OnMouseDown - GridCube clicked : "+this.GridPos.ToString()+", mineValue : "+this.MineValue);
#endif

        GameManager.Instance.CurrentMineGrid.RevealCube(this.GridPos);

    }

    public void HideCube() {

        this.meshRenderer.material.color = Color.red;

        this.isRevealed = false;

        // TODO : Hide value info

    }

    public void RevealCube()
    {
        this.meshRenderer.material.color = Color.blue;

        this.isRevealed = true;

        // TODO : Reveal value info



    }

}
