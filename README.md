# Fortivex Login System Frontend & Backend

This repository contains the Vue 3 + Vite frontend that pairs with the Fortivex authentication backend (ASP.NET Core). Use the steps below to bundle and share the backend whenever you need to provide the complete project to collaborators.

## How to Share the Backend Folder

### 1. Using Git (Recommended)
1. Initialize a repository inside the backend root if it is not already under version control: `git init`.
2. Commit your backend files.
3. Push the repository to a remote service such as GitHub or GitLab so teammates can clone it.

### 2. Creating a Zip Archive from the Command Line
- **Windows (PowerShell):**
  ```powershell
  Compress-Archive -Path BackendFolder\* -DestinationPath FortivexBackend.zip
  ```
- **macOS / Linux (Terminal):**
  ```bash
  zip -r FortivexBackend.zip BackendFolder/
  ```
Send the generated `FortivexBackend.zip` file through your preferred channel (email, cloud storage, etc.).

### 3. Creating a Zip Archive with File Explorer / Finder
1. Right-click the backend folder.
2. Choose **Send to → Compressed (zipped) folder** on Windows, or **Compress** on macOS.
3. Share the resulting archive file with your collaborator.

> Replace `BackendFolder` with the actual folder name that stores the ASP.NET Core backend (for example, `LoginSystem`).

## Frontend Development
The frontend is scaffolded with Vue 3 and Vite. Install dependencies and run the development server with:

```bash
npm install
npm run dev
```
