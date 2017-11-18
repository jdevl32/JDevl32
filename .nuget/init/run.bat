@echo off

set "src=C:\Offline\[D Drive]\[Storage]\Development\Package\NuGet\Release"
set "dst=\\dd-wrt\nas-t-a1\[Storage]\Development\Package\NuGet"
@rem todo|jdevl32: use "dst" to replace slashes
set "dstls=//dd-wrt/nas-t-a1/[Storage]/Development/Package/NuGet"

@rem @echo %cd%

nuget init "%src%" "%dst%"
ls -lA "%dstls%"
