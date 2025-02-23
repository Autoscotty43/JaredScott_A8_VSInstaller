# Jared Scott’s Face Maker

## Overview
Jared Scott's Face Maker is a Windows application that allows users to create and modify facial designs with customizable features. The application includes a user-friendly interface and a help documentation file (`FaceMakerHelp.chm`). The project utilizes the Windows Setup Installer extension in Visual Studio to generate an executable (`.exe`) installer that bundles all necessary resources for installation.

## Features
- Create and edit face designs with various customization options.
- Save and load face designs.
- Access an integrated help file (`FaceMakerHelp.chm` and HTML versions).
- Includes a `Sample_Faces` folder with example designs.
- Installer automatically sets up necessary files and directories.
- Creates a desktop shortcut for easy access.

## Installation
To install Face Maker:
1. Download and run `FaceMaker_Installer.exe`.
2. Follow the on-screen instructions to complete the setup.
3. A shortcut to `FaceMaker.exe` will be created on your desktop.
4. Launch the application and start designing faces!

## Project Structure
```
FaceMaker/
├── FaceMaker.exe              # Main application executable
├── Sample_Faces/              # Directory for example face designs
├── FaceMakerHelp.chm          # Help documentation
├── Help/                      # Additional help files (CHM & HTML)
└── Installer Script           # Configuration for Windows Setup Installer
```

## Development
- **Development Environment:** Visual Studio Code with Windows Setup Installer extension.
- **Installer Configuration:** The installer script ensures correct file placement and directory setup.

Example installer configuration:
```json
{
  "app": "C:/Path/To/FaceMaker.exe",
  "output": "FaceMaker_Installer.exe",
  "files": [
    "C:/Path/To/Sample_Faces/*",
    "C:/Path/To/Help"
  ]
}
```

## Testing
### Functional Testing
- Verify UI elements and face editing functionalities.
- Test loading and saving of face designs.
- Ensure the help file opens correctly.

### Installer Testing
- Confirm `FaceMaker.exe` installs correctly.
- Ensure the `Sample_Faces/` folder is included.
- Verify the desktop shortcut is created and works as expected.

### User Testing
- Gather feedback on usability and application performance.

## Requirements Traceability
| Requirement                          | Implemented | Tested |
|--------------------------------------|-------------|---------|
| Users can create and edit faces      | ✅ | ✅ |
| Faces can be saved and loaded        | ✅ | ✅ |
| Installer includes `Sample_Faces`    | ✅ | ✅ |
| Help file is included and accessible | ✅ | ✅ |
| Desktop shortcut is created          | ✅ | ✅ |

## Repository
GitHub: [Autoscotty43/JaredScott_A8_VSInstaller](https://github.com/Autoscotty43/JaredScott_A8_VSInstaller)

---
*Developed by Jared Scott - February 21, 2025*

