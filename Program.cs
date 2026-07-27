using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Timers;
using Timer = System.Timers.Timer;

//----------------------------- LOCAL VARIABLES -----------------------------------
string[] shapeDictionary = ["square", "triangle", "circle", "donut", "hexagon"];
Mesh mesh = new Mesh();
Renderer renderer = new Renderer(mesh);

//------------------------------- SETUP LOGIC -------------------------------------
//Setup Timer
//Initialization - Startup
await InitIntroduction();
GetUserInput();

//Switch to different tab
Console.Write("\x1b[?1049h");
Console.CursorVisible = false;

mesh.InitSquareMesh();
renderer.Render();

// Wait 
Console.ReadKey(true);

//Swap back
Console.CursorVisible = true;
Console.Write("\x1b[?1049l");
GetUserInput();
//------------------------------- SETUP LOGIC -------------------------------------

//-------------------------------- FUNCTIONS --------------------------------------
async Task PrintWelcomeArtIntro()
{
    int delay = 200;
    
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(" _    _      _                            _                            _____     _                    _            ");
    await Task.Delay(delay);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("| |  | |    | |                          | |                          |____ |   | |                  (_)           ");
    await Task.Delay(delay);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("| |  | | ___| | ___ ___  _ __ ___   ___  | |_ ___    _ __ ___  _   _      / / __| |   ___ _ __   __ _ _ _ __   ___ ");
    await Task.Delay(delay);
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("| |/\\| |/ _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\ | __/ _ \\  | '_ ` _ \\| | | |     \\ \\/ _` |  / _ \\ '_ \\ / _` | | '_ \\ / _ \\");
    await Task.Delay(delay);
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("\\  /\\  /  __/ | (_| (_) | | | | | |  __/ | || (_) | | | | | | | |_| | .___/ / (_| | |  __/ | | | (_| | | | | |  __/");
    await Task.Delay(delay);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(" \\/  \\/ \\___|_|\\___\\___/|_| |_| |_|\\___|  \\__\\___/  |_| |_| |_|\\__, | \\____/ \\__,_|  \\___|_| |_|\\__, |_|_| |_|\\___|");
    await Task.Delay(delay);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("                                                                __/ |                            __/ |             ");
    await Task.Delay(delay);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("                                                               |___/                            |___/              ");
    await Task.Delay(delay);
    Console.ResetColor();
}

async Task PrintAsciiDivider()
{
    string[] divider = ["-", "<", ">", "-"];
    int counter = 0;
    int lastElement = divider.Length - 1;
    int iterationLength = 15;
    int length = divider.Length * iterationLength;
    
    for (int i = 0; i < length; i++)
    {   
        if (i >= length - 1)
        {
            Console.WriteLine(divider[lastElement]);
            await Task.Delay(10);
        }
        else
        {
            Console.Write(divider[counter]);
            if (counter >= lastElement)
            {
                counter = 0;
            }
            else
            {
                counter++;
            }

            await Task.Delay(10);
        }
    }
}

async Task PrintPickMessage()
{
    string[] message = ["Name", "a", "shape", "from", "the", "list", "you", "want", "to", "see!"];
    for (int i = 0; i < message.Length; i++)
    {
        Console.Write(message[i] + " ");
        await Task.Delay(100);
    }
    
    await Task.Delay(200);
    Console.Write("※ ");
    await Task.Delay(200);
    Console.Write("\\(^o^)/");
    await Task.Delay(200);
    Console.WriteLine("※");
}

async Task PrintShapeDictionary()
{
    for (int i = 0; i < shapeDictionary.Length - 1; i++)
    {
        if (i == (shapeDictionary.Length - 2))
        {
            await Task.Delay(300);
            Console.Write(shapeDictionary[i] + " or ");
            await Task.Delay(300);
            Console.Write(shapeDictionary[i + 1]);
            await Task.Delay(300);
            Console.Write(".");
            await Task.Delay(300);
            Console.Write(".");
            await Task.Delay(300);
            Console.WriteLine(".");
            await Task.Delay(300);
        }
        else
        {
            await Task.Delay(300);
            Console.Write(shapeDictionary[i] + ", ");
        }
    }
}

async Task InitIntroduction() {
    Console.Clear();

    await PrintWelcomeArtIntro();
    await Task.Delay(100);
    //await PrintAsciiDivider();
    await PrintPickMessage();
    await PrintShapeDictionary();
    //await PrintAsciiDivider();
}

void GetUserInput() {
    string userInputShape = Console.ReadLine();

        if (shapeDictionary.Contains(userInputShape.ToLower())) {
            Console.WriteLine("Loading " + userInputShape + "mesh... ");   
        } else {
            Console.WriteLine("Shape not found... ");
            Console.WriteLine("Pick something else from the list!");
            GetUserInput();
    }
}
//-------------------------------- FUNCTIONS --------------------------------------
