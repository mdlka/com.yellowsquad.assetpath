# com.yellowsquad.assetpath Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/), and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).



## [Unreleased]

### Breaking Changes

### Added

### Changed

### Removed

### Fixed



## [2.0.0] - 2023-04-14

### Breaking Changes
- A generic class is now used instead of an attribute.

### Added
- Generic `ResourcesReference` class that can be applied to all classes that inherit UnityEngine.Object.
- Implementation of `ISerializationCallbackReceiver` to update paths before build.

### Removed
- `SceneReference` class because for scenes, there are better solutions.
- `AssetTypeAttribute`.



## [1.0.1] - 2023-03-28

### Fixed
- Fix incorrect display of Sprite in array



## [1.0.0] - 2023-03-24

Initial release.