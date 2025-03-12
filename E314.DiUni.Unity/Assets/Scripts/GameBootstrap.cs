using E314.DI;
using E314.DI.Uni;
using E314.ExtUni;
using UnityEngine;

namespace Game
{

[CreateAssetMenu(fileName = "GameBootstrap", menuName = "Game/GameBootstrap")]
public sealed class GameBootstrap : Bootstrap
{
	[SerializeField]
	private RootContext _rootContextPrefab;
	
	protected override void OnSubsystemRegistration()
	{
		Debug.Log(nameof(OnSubsystemRegistration));
		var rootContext = Instantiate(_rootContextPrefab);
		DontDestroyOnLoad(rootContext.gameObject);
	}

	protected override void OnAfterAssembliesLoaded()
	{
		Debug.Log(nameof(OnAfterAssembliesLoaded));
	}

	protected override void OnBeforeSplashScreen()
	{
		Debug.Log(nameof(OnBeforeSplashScreen));
	}

	protected override void OnBeforeSceneLoad()
	{
		Debug.Log(nameof(OnBeforeSceneLoad));
	}

	protected override void OnAfterSceneLoad()
	{
		Debug.Log(nameof(OnAfterSceneLoad));
	}
}

}