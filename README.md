# Herald.Template.Grpc

![Status](https://github.com/tcfialho/Herald.Template.Grpc/workflows/Herald.Template.Grpc/badge.svg) ![Coverage](https://codecov.io/gh/tcfialho/Herald.Template.Grpc/branch/master/graph/badge.svg) ![NuGet](https://buildstats.info/nuget/Herald.Template.Grpc)

## Overview
 - Herald Scaffold for create gRPC projects.

## Installation
 - .NET CLI
    ```
    dotnet new -i Herald.Template.gRPC::*
    ```

See more information in [Nuget](https://www.nuget.org/packages/Herald.Template.Grpc/).

## Usage

```
dotnet new herald-grpc -n ProjectName -o OutputFolder 

Options:
  -nd|--no-database     Removes database sample into generated project (Default: false).
  -nq|--no-queue        Removes queue sample into generated project (Default: false).
  -ne|--no-externalapi  Removes external api sample into generated project (Default: false).
```
## Credits

Author [**Thiago Fialho**](https://br.linkedin.com/in/thiago-fialho-139ab116)

## License

Herald.Template.Grpc is licensed under the [MIT License](LICENSE).