using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;

namespace Prisms;

public static class Program {
    public static void Main(String[] args) {
        RenderWindow window = new(new VideoMode(800, 600), "Prisms", Styles.Default);
        window.SetVerticalSyncEnabled(true);
        
        ScreenManager manager = new ScreenManager(window);

        window.Resized += (sender, e) => {
            window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
            manager.Resize();
        };

        MainMenuScreen mainMenu = new MainMenuScreen(window);
        manager.LoadScreen(mainMenu);

        while (window.IsOpen) {
            window.DispatchEvents();

            Time.Update();
            manager.Update();
            manager.Draw();

            window.Display();
        }
    }
}
