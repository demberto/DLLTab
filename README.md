# DLLTab

DLLTab is a Windows property sheet extension which displays the imports and
exports of 32/64 bit PE DLLs.

![Preview](https://raw.githubusercontent.com/demberto/DLLTab/master/ext/preview.gif)

## Installation

Use the installers from the [Releases](https://github.com/demberto/DLLTab/releases) section.

*OR*

### Build from source

NOTE: [PeNet](https://github.com/secana/PeNet), a dependency, uses an incorrect
version of `System.Runtime.CompilerServices.Unsafe` (see [this][penet-issue] issue).

This can be fixed by installing v4.5.3 of `System.Runtime.CompilerServices.Unsafe`
into the GAC:

1. Download the Nuget [package][nuget-package].
2. Unzip the `.nupkg` file.
3. Go to the `lib/net461` directory.
4. In that directory, open an instance of VS developer CMD/Powershell.
5. Run:

        gacutil /i System.Runtime.CompilerServices.Unsafe.dll

Rest of the build process is super-simple, just build the solution and the
installation / registration will be automatically handled in the pre/post build
steps.

<!-- LINKS -->
[penet-issue]: https://github.com/secana/PeNet/issues/238
[nuget-package]: https://www.nuget.org/packages/System.Runtime.CompilerServices.Unsafe/4.5.3
