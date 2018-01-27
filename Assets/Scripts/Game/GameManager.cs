using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    #region Singleton

    private static GameManager instance;
    public static GameManager Instance {
        get { return GameManager.instance; }
    }

    private void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);

        }
        else {
            GameObject.Destroy(this);
        }
    }

    [SerializeField]
    private MineGrid mineGrid;

    [SerializeField]
    private RectTransform cubeValueInfoParent;
    public RectTransform CubeValueInfoParent {
        get { return this.cubeValueInfoParent; }
    }

    #endregion

    #region Properties


    public void Start()
    {

        this.mineGrid.GenerateGrid();

    }


    #endregion

}
