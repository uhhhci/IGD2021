using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public GameObject goal;

    public Transform leftCylinder;
    public Transform rightCylinder;

    public void MoveGoal(float movement)
    {
        goal.transform.localPosition = goal.transform.localPosition + new Vector3(0, 0, movement);
    }

    public void ActivateGoal()
    {
        goal.SetActive(true);
    }

    public Vector3 GetGoalPosition()
    {
        return goal.transform.position;
    }

    public void SetGoalPosition(Vector3 pos) 
    {
        goal.transform.position = pos;
    }

    public float GetUpperExtremeX()
    {
        return leftCylinder.position.x < rightCylinder.position.x? leftCylinder.position.x : rightCylinder.position.x;
    }
    public float GetLowerExtremeX()
    {
        return leftCylinder.position.x >= rightCylinder.position.x? leftCylinder.position.x : rightCylinder.position.x;
    }
}
