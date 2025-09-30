Sandbox Projects
===============

This folder groups multiple tiny sandbox projects used for quick experiments. Each sandbox is a standalone .NET console project located under the `sandboxes/` subfolder.

Layout
- `sandboxes/` - contains individual sandbox projects (each with its own .csproj)
- `scripts/` - helper scripts (optional)

How to run a sandbox (PowerShell / Windows)

From the workspace root you can build+run any sandbox project by pointing `dotnet run` at its .csproj. Example using the existing projects:

```powershell
dotnet run --project "C:\Users\Jesse Nielson\Downloads\byui_fall_2025\cse_210\cse210-projects\sandbox\sandboxes\Sandbox\Sandbox.csproj"

dotnet run --project "C:\Users\Jesse Nielson\Downloads\byui_fall_2025\cse_210\cse210-projects\sandbox\sandboxes\TempRun\TempRun.csproj"
```

Run the compiled DLL directly (example):

```powershell
dotnet "C:\Users\Jesse Nielson\Downloads\byui_fall_2025\cse_210\cse210-projects\sandbox\sandboxes\Sandbox\bin\Debug\net8.0\Sandbox.dll"
```

Quick helper (PowerShell)
- Run the helper script to execute a sandbox by name (created at `sandbox/scripts/run.ps1`):

```powershell
# from sandbox folder
./scripts/run.ps1 Sandbox
```

Notes
- Do not pass a single .cs file to `dotnet build` — `dotnet build` expects a project (.csproj) or solution (.sln) file. Passing a .cs file will cause an XML parse error.
- Each sandbox prints whatever it was written to print; for the `Sandbox` project the expected output (if using the Person demo) is:

```
Smith, Joseph
Joseph, Smith
```

If you want I can also add a `README.md` inside each sandbox with a one-line run command.
