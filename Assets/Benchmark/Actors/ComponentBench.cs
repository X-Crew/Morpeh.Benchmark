﻿using Pixeye.Actors;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using System.Runtime.CompilerServices;

namespace Game.Source
{
  public struct ComponentBench
  {
    public Transform transform;
    public Vector3 position;
  }

  #region HELPERS

  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  static partial class Component
  {
    public const string Bench = "Game.Source.ComponentBench";

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref ComponentBench ComponentBench(in this ent entity) =>
      ref Storage<ComponentBench>.components[entity.id];
  }

  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  sealed class StorageComponentBench : Storage<ComponentBench>
  {
    public override ComponentBench Create() => new ComponentBench();

    // Use for cleaning components that were removed at the current frame.
    public override void Dispose(indexes disposed)
    {
      foreach (var id in disposed)
      {
        ref var component = ref components[id];
      }
    }
  }

  #endregion
}