using UnityEngine;

namespace E314.DI.Uni
{

/// <summary>
/// Abstract base class for root dependency injection context.
/// Provides configuration for container capacity and implements container creation.
/// </summary>
public abstract class RootContext : Context
{
	[SerializeField]
	[Tooltip("The initial capacity of the container.")]
	private int _capacity = 127;

	[SerializeField]
	[Tooltip("The initial capacity for scoped instances.")]
	private int _scopeCapacity = 7;

	/// <summary>
	/// Creates a new instance of DiContainer with specified capacity settings.
	/// </summary>
	/// <returns>A new configured instance of DiContainer.</returns>
	protected override DiContainer CreateContainer()
	{
		return new DiContainer(new DiContainer.Config(_capacity, _scopeCapacity));
	}
}

}
