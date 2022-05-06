# MonoGame POC

The objective of this POC is test basic mechanisms of the game.

# Task list

The current task list is:

 - Create a splash screen; OK
 - Create a menu using IM GUI; OK
 - Basic walk over the map; OK
 - Create a background; OK
 - Use engine to make physics;
 - Create the hero;
 - Create an enemy;
 - Create a parallax background;
 - Create win and loose logic with an HUD;
 - Add soundtrack;
 - Add sound effects.

Non functional requirements:
 - Run in mobile;
 - Run in desktop.

 # Como executar o MGCB no Linux

 Clone o codigo fonte do MonoGame.
 Compile o editor usando o comando `dotnet publish -c Release Tools/MonoGame.Content.Builder.Editor/MonoGame.Content.Builder.Editor.Linux.csproj --self-contained true --runtime linux-x64 -p:PublishSingleFile=true --output /tmp/mgcb-editor`