using System.Collections;
using UnityEngine;

public class Shooting : Grounded
{
    private float timer;
    private bool shooting;

    public override void Init(PlayerStateMachine stateMachine)
    {
        this.Player = stateMachine;
        stateID = PlayerStateID.Shooting;
    }
    public override void Tick()
    {
        base.Tick();
        timer += Time.deltaTime;
        shooting = true;
        Shoot();
    }

    private void Shoot()
    {
        if (timer > Player.fireRate)
        {
            timer = 0;
            var bullet = GameManager.Instance.BulletsPool.GetPooledObject();
            if (bullet == null)
                return;
            bullet.transform.position = Player.firePoint.position;
            bullet.SetActive(true);
        }
    }

    public override void CheckConditions()
    {
        base.CheckConditions();

        if (Input.GetMouseButtonUp(0))
            Player.ChangeState(Player.GetPreviousState());

    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        shooting = true;
        //StartCoroutine(IShoot());
    }

    public override void OnExitState()
    {
        base.OnExitState();
        shooting = false;
        //StopCoroutine(IShoot());
    }

    private IEnumerator IShoot()
    {
        while (Player.GetCurrentState() == PlayerStateID.Shooting)
        {
            if (Input.GetMouseButton(0))
            {
                Debug.LogError("Shooting for some reason");
                yield return new WaitForSeconds(1 / Player.fireRate);
                Shoot();
            }
        }
    }
}