using System;

namespace _13_TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] taskList = new string[5];
            string[][] taskList2 = new string[10][];
            
            taskList2[0] = new string[] {"Take out the trash", "step one", "step two"};
            taskList2[1] = new string[] { "Take out the trash" };
            taskList2[2] = new string[] { "Take out the trash", "step one", "step two", "step 3" };
            taskList2[3] = new string[] { "Take out the trash", "step one", "step two" };
            taskList2[4] = new string[] { "Take out the trash", "step one", "step two" };

            ViewListWithSubtasks(taskList2);

            bool running = false;
            while (running) 
            {
                // prompt user to select list action
                Console.WriteLine("Task List\n=====================================\n1. View List\n2. Add a Task\n3. Remove a Task\n\nPress Q to quit\n=====================================\n");
                int selection = GetIntInRange("Make a selection :", 1, 3);

                // switch statement on
                switch (selection) 
                {
                    case 1:
                        // View list
                        ViewList(taskList);
                        Console.WriteLine($"\n");
                        break;
                    case 2:
                        // Add a task
                        AddToList(taskList);
                        Console.WriteLine($"\n");
                        break;
                    case 3:
                        // Remove a task
                        RemoveFromTaskList(taskList);
                        Console.WriteLine($"\n");
                        break;
                    default:
                        break;
                }

                Console.WriteLine($"\nWould you like to quit?");
                if (Console.ReadKey().KeyChar == 'q') 
                {
                    running = false;
                }
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
                input = Console.ReadLine();
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
                output = Console.ReadLine();
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

        static void ViewListWithSubtasks(string[][] taskArray)
        {
            string[] dayArray = new string[5];

            dayArray[0] = "monday";
            dayArray[1] = "tuesday";
            dayArray[2] = "wednesday";
            dayArray[3] = "thursday";
            dayArray[4] = "friday:";

            for (int i = 0; i < dayArray.Length; i++)
            {
                Console.WriteLine($"{dayArray[i]} : {taskArray[i][0]}");
                for (int j = 1; j < taskArray[i].Length; j++) 
                {
                    Console.WriteLine($"    - {taskArray[i][j]}");
                }
            }
        }

        //ADDING 
        //CREATE METHOD to put in the menu.  
        //getstring keeps reprompting         
        static void AddToList(string[] taskList) 
        {   
            string taskss;
            taskss = GetString("Enter Task to add:");

            bool isFull = true;
            // check for duplicates
            for (int i = 0; i < taskList.Length; i++) 
            {
                if (taskList[i] == taskss) 
                {
                    // repeate found
                    break;
                }
            }

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
    }
}
