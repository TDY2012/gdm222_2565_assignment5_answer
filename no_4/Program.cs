using System;

class Program
{
    static int[] currentPos = new int[2]{ 0, 0 };
    static Stack<Tuple<int, int>> undoStack = new Stack<Tuple<int, int>>();
    static Stack<Tuple<int, int>> redoStack = new Stack<Tuple<int, int>>();

    static bool Move(int direction, int moveStep)
    {
        int[] newPos = new int[2]{currentPos[0], currentPos[1]};
        switch(direction)
        {
            case 1:
                newPos[1] += moveStep;
                break;
            case 2:
                newPos[0] -= moveStep;
                newPos[1] += moveStep;
                break;
            case 3:
                newPos[0] -= moveStep;
                break;
            case 4:
                newPos[0] -= moveStep;
                newPos[1] -= moveStep;
                break;
            case 5:
                newPos[1] -= moveStep;
                break;
            case 6:
                newPos[0] += moveStep;
                newPos[1] -= moveStep;
                break;
            case 7:
                newPos[0] += moveStep;
                break;
            case 8:
                newPos[0] += moveStep;
                newPos[1] += moveStep;
                break;
            default:
                //  Guaranteed to move outside of the board.
                newPos[0] += 8;
                newPos[1] += 8;
                break;
        }

        if(newPos[0] >= 0 && newPos[0] < 8 && newPos[1] >= 0 && newPos[1] < 8)
        {
            currentPos = newPos;
            return true;
        }

        return false;
    }

    static bool Undo()
    {
        if(undoStack.Count() > 0)
        {
            Tuple<int, int> command = undoStack.Pop();
            redoStack.Push(command);
            return Move(command.Item1, -command.Item2);
        }

        return false;
    }

    static bool Redo()
    {
        if(redoStack.Count() > 0)
        {
            Tuple<int, int> command = redoStack.Pop();
            undoStack.Push(command);
            return Move(command.Item1, command.Item2);
        }

        return false;
    }

    static string GetPosString(int posX, int posY)
    {
        //  NOTE -  'A' can be represented as 65 in ASCII.
        return string.Format("{0}{1}", (char)(posX + 65), posY + 1);
    }

    static void Main(string[] args)
    {
        int command;
        int moveStep;

        while(true)
        {
            command = int.Parse(Console.ReadLine());
            if(command >= 1 && command <= 8)
            {
                moveStep = int.Parse(Console.ReadLine());
                if(Move(command, moveStep))
                {
                    undoStack.Push(new Tuple<int, int>(command, moveStep));
                    redoStack = new Stack<Tuple<int, int>>();
                }
            }
            else if(command == 9)
            {
                Undo();
            }
            else if(command == 10)
            {
                Redo();
            }
            else
            {
                break;
            }
        }

        Console.WriteLine(GetPosString(currentPos[0], currentPos[1]));
    }
}