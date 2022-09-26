## Current version 1.0.3
## Next version 1.0.3.2

## Building new version
 - After editing the version on .csproj file Go to the project path "repos\SuperConvert\SuperConvert" and Run=>

``` 
msbuild -t:pack 
```

## Publishing new version 
## Go to nuget.com -> under username -> API keys -> create key
## CD to .nupkg path (\repos\SuperConvert\SuperConvert\bin\Debug\) and RUN:

```
dotnet nuget push SuperConvert.1.0.3.2.nupkg --api-key <KEY> --source https://api.nuget.org/v3/index.json
```

## Adding new features 
- 1.0.x.0
## Editing old features 
- 1.0.0.x
