using MyNotes.Data.Interfaces;
using MyNotes.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Data.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private static string notesPath;
        public void SetPath(string path)
        {
            notesPath = path;
        }

        public void AddNote(Note note)
        {
            using (StreamWriter notesStorage = new StreamWriter(notesPath, true))
            {
                notesStorage.WriteLine(note.content);
            }
        }

        public IEnumerable<Note> GetNotes()
        {
            List<Note> notesList = new List<Note> { };
            string textLine;
            using (StreamReader storage = new StreamReader(notesPath, Encoding.UTF8))
            {
                while ((textLine = storage.ReadLine()) != null)
                {
                    if (textLine.Length != 0)
                    {
                        notesList.Add(new Note { content = textLine });
                    }
                    
                }
            }
            return notesList;
        }
    }
}
