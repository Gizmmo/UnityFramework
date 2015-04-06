# PatioCreator

##Patio Creator Architecture
To see an overview of the architecture, [please see the architecture page](https://github.com/CanTireInnovations/PatioCreator/blob/master/Architecture.md).
##Running Code Analytics (For Mac)
1. In terminal, Go to (Project)/Unity-Gendarme-2.10/
2. Run mono gendarme.exe --html code_report.html --set unity-full ../PatioCreator/Library/ScriptAssemblies/Assembly-CSharp.dll
3. Run open code_report.html

##Running Code Analytics (For Windows)
1. Go to (Project)/Unity-Gendarme-2
2. Run Gendarme.exe or something? If that doesn't work, use the GendarmeWizard.
3. Get a Mac

##Steps to Add Story to Project
1. Pull Master into your branch
2. Transfer Content from your scene into the main scene
3. Fix any merge conflicts
4. Make a Pull-Request for your branch with the master.
5. Make a Build for Windows
6. Put Build in Google Drive. Place the build in a folder, with the name equal to the Jira Story Key. (ex. Patio Builder/Development/Patio Builder/Builds/ADO-137/build.zip)
7. Travis will Test Acceptance Criteria, and make sure Project/Code follows our standards.
8. If it passes, we move it to verify done (for BA's), else go to number 1 and have dev fix issues.
