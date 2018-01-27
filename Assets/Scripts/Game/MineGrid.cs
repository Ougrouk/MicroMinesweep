using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineGrid : MonoBehaviour {

    #region Properties

    [Header("MineGrid")]
    [SerializeField]
    private List<List<int>> gridArray = new List<List<int>>();
    public List<List<int>> GridArray {
        get { return this.gridArray; }
    }


    #endregion
}
