### Description
- dotnet 7 app proxying to [luceed](https://kb.luceed.hr/)
- using C# 11 and dotnet 7.0.404 on debian 12

### Requirements
- dotnet, make

### Quick Start
```console
$ dotnet run --project=lucxy
```
or
```console
$ make run
```

### Test
```console
$ cd lucxytest
$ dotnet test
```

### Endpoints
- [article](http://localhost:5293/luceed/article/pri)
- [transaction payment](http://localhost:5293/luceed/transaction/payment/132-1/01.01.2020/01.01.2024)
- [transaction article](http://localhost:5293/luceed/transaction/article/132-1/01.01.2020/01.01.2024)
