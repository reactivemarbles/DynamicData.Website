---
NoTitle: true
Title: Compiling
---

0. DynamicData will not build correctly on Visual Studio for Mac as of 22/08/2017 building for multiple TFM's is not implemented nor working in Visual Studio for Mac. Only netstandard is compiled.

1. You'll need a windows machine w/VS2022 with UWP+Windows10 SDK's installed. We are able to compile iOS and Mac platforms without being connected to a Mac via reference assemblies. It's magic. You do not need a mac.

2. Clone DynamicData using Git, you won't be able to compile from the archive as the build script uses GitVersion to automatically determine semver.

3. DynamicData and other projects within the group make use of msbuild.sdk.extras. Each project repository contains a global.json that denotes the version of the .Net Core SDK being used. If you do not have the correct version you will see a solution with a bunch of unloaded projects. When you attempt to load a project you will get a message akin to:

   ```
   Unable to locate the .NET Core SDK. Check that it is installed and that the version specified in global.json (if any) matches the installed version.

   D:\github\reactiveui\splat\src\Splat\Splat.csproj : error  : The expression "[System.IO.Path]::GetDirectoryName('')" cannot be evaluated. The path is not of a legal form.  C:\Users\username\.nuget\packages\msbuild.sdk.extras\2.0.29\Sdk\Sdk.props
   ```

   To get the correct version (or later) please visit https://dotnet.microsoft.com/download/dotnet-core


## Introduction

For you to contribute to the DynamicData framework you need to have an understanding of the DynamicData framework.
This document will give you an overview of the DynamicData framework elements.

DynamicData is a composable, cross-platform model-view-viewmodel framework for all .NET platforms that is inspired by functional reactive programming which is a paradigm that allows you to abstract mutable state away from your user interfaces and express the idea around a feature in one readable place and improve the testability of your application.

## The Main Features of DynamicData

* **Reactive programming** - DynamicData is a reactive programming framework which means you are able to easily express complex architectures in a composable, testable way.
* **MVVM** - DynamicData is a MVVM framework which means it provides a way to structure your application in a way that is easy to reason about and test.
* **Cross-platform** - DynamicData is a cross-platform framework which means you can share your business logic across all .NET platforms.
* **Extensible** - DynamicData is an extensible framework which means you can extend the framework to fit your needs.
* **Testable** - DynamicData is a testable framework which means you can test your application in a deterministic way.
* **DynamicData is a community project** - DynamicData is a community project which means it is developed by the community for the community.
* **DynamicData is open source** - DynamicData is open source which means you can dig into the source code and learn from it.
* **DynamicData is used by many companies** - DynamicData is used by many companies which means it is a framework that is used in production and is battle tested.

## The Main Elements of DynamicData

* **ReactiveObject** - ReactiveObject is the base class for objects that notify when properties change.
* **ReactiveCommand** - ReactiveCommand is a command that notifies when it is executing and has completed.
* **WhenAnyValue** - WhenAnyValue is a method that allows you to observe when a property changes.
* **ObservableAsPropertyHelper** - ObservableAsPropertyHelper is a class that allows you to create a read-only property from an observable.

DynamicData has Splat as a dependency which is a portable library for logging, error reporting, and a service locator.

DynamicData has Akavache as a dependency which is an asynchronous, persistent key-value store created for writing desktop and mobile applications in C#, based on SQLite3. Akavache is great for both storing important data (i.e. user settings) as well as cached local data that expires.

DynamicData has DynamicData as a dependency which is a portable class library which brings the power of Reactive Extensions (Rx) to collections. Rx is extremely powerful but out of the box provides nothing to assist with managing collections, nor does it solve the problem of turning asynchronous data into collections. This library fills that void, and initialises the Reactive Extensions suite of collections.

The combination of DynamicData, Splat, Akavache, and DynamicData is called the DynamicData framework.

In order to maintain a high level of quality, DynamicData has a set of unit tests that are run on every commit via CI. DynamicData also has a set of integration tests that are run on every commit using CI.

All code changes are reviewed by the DynamicData team via pull requests. The DynamicData team consists of the core team and the community. The core team consists of the maintainers of the DynamicData framework. The community consists of the contributors to the DynamicData framework.

Any code changes must take into account the other projects and platforms in the DynamicData framework and how they are affected by the code changes.

Any code changes must take into account the existing functionality and how it affects the operation of current releases in the DynamicData framework and how they are affected by the code changes.
