using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMasterHand : FSM
{
    private GoldenBrickManager brickManager;
    private CameraMovement cam;
    private State state;

    private enum State {
        MOVE_CAM_TO_TARGET, // camera moves to golden brick
        RELOCATE, // relocate golden brick
        MOVE_CAM_TO_NEW_TARGET, // camera moves to new locations
    }

    public TileMasterHand(GoldenBrickManager brickManagerPara, CameraMovement camera) {
        brickManager = brickManagerPara;
        cam = camera;
        state = State.MOVE_CAM_TO_TARGET;
        cam.moveToGoldenBrick();
    }

    override public bool update() {
        switch (state)
        {
            case State.MOVE_CAM_TO_TARGET:
                if (cam.movementCompleted()) {
                    state = State.RELOCATE;
                    cam.moveToGoldenBrick();
                }
                break;
            case State.RELOCATE:
                state = State.MOVE_CAM_TO_NEW_TARGET;
                brickManager.relocate();
                cam.moveToGoldenBrick();
                break;
            case State.MOVE_CAM_TO_NEW_TARGET:
                if (cam.movementCompleted()) {
                    return true;
                }
                break;
        }
        return false;
    }
}
