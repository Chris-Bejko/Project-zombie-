using System.Collections;
using UnityEngine;

public class Shooting : Grounded
{
    public override void Init(PlayerStateMachine stateMachine)
    {
        this.Player = stateMachine;
        stateID = PlayerStateID.Shooting;
    }
    public override void Tick()
    {
        base.Tick();
        Shoot();
    }

    private void Shoot()
    {
        var bullet = GameManager.Instance.BulletsPool.GetPooledObject();
        if (bullet == null)
            return;
        bullet.transform.position = Player.firePoint.position;
        bullet.SetActive(true);
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
        StartCoroutine(IShoot());
    }

    public override void OnExitState()
    {
        base.OnExitState();
        StopCoroutine(IShoot());
    }
    private IEnumerator IShoot()
    {
        while (Player.GetCurrentState() == PlayerStateID.Shooting)
        {
            Debug.LogError("Shooting for some reason");
            yield return new WaitForSeconds(1/Player.fireRate);
            Shoot();
        }
    }
}