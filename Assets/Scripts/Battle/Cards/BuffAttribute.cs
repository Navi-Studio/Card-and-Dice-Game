using System;

[AttributeUsage(AttributeTargets.Class)]
public class BuffAttribute : Attribute
{
    public string buffName { get; }
    public string buffDescription { get; }
    public int duration { get; set; }
    public PlayerOrEnemy playerOrEnemy { get; }

    public BuffAttribute(string _buffName,string _buffDescription,int _duration,PlayerOrEnemy _playerOrEnemy)
    {
        buffName = _buffName;
        buffDescription = _buffDescription;
        duration = _duration;
        playerOrEnemy = _playerOrEnemy;
    }
}