using E314.DI;
using E314.DI.Uni;
using UnityEngine;

namespace Game
{

public sealed class GameSceneContext : SceneContext
{
	protected override void Bind(IDiContainer container)
	{
		Debug.Log("GameSceneContext initialized");
	}

	protected override void Configure()
	{
		Debug.Log("GameSceneContext configure");
	}

	protected override void Run()
	{
		Debug.Log("GameSceneContext run");
	}
}

}