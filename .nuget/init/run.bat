@echo off

set "src=..\.."
set "dst=\\dd-wrt\nas-t-a1\[Storage]\Development\Package\NuGet"

@rem @echo %cd%

nuget init "%src%" "%dst%"
ls -lA "%dst%"
