# Building
### 1. Prerequisites
- .NET 7 SDK
- Optionally, [Visual Studio 2022](https://visualstudio.microsoft.com/vs/), [Rider](https://www.jetbrains.com/rider), or other editor of choice

### 2. Preparing workload
#### Building with Visual Studio 2022
  - Open dobra3.sln file which will launch Visual Studio
  - Ensure that the following build settings match your configuration (toolbar):
    - Selected "Any CPU"
    - Startup project set to dobra3 (You can change the startup project by opening Solution Explorer > Right click dobra3 > "Set as startup project"<br/>
    ![image](https://github.com/taj-ny/dobra3/assets/53011783/1e559bee-95ce-4ec0-b96c-259806d238c4)
  
#### Building with Rider
  - Launch Rider
  - In the welcome screen, click "Open" and select dobra3.sln
  - Ensure that the following build settings match your configuration (toolbar):
    - Selected "Any CPU"<br/>
    ![image](https://github.com/taj-ny/dobra3/assets/79316397/df1016b1-f495-44b4-8f5b-2438fad046d5)

    - Startup project set to dobra3<br/>
    ![image](https://github.com/taj-ny/dobra3/assets/79316397/0cb907f5-498a-4e8e-9f61-4c4f56b8421b)

#### Building with Terminal

Open a terminal window and paste the following command:
```ps
dotnet build dobra3
```

To build Release version of the app, modify the command as follows:
```ps
dotnet build dobra3 -c Release
```
