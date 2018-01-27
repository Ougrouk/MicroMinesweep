using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeValueInfo : MonoBehaviour {

    #region Properties

    [Header("CubeValueInfo")]
    [SerializeField]
    private Text valueText;

    private Transform transformToFollow;

    private int valueToDisplay;

    private RectTransform rt = null;
    public RectTransform RT {
        get {

            if (this.rt == null) {
                this.rt = this.GetComponent<RectTransform>();
            }

            return this.rt;
        }
    }

    private float yOffset = 0f;

    #endregion

    public void SetCubeToFollow(GridCube cube) {

        this.valueToDisplay = cube.MineValue;
        this.transformToFollow = cube.transform;

        // Display the cube value at all time
        this.valueText.text = this.valueToDisplay.ToString();

    }

    public void Update()
    {

        if (this.transformToFollow != null) {

            Vector3 worldPos = new Vector3(this.transformToFollow.position.x, this.transformToFollow.position.y + this.yOffset, this.transformToFollow.position.z);
            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
            this.RT.position = screenPos;

        }

    }

}
