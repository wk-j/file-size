## Get File Size

```
rm ~/.dotnet/tools/wk-file-size
cake -target=Pack
dotnet install tool -g FileSize --source ./publish

wk-file-size README.md
wk-file-size -b README.md
wk-file-size -k README.md
wk-file-size -m README.md
wk-file-size -g README.md
```