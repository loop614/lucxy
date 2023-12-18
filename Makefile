USER:=$(shell id -u)
GROUP:=$(shell id -g)

DOTNETRUN:=dotnet run
DOTNETTEST:=dotnet test

run:
	$(DOTNETRUN) --project=lucxy
