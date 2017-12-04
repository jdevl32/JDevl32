@echo off

set "dst=\\dd-wrt\nas-t-a1\[Storage]\Development\Package\NuGet"
@rem todo|jdevl32: use "dst" to replace slashes
set "dstls=//dd-wrt/nas-t-a1/[Storage]/Development/Package/NuGet"

@rem @echo %cd%

set "src=..\..\JDevl32.Entity\bin\Release"
nuget init "%src%" "%dst%"

set "src=..\..\JDevl32.Logging\bin\Release"
nuget init "%src%" "%dst%"

set "src=..\..\JDevl32.Mapper\bin\Release"
nuget init "%src%" "%dst%"

set "src=..\..\JDevl32.Web\bin\Release"
nuget init "%src%" "%dst%"

set "src=..\..\JDevl32.Web.Host\bin\Release"
nuget init "%src%" "%dst%"

ls -lA "%dstls%"
