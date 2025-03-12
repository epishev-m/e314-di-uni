using System;
using E314.Protect;
using UnityEngine;

namespace E314.DI.Uni
{

/// <summary>
/// Abstract base class for dependency injection context.
/// Provides core functionality for setting up and managing the dependency container.
/// </summary>
public abstract class Context : MonoBehaviour, IDisposable
{
	private DiContainer _container;

	/// <summary>
	/// Provides access to the container's binding provider.
	/// </summary>
	public IBindingProvider BindingProvider => _container;

	/// <summary>
	/// Releases resources used by the container.
	/// </summary>
	public void Dispose()
	{
		_container.Dispose();
	}

	/// <summary>
	/// Defines bindings for the dependency container.
	/// </summary>
	/// <param name="container">The dependency container to configure.</param>
	protected abstract void Bind(IDiContainer container);

	/// <summary>
	/// Performs additional configuration after bindings are defined.
	/// </summary>
	protected abstract void Configure();

	/// <summary>
	/// Starts the main context logic after initialization.
	/// </summary>
	protected abstract void Run();

	/// <summary>
	/// Creates a new instance of the dependency container.
	/// </summary>
	/// <returns>A new instance of DiContainer.</returns>
	protected abstract DiContainer CreateContainer();

	/// <summary>
	/// Initializes the dependency container when the object awakens.
	/// Creates the container, performs bindings and configuration.
	/// </summary>
	protected void Awake()
	{
		_container = CreateContainer();
		Requires.Ensure(_container != null, "Container is null.");
		Bind(_container);
		Configure();
	}

	/// <summary>
	/// Executes the main context logic after all objects are initialized.
	/// </summary>
	private void Start()
	{
		Run();
	}
}

}
