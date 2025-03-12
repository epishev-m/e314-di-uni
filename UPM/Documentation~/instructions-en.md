# E314.DiUni

## Description

The `E314.DiUni` module provides basic functionality for organizing dependency injection through a context system in Unity.
Currently, the context system is implemented, and new modules are planned to be added in the future to extend functionality.

## Content tree

- [E314.DiUni](#e314diuni)
  - [Description](#description)
  - [Content tree](#content-tree)
  - [Context](#context)
    - [RootContext](#rootcontext)
    - [SceneContext](#scenecontext)
    - [Custom Implementations](#custom-implementations)
    - [Unity Configuration](#unity-configuration)

## Context

`Context` is an abstract base class for dependency injection context.
It provides core functionality for setting up and managing the dependency container:

- `Bind(IDiContainer container)` - defines bindings for the dependency container
- `Configure()` - performs additional configuration after defining bindings
- `Run()` - executes the main context logic after initialization

### RootContext

`RootContext` is an abstract base class for the root dependency injection context. It provides configuration for container capacity:

- `_capacity` - initial container capacity (default 127)
- `_scopeCapacity` - initial capacity for scoped instances (default 7)

```csharp
public sealed class GameRootContext : RootContext
{
    protected override void Bind(IDiContainer container)
    {
        // Define your container bindings here
    }

    protected override void Configure()
    {
        // Additional configuration
    }

    protected override void Run()
    {
        // Main logic after initialization
    }
}
```

### SceneContext

`SceneContext` is an abstract base class for scene dependency injection context.
It provides container creation with the ability to inherit bindings from another context:

- Supports the same capacity settings as `RootContext`
- Allows specifying parent context type for binding inheritance
- Automatically searches for parent context during creation

```csharp
public sealed class GameSceneContext : SceneContext
{
    protected override void Bind(IDiContainer container)
    {
        // Define your scene container bindings here
    }

    protected override void Configure()
    {
        // Additional configuration
    }

    protected override void Run()
    {
        // Scene logic after initialization
    }
}
```

### Custom Implementations

You can create your own context type by inheriting directly from `Context`.
This is useful when you need special container initialization logic or specific behavior different from `RootContext` and `SceneContext`.

### Unity Configuration

The following parameters are used in the Unity Inspector to configure contexts:

- **Capacity**: Initial container capacity
- **Scope Capacity**: Initial capacity for scoped instances
- **Parent Context Type** (SceneContext only): Parent context type for binding inheritance
