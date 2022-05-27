using UnityEngine;
using Zenject;

public class PoolInstaller : MonoInstaller
{
    [SerializeField] private AmmoPool pool;
    public override void InstallBindings()
    {
        Container.Bind<AmmoPool>()
            .FromInstance(pool)
            .AsSingle();
    }
}