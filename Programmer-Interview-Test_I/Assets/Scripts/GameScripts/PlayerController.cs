using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum TurnDirection { NONE, LEFT, RIGHT }

    private TurnDirection turn = TurnDirection.NONE;

    private readonly float turnSpeed = 100;
    private readonly float walkSpeed = 5f;
    private readonly float navRange = 2f;

    private Vector3 directionVector = Vector3.zero;

    
    public void Create()
    {
        StartCoroutine(Move());
    }

    public void TurnLeft()
    {
        turn = TurnDirection.LEFT;
    }

    public void TurnRight()
    {
        turn = TurnDirection.RIGHT;
    }

    public void StopTurn()
    {
        turn = TurnDirection.NONE;
    }

    private IEnumerator Move()
    {
        while(true)
        {
            if (GameData.paused)
            {
                yield return null;
                continue;
            }

            switch (turn)
            {
                case TurnDirection.LEFT:
                    transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
                    break;
                case TurnDirection.RIGHT:
                    transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
                    break;
            }

            directionVector = Quaternion.Euler(new Vector3(0, transform.localEulerAngles.y, 0)) * Vector3.forward * navRange;

            Debug.DrawRay(transform.position, directionVector, Color.green);

            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), directionVector, out RaycastHit _coinHit, navRange, GameData.coinLayerMask))
            {
                _coinHit.collider.GetComponent<Coin>().Destroy();
            }

            yield return null;
        }
    }
}
