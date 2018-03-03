Task("Pack").Does(() => {
    DotNetCorePack("src/FileSize", new DotNetCorePackSettings {
        OutputDirectory = "publish"
    });
});

var target = Argument("target", "Pack");
RunTarget(target);