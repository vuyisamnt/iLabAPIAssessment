# iLabAPIAssessment

Steps for running the project
1. Download the project
2. Open the project on visual studio 2019 community atleast
3. Download and install Specflow on this location -> https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowForVisualStudio
4. Restart vs 2019
5. Update the location 
6. Build the project
7. Please update Extent Reporting path location to your location on line 39 in Hooks.cs
8. Click on test View tab and select Test Explorer
9. If the tests do no show on Test Explorer 
    - Go to project Solution Explorer
    - Right click on the project
    - Select Manage NuGet Packages
    - Unsistall NUnitTestAdapter
    - Reinstall NUnitTestAdapter - 3.17.0
    - Build the project
    - The tests should be on Test Explorer Tab
    

