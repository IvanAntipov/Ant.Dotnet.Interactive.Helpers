# Ant.Dotnet.Interactive.Helpers

# Features

## Fix displaying of Newtonsoft.Json.Linq.JObject in dotnet interactive

Workaround for [that](https://github.com/dotnet/interactive/issues/2877) issue

### Usage
```
#r "nuget: Ant.Dotnet.Interactive.Helpers"
Ant.Dotnet.Interactive.Helpers.NewtonsoftFormatter.Register();
```

## DisplayExtensions.DisplayCollapsed

Some times it is covenient to display data collapsed in order to make notebook more compact.

### Usage
```
#r "nuget: Ant.Dotnet.Interactive.Helpers"
using Ant.Dotnet.Interactive.Helpers;

var myData = new{a = 1};
myData.DisplayCollapsed();
```

## PropsRenderer

Shorthand to update cell output in place

## Usage
```
#r "nuget: Ant.Dotnet.Interactive.Helpers"
using Ant.Dotnet.Interactive.Helpers;

var renderer = new PropsRenderer();

renderer.DisplayProp("a", "1");
await System.Threading.Tasks.Task.Delay(1000);
renderer.DisplayProp("b", "2");
```