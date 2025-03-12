using E314.ExtUni;
using UnityEngine;

namespace E314.DI.Uni
{

/// <summary>
/// Abstract base class for scene dependency injection context.
/// Provides container creation with the ability to inherit bindings from another context.
/// </summary>
public abstract class SceneContext : Context
{
	[SerializeField]
	[Tooltip("The initial capacity of the container.")]
	private int _capacity = 127;

	[SerializeField]
	[Tooltip("The initial capacity for scoped instances.")]
	private int _scopeCapacity = 7;

	[SerializeField]
	[Tooltip("The type of parent context to inherit bindings from.")]
	private SerializableType _serializableType = new(typeof(Context));

	/// <summary>
	/// Creates a new DiContainer instance with specified capacity settings.
	/// Attempts to find a parent context in the following order:
	/// 1. If _serializableType is set - searches for an object of that type
	/// 2. If type is not set or object is not found - searches for RootContext
	/// 3. If context is found - uses its bindings through BindingProvider
	/// </summary>
	/// <returns>A new DiContainer instance that optionally inherits bindings from the found context.</returns>
	protected override DiContainer CreateContainer()
	{
		var context = _serializableType.Type != null
			? FindAnyObjectByType(_serializableType.Type) as Context
			: FindAnyObjectByType<RootContext>();
		var bindingProvider = context?.BindingProvider;
		return bindingProvider != null
			? new DiContainer(new DiContainer.Config(_capacity, _scopeCapacity), bindingProvider)
			: new DiContainer(new DiContainer.Config(_capacity, _scopeCapacity));
	}
}

}