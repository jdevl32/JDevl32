@echo off

set "src=..\..\JDevl32.Web\bin\Release"
set "dst=\\dd-wrt\nas-t-a1\[Storage]\Development\Package\NuGet"
set "dstls=//dd-wrt/nas-t-a1/[Storage]/Development/Package/NuGet"

@rem @echo %cd%

nuget init "%src%" "%dst%"
ls -lA "%dstls%"
