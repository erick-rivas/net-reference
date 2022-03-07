# net-reference

## Create a new folder web api and switch to it
```
dotnet new webapi -f net6.0 -o ProjectName
```

## Switch to the project's dir
```
cd ProjectName
```

## If your're in a development environment and it's the firts time you execute a dotnet web app you need to add a local https certificate

### To install a test HTTPS certificate, run:
```
dotnet --info
```

### To execute the tool **dev-certs** to trust the HTTPS certificate, run:
```
dotnet dev-certs https --trust
```



