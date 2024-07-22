# ExeMerger

一个将 exe、dll 和其他程序文件或文件夹合并为单个可执行文件的工具。


## 许可证

本项目采用 GPL-3.0 许可证。

## 描述

ExeMerger 是一个工具，旨在将可执行文件 (exe)、动态链接库 (dll) 和其他程序文件或文件夹合并为一个单一的可执行文件。这对于以单一、独立的可执行文件部署应用程序非常有用。

## 如何使用

### 前提条件

- .NET Core SDK
- PowerShell

### 使用说明

1. **克隆仓库**：

    ```bash
    git clone https://github.com/Gnayoah/ExeMerger.git
    cd ExeMerger
    ```

2. **替换 `demo.zip` 和 `demo.exe`**：

    - 将包含必要的 exe、dll 和其他文件的压缩文件放置在项目的根目录，并将其重命名为 `demo.zip`。
    - 在压缩包内，将可执行文件的名称替换为 `demo.exe`。

3. **构建和发布项目**：

    使用以下命令将项目发布为单个可执行文件：

    ```bash
    dotnet publish -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:PublishTrimmed=true -o ./publish
    ```

    此命令将在 `./publish` 目录中创建一个单一的可执行文件。

4. **运行可执行文件**：

    发布后，运行生成的可执行文件。程序将会：
    - 将 `demo.zip` 解压到本地应用数据目录。
    - 将解压后的文件夹设置为隐藏。
    - 以管理员权限执行 `demo.exe`。



## 代码解释

- **Main 方法**：设置目录并提取嵌入的 `demo.zip` 资源。
- **ExtractEmbeddedResource 方法**：将 zip 文件提取到指定目录。
- **RunAsAdmin 方法**：以管理员权限运行 `demo.exe` 文件。

## 支持

如果有任何问题或疑问，请在 GitHub 仓库中提交 issue。

## 作者

- Gnayoah - [Gnayoah.com](https://gnayoah.com)
