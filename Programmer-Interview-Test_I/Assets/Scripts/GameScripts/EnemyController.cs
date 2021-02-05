using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private readonly float walkSpeed = 4.5f;
    private readonly float navRange = 4f;

    private Vector3 directionVector = Vector3.zero;


    public void Create()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if (GameData.paused)
            {
                yield return null;
                continue;
            }

            transform.LookAt(GameController.Instance.Player.transform);
            
            directionVector = Quaternion.Euler(new Vector3(0, transform.localEulerAngles.y, 0)) * Vector3.forward * navRange;

            Debug.DrawRay(transform.position, directionVector, Color.red);

            if (!Physics.Raycast(transform.position, transform.forward, out RaycastHit _rayHit, navRange, GameData.obstacleLayerMask))
            {
                transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            }

            if (Vector3.Distance(GameController.Instance.Player.transform.position, transform.position) < 3)
            {
                MenuManager.Manager.PopMenu(false);
                MenuManager.Manager.DisplayDeathMenu();
            }

            yield return null;
        }
    }
}
