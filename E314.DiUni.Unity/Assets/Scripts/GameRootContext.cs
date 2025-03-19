using E314.DI;
using E314.DI.Uni;
using UnityEngine;

namespace Game
{

public sealed class GameRootContext : RootContext
{
	protected override void Bind(IDiContainer container)
	{
		Debug.Log("GameRootContext initialized");
	}

	protected override void Run()
	{
		Debug.Log("GameRootContext run");
	}
}

}