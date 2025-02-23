# Jared Scott’s Face Maker
## Using Windows Setup Installer

**Subject:** Visual Studio Windows Setup Installer  
**Author:** Jared  
**Date:** February 21st, 2025  
**GitHub:** [Autoscotty43/JaredScott_A8_VSInstaller](https://github.com/Autoscotty43/JaredScott_A8_VSInstaller)

---

## Table of Contents
1. [Project Overview](#project-overview)
2. [Project Requirements](#project-requirements)
   1. [Requirements](#requirements)
   2. [Derived Requirements](#derived-requirements)
3. [Design Plans](#design-plans)
   1. [Design Elements](#design-elements)
4. [Implementation](#implementation)
   1. [Implementation Details](#implementation-details)
5. [Testing](#testing)
   1. [Testing Procedures](#testing-procedures)
6. [Requirements Traceability](#requirements-traceability)

---

## 1. Project Overview
The Face Maker project is a Windows application that allows users to create and modify facial designs with customizable features. The application includes a user-friendly interface and comes with a help documentation file (`FaceMakerHelp.chm`). The application is packaged using the **Setup Windows Installer** extension in **Visual Studio Code** to generate an `.exe` installer that includes all necessary resources.

---

## 2. Project Requirements
### 2.1 Requirements
- The application must allow users to create and edit face designs.
- Users should be able to save and load faces.
- The application must include a help file (`FaceMakerHelp.chm` and HTML version).
- The installer must include required files such as the `Sample_Faces/` folder containing example face designs.
- The installer must create a **desktop shortcut** for easy access.

### 2.2 Derived Requirements
- The application should have an **intuitive UI**.
- File handling should be implemented to **support loading face details**.
- The installer should ensure **all necessary files are placed in the correct directories**.
- The help file should be accessible **within the application and externally**.

---

## 3. Design Plans
### 3.1 Design Elements
#### User Interface
- A **simple UI** with buttons for face selection, info, and help files.

#### Data Storage
- **Saved face data** is stored in a designated `Sample_Faces/` directory.
- **Help documentation** is stored in the `Help/` directory.

#### Installer Setup
The installer includes:
- `FaceMaker.exe` (application executable)
- `FaceMakerHelp.chm` (help documentation)
- `Sample_Faces/` (directory for example faces)
- `Help/` (directory for help files)
- A **desktop shortcut** for the help file

---

## 4. Implementation
### 4.1 Implementation Details
#### Development Environment
- Built using **Visual Studio Code** with the **Setup Windows Installer** extension.

#### File Structure
- `FaceMaker.exe`: The main application executable.
- `Sample_Faces/`: Contains pre-made faces for users.
- `FaceMakerHelp.chm`: The help documentation file.
- `Help/`: Contains help files (`.chm` and HTML).

#### Installer Configuration
The installer script includes:
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

#### Installation Steps
1. The user **runs** `SetupInstaller.exe`.
2. Files are **copied** to the installation directory.
3. A **shortcut** to the `.exe` file is placed on the **desktop**.
4. The user can **launch the application** from the shortcut.

---

## 5. Testing
### 5.1 Testing Procedures
#### Functional Testing
- Verify **UI elements** function correctly.
- Ensure **faces** can be loaded successfully.
- Confirm the **help file** opens correctly.

#### Installer Testing
- Ensure `FaceMaker.exe` installs correctly.
- Confirm the `Sample_Faces/` folder is included.
- Verify the **help file** works.

#### User Testing
- Gather feedback on **usability** and **functionality**.

---

## 6. Requirements Traceability

| Paragraph Defined | Requirements Text | Paragraph Implemented | Paragraph Tested |
|------------------|------------------|----------------------|------------------|
| 2.1 | Users can create/edit faces | 4.1 | 5.1 |
| 2.1 | Load functionality | 4.1 | 5.1 |
| 2.1 | Installer includes `Sample_Faces/` | 4.1 | 5.1 |
| 2.1 | Installer includes help file | 4.1 | 5.1 |
| 2.1 | Desktop shortcut for `.exe` file | 4.1 | 5.1 |

---

This README.md provides all necessary details regarding the **Face Maker** project, from requirements to testing and implementation. If you have any questions, feel free to open an **issue** on the GitHub repository.
