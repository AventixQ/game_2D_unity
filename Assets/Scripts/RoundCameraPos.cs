using UnityEngine;
using Cinemachine;

public class RoundCameraPos : CinemachineExtension
{
    public float PixelsPerUnit = 32;
    protected override void PostPipelineStageCallback( CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage,
        ref CameraState state, float deltaTime){
        //check if it is a Body stage, if so, it sets the camera to a certain place in the scene
        if (stage == CinemachineCore.Stage.Body){
            //reading the camera position
            Vector3 pos = state.FinalPosition;
            //creating new position of the camera
            Vector3 pos2 = new Vector3(Round(pos.x), Round(pos.y), pos.z); 
            //correction of position
            state.PositionCorrection += pos2 - pos;
        }
    }
    //rounds the given value
    float Round(float x){
        return Mathf.Round(x * PixelsPerUnit) / PixelsPerUnit;
    }
}