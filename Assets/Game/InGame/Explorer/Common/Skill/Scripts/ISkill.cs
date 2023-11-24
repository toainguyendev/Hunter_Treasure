
using UnityEngine;

public interface ISkill
{
    public string Name { get; }

    public bool IsDonePerform { get; }

    // Get Skill icon method (for UI)
    public Sprite Icon { get; }
    // Get Skill description method (for UI)
    public string Description { get; }
    // Get Skill cooldown method 
    public float CooldownTime { get; }
    // Get Skill maintance time method 
    public float MaintanceTime { get; }
    // Get Skill casting time method 
    public float CastingTime { get; }
    // Get Skill can be interrupted method
    public bool CanBeInterrupted { get; }


    // Trigger Skill method
    public void Trigger();

    // Interrupt Skill method
    public void Interrupt();
}
