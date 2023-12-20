### Description
- dotnet 7 app proxying to [luceed](https://kb.luceed.hr/)
- using C# 11 and dotnet 7.0.404 on debian 12
- postgres caching needs to be enabled per module in moduleConfig, and in appsettings json

### Requirements
- dotnet, docker

### Quick Start
```console
cd lucxy
docker compose up ( if db caching )
dotnet run
```

### Endpoints
- [article](http://localhost:5059/luceed/article/pri/0/10)
- [transaction payment](http://localhost:5059/luceed/transaction/payment/4986-1/01.01.1999/01.01.2024)
- [transaction article](http://localhost:5059/luceed/transaction/article/4986-1/01.01.1999/01.01.2024)

### Test
```console
$ cd lucxytest
$ dotnet test
```
