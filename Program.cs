using System;
using System.Collections.Generic;



class Program
{
    static List<Note> notes = new List<Note>
    {
        new Note { Title = "Пересдача", Description = "Готовиться усердно", Date = new DateTime(2024, 1, 29) },
        new Note { Title = "Отдых", Description = "зарубить некиту в вальхейме", Date = new DateTime(2024, 2, 6) },
        new Note { Title = "Конец практики", Description = "Блин, снова в тех", Date = new DateTime(2024, 3, 24) },
    };

    static int currentIndex = 0;

    static void Main()
    {
        Console.CursorVisible = false;

        while (true)
        {
            string[] menuItems = notes.Select(note => note.Title).ToArray();
            int selectedNoteIndex = ArrowMenu.ShowMenu(menuItems);

            if (selectedNoteIndex == -1)
            {
                break;
            }

            currentIndex = selectedNoteIndex;
            Details();
        }
    }
    static void Menu()
    {
        Console.WriteLine("Ежедневник");

        for (int i = currentIndex; i < currentIndex + 5 && i < notes.Count; i++)
        {
            Console.WriteLine($"[{i - currentIndex + 1}] {notes[i].Title}");
        }
    }

    static void Details()
    {
        if (currentIndex < notes.Count)
        {
            Note selectedNote = notes[currentIndex];
            Console.Clear();
            Console.WriteLine($"Название: {selectedNote.Title}");
            Console.WriteLine($"Описание: {selectedNote.Description}");
            Console.WriteLine($"Дата: {selectedNote.Date.ToShortDateString()}");
            Console.WriteLine("\nНажмите на любую клавишу для возврата в меню");
            Console.ReadKey();
        }
    }

}

class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
}