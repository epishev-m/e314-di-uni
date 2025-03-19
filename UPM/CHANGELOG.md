# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0] - 2025.03.19

### Removed

- Removed `Configure` method from `Context`

## [1.0.0] - 2025.03.12

### Added

- `Context` - base abstract class for DI context with `Bind`, `Configure`, `Run` methods
- `RootContext` - root context with container capacity configuration (default 127 items)
- `SceneContext` - scene context with support for inheriting bindings from parent context
