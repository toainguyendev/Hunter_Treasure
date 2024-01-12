using UnityEngine;

public abstract class SkillBase : MonoBehaviour, ISkill
{
    public virtual string Name => throw new System.NotImplementedException();

    public virtual bool IsDonePerform => throw new System.NotImplementedException();

    public virtual Sprite Icon => throw new System.NotImplementedException();

    public virtual string Description => throw new System.NotImplementedException();

    public virtual float CooldownTime => throw new System.NotImplementedException();

    public virtual float MaintanceTime => throw new System.NotImplementedException();

    public virtual float CastingTime => throw new System.NotImplementedException();

    public virtual bool CanBeInterrupted => throw new System.NotImplementedException();

    public virtual void Interrupt()
    {
    }

    public virtual void Trigger()
    {
    }
}
