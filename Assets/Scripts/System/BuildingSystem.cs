using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject carryingBlock;
    private void FixedUpdate() {

        if(PlayerBuildController.current.IsCarryingBlock()){
            
        }

    }
}