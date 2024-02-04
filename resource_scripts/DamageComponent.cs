using Godot;
using System;

public partial class DamageComponent : Node
{
    public int DamageAmount { get; set; } = 2;


    public void DealDamage(Node2D body)
    {
        if (body == null) return;
        if (body.HasMethod("TakeDamage"))
        {
            body.Call("TakeDamage", DamageAmount);
        }
    }
}
