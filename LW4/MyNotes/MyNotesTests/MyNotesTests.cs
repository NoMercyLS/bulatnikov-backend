using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNotes.Data.Models;
using MyNotes.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MyNotesTests
{
    [TestClass]
    public class AddNoteTest
    {
        private string pathAddNote = @"../../../src/NoNotes.txt";
        public void AddNote(Note note)
        {
            NotesRepository notesRepository = new NotesRepository();
            notesRepository.SetPath(pathAddNote);
            notesRepository.AddNote(note);
        }

        [TestMethod]
        public void AddNote_WithOneNote_ShouldAddNoteToFile()
        {
            string noteText = "Some content";
            Note note = new Note { content = noteText };
            AddNote(note);
            string expectedLine = "Some content";
            Assert.AreEqual(expectedLine, note.content);
        }
    }

    [TestClass]
    public class GetNoteTests
    {
        private string pathGetNote = @"../../../src/ExistingNotes.txt";
        public IEnumerable<Note> GetNote()
        {
            NotesRepository notesRepository = new NotesRepository();
            notesRepository.SetPath(pathGetNote);
            return notesRepository.GetNotes();
        }
        [TestMethod]
        public void GetNote_ShouldGetNoteListFromFile()
        {
            var notes = GetNote();
            string[] notesList = notes.Select(note => note.content).ToArray();
            string[] expectedList = { "Interesting 1", "Interesting 2", "Interesting 3" };
            CollectionAssert.AreEqual(expectedList, notesList);
        }
    }
}
