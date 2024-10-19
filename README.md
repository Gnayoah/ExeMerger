[简体中文](https://github.com/Gnayoah/ExeMerger/blob/main/README_CN.md)



# ExeMerger

A tool to merge exe, dll, and other program files or folders into a single executable.

## License

This project is licensed under the AGPL-3.0 License.

## Description

ExeMerger is a tool designed to merge executable files (exe), dynamic link libraries (dll), and other program files or folders into a single executable file. This can be particularly useful for deploying applications in a single, self-contained executable.

## How to Use

### Prerequisites

- .NET Core SDK
- PowerShell

### Instructions

1. **Clone the Repository**:

    ```bash
    git clone https://github.com/Gnayoah/ExeMerger.git
    cd ExeMerger
    ```

2. **Replace `installer.zip` and `installer.exe`**:

    - Place your zipped files (containing the necessary exe, dll, and other files) in the root directory of the project and rename it to `demo.zip`.
    - Replace `demo.exe` with your executable file name inside the zip archive.

3. **Build and Publish the Project**:

    Use the following command to publish the project as a single executable:

    ```bash
    dotnet publish -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:PublishTrimmed=true -o ./publish
    ```

    This command will create a single executable in the `./publish` directory.

4. **Run the Executable**:

    After publishing, run the generated executable file. The program will:
    - Extract `installer.zip` to the Temp directory.
    - Set the extracted folder to hidden.
    - Execute `installer.exe` with administrative privileges.


## Code Explanation

- **Main method**: Sets up the directory and extracts the embedded `installer.zip` resource.
- **ExtractEmbeddedResource method**: Extracts the zip file to a specified directory.
- **RunAsAdmin method**: Runs the `installer.exe` file with administrative privileges.

## Support

For any issues or questions, please open an issue on the GitHub repository.

## Authors

- Gnayoah - [Gnayoah.com](https://gnayoah.com)
