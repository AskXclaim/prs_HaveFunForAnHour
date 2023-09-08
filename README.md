# prs_HaveFunForAnHour
A demo Rock Paper Scissors Game

## About the project
The Solution contains three projects that work together.
- An Application/core project which is an Aspnet core class project that contains the Domain files/ interfaces
  used in other parts of the project. It's located at src/Application
- An Api project, built using Aspnet core WebApi that contains the Api used by the UI/ frontend.
  It's located at src/Api/AnHourOfFun.Api
- A UI project built with ReactJs. Located at src/Ui

## Setup Instructions
- You will need an IDE that can run an AspnetCore Web Api project. And one that can run ReactJs projects.
Here are some links to popular IDEs
Visual Studio 2022 https://visualstudio.microsoft.com/vs/community/
Visual Studio Code https://code.visualstudio.com/download

- You would also need to have Aspnet core 7 Sdk install on your machine/environment.
  Here is a link to download Aspnet core 7 sdk https://dotnet.microsoft.com/en-us/download/dotnet/7.0
- For ReactJs remember you will need to have node installed on your system. Here is a link to node
  https://nodejs.org/en/download.
- After installating a suitable IDE start up the Api application using the Https setting then
- run the `npm i` command to install the different needed packages for the ReactJs project
- after which you can now start the UI i.e. the ReactJs application using `npm start`



