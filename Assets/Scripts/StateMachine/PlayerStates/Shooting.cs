using UnityEngine;

public class Shooting : Grounded
{
    private float timer;

    public override void Init(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        stateID = StateID.Shooting;
    }
    public override void Tick()
    {
        base.Tick();
        timer += Time.deltaTime;
        Shoot();
    }

    private void Shoot()
    {
        if (timer > player.fireRate)
        {
            timer = 0;
            var bullet = GameManager.Instance.BulletsPool.GetPooledObject();
            if (bullet == null)
                return;
            bullet.transform.position = player.firePoint.position;
            bullet.SetActive(true);
            GameManager.Instance.AudioManager.PlayAudio(AudioManager.AudioType.Gun);
        }
    }

    public override void CheckConditions()
    {
        base.CheckConditions();

        if (Input.GetMouseButtonUp(0))
            stateMachine.ChangeState(stateMachine.GetPreviousState());

    }

    public override void OnExitState()
    {
        base.OnExitState();
        //if (GameManager.Instance.AudioManager.GetSource(AudioManager.SourceType.Player).isPlaying)
            //GameManager.Instance.AudioManager.StopAudio(AudioManager.AudioType.Gun);
    }

}