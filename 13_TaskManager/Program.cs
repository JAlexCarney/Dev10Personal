using System;

namespace _13_TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] taskList = new string[5][];
            
            taskList[0] = new string[] {"Take out the trash", "step one", "step two"};

            bool running = true;
            while (running) 
            {
                // prompt user to select list action
                Console.WriteLine("Task List\n=====================================\n1. View List\n2. Add a Task\n3. Remove a Task\n4. Remove a SubTask\n\nPress Q to quit\n=====================================\n");
                int selection = GetIntInRange("Make a selection :", 1, 4);

                // switch statement on
                switch (selection) 
                {
                    case 1:
                        // View list
                        Console.Clear();
                        ViewList(taskList);
                        break;
                    case 2:
                        // Add a task
                        Console.Clear();
                        AddToList(taskList);
                        break;
                    case 3:
                        // Remove a task
                        Console.Clear();
                        RemoveFromTaskList(taskList);
                        break;
                    case 4:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This feature is not yet implemented :P");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        break;
                }

                Console.WriteLine($"Press any key to continue...");
                if (Console.ReadKey().KeyChar == 'q') 
                {
                    running = false;
                }

                Console.Clear();
            }
        }

        // input : prompt, minimum valid number, maximum valid number
        // output : 
        static int GetIntInRange(string prompt, int min, int max) 
        {
            int output;
            string input;
            do
            {
                Console.WriteLine(prompt);
                Console.ForegroundColor = ConsoleColor.Cyan;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            } 
            while (!int.TryParse(input, out output) || !(output >= min) || !(output <= max));

            return output;
        }

        // Input : prompt
        // Output : non-empty user string
        static string GetString(string prompt) 
        {
            string output = "";
            do
            {
                Console.WriteLine(prompt);
                Console.ForegroundColor = ConsoleColor.Cyan;
                output = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
            while (string.IsNullOrEmpty(output));
            return output;
        }

        // Input : Task Array, index to remove
        // Output : void
        // Summary : Remove a task from the task array
        static void RemoveFromTaskList(string[] taskList) 
        {
            Console.WriteLine("Here is your current list:");
            ViewList(taskList);

            int indexToRemove = GetIntInRange("Which task would you like to remove?", 1, taskList.Length) - 1;
            
            // remove task
            taskList[indexToRemove] = null;

            // shift elements forward
            for (int i = 1; i < taskList.Length; i++) 
            {
                if (string.IsNullOrEmpty(taskList[i - 1])) 
                {
                    taskList[i - 1] = taskList[i];
                    taskList[i] = null;
                }
            }
        }

        // Input : Task Array, index to remove
        // Output : void
        // Summary : Remove a task from the task array
        static void RemoveFromTaskList(string[][] taskList)
        {
            Console.WriteLine("Here is your current list:");
            ViewList(taskList);

            int indexToRemove = GetIntInRange("Which task would you like to remove?", 1, taskList.Length) - 1;

            // remove task
            taskList[indexToRemove] = null;

            // shift elements forward
            for (int i = 1; i < taskList.Length; i++)
            {
                if (taskList[i - 1] == null)
                {
                    taskList[i - 1] = taskList[i];
                    taskList[i] = null;
                }
            }
        }

        //View create list for viewing

        static void ViewList(string[] taskArray)
        {
            
            string[] dayArray = new string[5];

            dayArray[0] = "monday";
            dayArray[1] = "tuesday";
            dayArray[2] = "wednesday";
            dayArray[3] = "thursday";
            dayArray[4] = "friday:";

            for (int i = 0; i < dayArray.Length; i++)
            {
                Console.WriteLine($"{dayArray[i]} : {taskArray[i]}");
            }

        }

        //View create list for viewing

        static void ViewList(string[][] taskArray)
        {
            string[] dayArray = new string[5];

            dayArray[0] = "1";
            dayArray[1] = "2";
            dayArray[2] = "3";
            dayArray[3] = "4";
            dayArray[4] = "5";

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < dayArray.Length; i++)
            {
                if (taskArray[i] != null) 
                {
                    Console.WriteLine($"{dayArray[i]} : {taskArray[i][0]}");
                    for (int j = 1; j < taskArray[i].Length; j++)
                    {
                        Console.WriteLine($"    - {taskArray[i][j]}");
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        //ADDING 
        //CREATE METHOD to put in the menu.  
        //getstring keeps reprompting         
        static void AddToList(string[] taskList) 
        {   
            string taskss;
            taskss = GetString("Enter Task to add:");

            bool isFull = true;
            
            for (int i = 0; i < taskList.Length; i++) 
            {
                if (string.IsNullOrEmpty(taskList[i]))
                {
                    taskList[i] = taskss;
                    Console.WriteLine($"Added {taskss} to the list.");
                    isFull = false;
                    break;
                }
            }
            if (isFull)
            {
                Console.WriteLine("List is full. Remove task to Add more.");
            }
        }

        //ADDING with Subtasks
        //CREATE METHOD to put in the menu.  
        //getstring keeps reprompting         
        static void AddToList(string[][] taskList)
        {
            string taskss;
            taskss = GetString("Enter Task to add:");

            bool isFull = true;

            for (int i = 0; i < taskList.Length; i++)
            {
                if (taskList[i] == null)
                {
                    Console.Clear();
                    Console.WriteLine($"Added {taskss} to the list.");
                    int numSubTasks = GetIntInRange("How many subtasks are there?", 0, 100);

                    taskList[i] = new string[numSubTasks + 1];
                    taskList[i][0] = taskss;
                    for (int j = 1; j < taskList[i].Length; j++) 
                    {
                        taskList[i][j] = GetString("Enter a subtask: ");
                    }
                    
                    isFull = false;
                    break;
                }
            }
            if (isFull)
            {
                Console.WriteLine("List is full. Remove task to Add more.");
            }
        }
    }
}
