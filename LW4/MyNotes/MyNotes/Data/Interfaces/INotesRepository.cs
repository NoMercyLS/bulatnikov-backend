using MyNotes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotes.Data.Interfaces
{
    public interface INotesRepository
    {
        IEnumerable<Note> GetNotes();
        void AddNote(Note note);
        void SetPath(string path);
    }
}
