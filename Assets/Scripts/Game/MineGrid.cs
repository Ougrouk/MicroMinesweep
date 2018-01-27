using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineGrid : MonoBehaviour {

    #region Properties

    [Header("MineGrid")]


    [SerializeField]
    private List<int> grid1 = new List<int>();
    [SerializeField]
    private List<int> grid2 = new List<int>();
    [SerializeField]
    private List<int> grid3 = new List<int>();
    [SerializeField]
    private List<int> grid4 = new List<int>();
    [SerializeField]
    private List<int> grid5 = new List<int>();
    [SerializeField]
    private List<int> grid6 = new List<int>();

    [Space(10)]
    [SerializeField]
    private List<List<int>> gridArray = new List<List<int>>();
    public List<List<int>> GridArray {
        get { return this.gridArray; }
    }

    [SerializeField]
    private GridCube gridCubePrefab;

    private List<List<GridCube>> cubeGrid = new List<List<GridCube>>();
    
    [SerializeField]
    private Transform GridParent;

    private int zCoordinate = 0; 

    #endregion

    public void GenerateGrid() {

        this.gridArray.Add(this.grid1);
        this.gridArray.Add(this.grid2);
        this.gridArray.Add(this.grid3);
        this.gridArray.Add(this.grid4);
        this.gridArray.Add(this.grid5);
        this.gridArray.Add(this.grid6);


        this.cubeGrid.Clear();

        // For every line in the grid
        for(int y=0; y< this.gridArray.Count; ++y)
        {
            List<int> lineValue = this.gridArray[y];

            List<GridCube> cubeLine = new List<GridCube>();
            this.cubeGrid.Add(cubeLine);

            // Instantiate every cube in the line
            for (int x = 0; x < lineValue.Count; ++x) {

                GridCube cube = GameObject.Instantiate<GridCube>(this.gridCubePrefab);

                cube.transform.SetParent(this.GridParent);
                cube.transform.localPosition = new Vector3(cube.CubeSize * x, cube.CubeSize * y, this.zCoordinate);

                cube.SetGridPosition(new Vector2(x, y), this.gridArray[y][x]);

                cubeLine.Add(cube);

            }

        }
    }

    public GridCube GetCube(int x, int y) {
        GridCube cube = null;
        
        if(y >=0 && y < this.cubeGrid.Count)
        {
            List<GridCube> cubeLine = this.cubeGrid[y];

            if (x >= 0 && x < cubeLine.Count) {
                cube = cubeLine[x];
            }
        }

        return cube;
    }

}
