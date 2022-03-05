![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")
# Sitecore Hackathon 2022

- MUST READ: **[Submission requirements](SUBMISSION_REQUIREMENTS.md)**
- [Entry form template](ENTRYFORM.md)
- [Starter kit instructions](STARTERKIT_INSTRUCTIONS.md)

# Hackathon Submission Entry form

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

## Team name
⟹ theEagles

## Category
⟹ Extend the Sitecore Command Line Interface (CLI) plugin 

## Description
⟹ Write a clear description of your hackathon entry.  

  - Module Purpose - create the scaffolding to extend CLI and add a cache clearer that could be triggered from the CLI.
  - What problem was solved (if any) - Creating the infrastructure to extend the CLI is cumbersome and being able to automate and remotely trigger clearing of the cache or very highly demanded features.
    - How does this module solve it - It exposes a `dotnet sitecore ae clear` command that clears the Sitecore cache


## Video link

⟹ [Sitecore Hackathon 2022 theEagles CLI Extension](https://www.youtube.com/watch?v=WZCrjEiH1qQ)

## Pre-requisites and Dependencies

⟹ Does your module rely on other Sitecore modules or frameworks?

- List any dependencies
nuget - https://www.nuget.org/downloads - we used 6.0.0. add the path to the folder holding nuget.exe to the PATHS environemnt variable.
Sitecore CLI module

## Installation instructions
⟹ Write a short clear step-wise instruction on how to install your module.  

- Download nuget 6.0.0 from https://www.nuget.org/downloads
- Add c:\users\\{your user}\downloads to PATHS in Windows Environment Variables.
- Install Sitecore 10.2 with Graphical Setup for XP Single from [here](https://sitecoredev.azureedge.net/~/media/F6813A6E3E424AB99A6E9A7CC257648B.ashx?date=20211101T105423)
- Pull latest on our repo's [main branch](https://github.com/Sitecore-Hackathon/2022-theEagles)
- Install CLI in the solution folder by following [these steps](https://doc.sitecore.com/xp/en/developers/101/developer-tools/install-sitecore-command-line-interface.html)
- Log into Sitecore through CLI by following [these steps](https://doc.sitecore.com/xp/en/developers/101/developer-tools/log-in-to-a-sitecore-instance-with-sitecore-command-line-interface.html)
- Build the solution
- Manually copy the following dlls from where they are built into the inetpub bin folder of the website: `Sitecore.DevEx.Extensibility.HackathonApi.deps.json` `Sitecore.DevEx.Extensibility.HackathonApi.dll` `Sitecore.DevEx.Extensibility.HackathonApi.pdb``Sitecore.DevEx.Configuration.dll` `Sitecore.Devex.Client.Cli.Extensibility.dll` `Sitecore.DevEx.Client.dll` `Sitecore.DevEx.dll`
- Open the output window and copy the path to the generated `Sitecore.DevEx.Extensibility.Hackathon.1.0.0.nupkg` file
- Create a folder for the local Nuget feed we are about to set up -- we are using `C:\schack\feed9`
- Create a nuget feed by running `nuget add ""C:\Hackathon-2022\TheEagles\2022-theEagles\src\Feature\Sitecore.DevEx.Extensibility.Hackathon\bin\Debug\Sitecore.DevEx.Extensibility.Hackathon.1.0.0.nupkg"" -Source C:\schack\feed9` -- replace the first argument after the `add` command with the path that you exctracted from the output window
- Add the nuget feed to your Nuget sources by running `nuget sources Add -Name "anyNameWorks" -Source C:\schack\feed9`
- Install the Plugin thru CLI -- make sure to CD into the solution folder and run `dotnet sitecore plugin add -n Sitecore.DevEx.Extensibility.Hackathon`

## Usage instructions
While in the solution folder in powershell run `dotnet sitecore ae clear`

Include screenshots where necessary. You can add images to the `./images` folder and then link to them from your documentation:

![Success](/images/1.png?raw=true "Success")
